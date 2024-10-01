using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Security.Authentication;
using System.IO;
using DotNetty.Handlers.Tls;
using DotNetty.Codecs;
using DotNetty.Buffers;
using DotNetty.Codecs.Mqtt;

namespace TcpStandard_Server.StandTcpController
{
    public class StandardTCPServer
    {
        IEventLoopGroup bossGroup;
        IEventLoopGroup workerGroup;
        IChannel bootstrapChannel;
        ServerBootstrap bootstrap;

        private Boolean isStop = false;
        private int Port;
        private Boolean useTLS = false;
        private Boolean UseMqttBin;
        private StandTCPControllerManager AllCntrls;
        public event TOnServerStatus onServerStatus;
        X509Certificate2 tlsCertificate = null;

        public StandardTCPServer(StandTCPControllerManager allController)
        {
            this.AllCntrls = allController;
        }

        #region 服务管理

        private void StatusChange(Boolean active)
        {
            if (null != onServerStatus)
                onServerStatus(active, "");
        }

        private void run(int port, Boolean isTls, Boolean isMqttBin)
        {
            Port = port;
            try
            {
                RunServerAsync(AllCntrls, port, isTls, isMqttBin).Wait();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("ServerTcpRun." + e.Message);
            }
        }

        public void Stop()
        {
            Task runTask = new Task(() =>
            {
                isStop = true;
            });
            runTask.Start();
        }

        public void Start(int port, Boolean isTls, Boolean isMqttBin)
        {
            Task runTask = new Task(() =>
            {
                run(port, isTls, isMqttBin);
            });
            runTask.Start();
        }

        public Boolean Active()
        {
            if (bossGroup == null) return false;
            if (workerGroup == null) return false;
            if (bootstrapChannel == null) return false;

            return bootstrapChannel.Active && (!isStop);
        }
        #endregion

        public static X509Certificate2 GetTestCertificate()
        {
            string s = "web3.pfx";

            FileStream fstream = new FileStream(s, FileMode.Open);
            byte[] bData = new byte[fstream.Length];
            fstream.Seek(0, SeekOrigin.Begin);
            fstream.Read(bData, 0, bData.Length);

            return new X509Certificate2(bData, "1");
        }

        public async Task RunServerAsync(StandTCPControllerManager allController, int port, Boolean isTls, Boolean isMqttBin)
        {
            this.Port = port;
            isStop = false;
            useTLS = isTls;
            UseMqttBin = isMqttBin;
            if (isTls)
            {
                tlsCertificate = GetTestCertificate();
            }

            try
            {
                bossGroup = new MultithreadEventLoopGroup(1);
                workerGroup = new MultithreadEventLoopGroup();
                bootstrap = new ServerBootstrap();
                bootstrap.Group(bossGroup, workerGroup);
                bootstrap.Channel<TcpServerSocketChannel>();

                bootstrap
                      .Option(ChannelOption.SoBacklog, 10000)
                    //.Option(ChannelOption.SoBacklog, 8192)
                    .ChildHandler(new ActionChannelInitializer<ISocketChannel>(channel =>
                    {
                        IChannelPipeline pipeline = channel.Pipeline;
                        if (useTLS) pipeline.AddLast(TlsHandler.Server(tlsCertificate));

                        if (UseMqttBin)
                        {
                            MqttDecoder md = new MqttDecoder(true, 1024);
                            pipeline.AddLast(new MqttEncoder());
                            pipeline.AddLast(md);
                        }
                        pipeline.AddLast(allController.LinkHandler(useTLS, UseMqttBin));

                    }))
                    // .Option(ChannelOption.SoRcvbuf, 512)
                    //   .ChildOption(ChannelOption.SoSndbuf, 512)
                    .ChildOption(ChannelOption.TcpNodelay, true) //不延迟，消息立即发送
                    .Option(ChannelOption.RcvbufAllocator, new AdaptiveRecvByteBufAllocator(512, 1024, 2048))
                    .ChildOption(ChannelOption.RcvbufAllocator, new FixedRecvByteBufAllocator(4096))
                    // .Option(ChannelOption.Allocator,  PooledByteBufAllocator.DEFAULT)
                    // .ChildOption(ChannelOption.Allocator, PooledByteBufAllocator.DEFAULT)
                    .ChildOption(ChannelOption.SoKeepalive, true);

                bootstrapChannel = await bootstrap.BindAsync(port);

                StatusChange(true);

                while (!isStop)
                {
                    Thread.Sleep(50);
                }
                await bootstrapChannel.DisconnectAsync();
                await bootstrapChannel.CloseAsync();
            }
            finally
            {
                await Task.WhenAll(
                    bossGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)),
                    workerGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)));
                StatusChange(false);
            }
        }
    }
}
