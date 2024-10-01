using TcpStandard_Server.StandTcpProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetty.Transport.Channels;
using DotNetty.Buffers;
using DotNetty.Transport.Channels.Sockets;
using DotNetty.Codecs.Mqtt.Packets;

namespace TcpStandard_Server.StandTcpController
{
    public class StandTCPControllerManager : CardStatusInterface
    {
        UInt16 OemCode = 23456;

        public List<TCPController> Controllerlist = new List<TCPController>();
        public EventHandleInterface EventHandle;

        public TCPLinkHandle LinkHandler(Boolean isTls, Boolean useMqttBin)
        {
            return new TCPLinkHandle(this, isTls, useMqttBin);
        }

        public StandTCPControllerManager(EventHandleInterface eventHandle)
        {
            EventHandle = eventHandle;
        }

        // 更新所有其他相同group值的控制器里面，该卡的状态值
        public void SetCardStatus(String Serial, int group, UInt16 Index, byte status)
        {
            foreach (TCPController a in Controllerlist)
            {
                if (a.Group == group)
                    if (a.SerialNo == Serial)
                    {
                        a.pullCmd.AddPullCmd(true, StandTCPCmd.SetCardStatus(Index, status));
                    }
            }
        }

        public TCPController GetController(string serial)
        {
            foreach (TCPController a in Controllerlist)
            {
                if (a.SerialNo == serial)
                //if (a.WorkStatus != TCPWorkStatus.Close)
                {
                    return a;
                }
            }
            return null;
        }

        public void SetOemCode(UInt16 OemCode)
        {
            foreach (TCPController a in Controllerlist)
            {
                if (a.WorkStatus != TCPWorkStatus.Close)
                {
                    a.OemCode = OemCode;
                }
            }
        }

        public TCPController AddControl(String SerialNo, String name)
        {
            TCPController acs = new TCPController(this, EventHandle);
            acs.OemCode = OemCode;
            acs.SerialNo = SerialNo;
            acs.Name = name;
            Controllerlist.Add(acs);
            return acs;
        }
    }

    // 控制器接收通讯类 
    public class TCPLinkHandle : SimpleChannelInboundHandler<object>
    {
        TCPController Controller = null;
        Boolean IsTls, UseMqttBin;
        int MqttPacketId = 0;
        IChannelHandlerContext ctx;
        public StandTCPControllerManager allControllers;

        public TCPLinkHandle(StandTCPControllerManager value, Boolean isTls, Boolean useMqttBin)
        {
            IsTls = isTls;
            UseMqttBin = useMqttBin;
            allControllers = value;
        }

        public Boolean Connected()
        {
            if (ctx == null) return false;
            return ctx.Channel.Active;
        }

        public Boolean Send(byte[] cmdbuf)
        {
            if (Connected() == false) return false;

            if (UseMqttBin)
            {
                MqttPacketId++;
                // rpublishPacket.PacketId = publishPacket.PacketId;
                PublishPacket rpublishPacket = new PublishPacket(QualityOfService.ExactlyOnce, false, false)
                {
                    TopicName = "Ack",
                    PacketId = MqttPacketId,
                    Payload = Unpooled.WrappedBuffer(cmdbuf)
                };
                ctx.WriteAndFlushAsync(rpublishPacket);
            }
            else
            {
                IByteBuffer buf = Unpooled.WrappedBuffer(cmdbuf);
                ctx.WriteAndFlushAsync(buf);//将接受到的消息写给发送者，而不冲刷出站消息·
            }
            return true;
        }

        public static string DecodeString(IByteBuffer src, int readerIndex, int len, Encoding encoding)
        {
            if (len == 0)
            {
                return string.Empty;
            }

            if (src.IoBufferCount == 1)
            {
                ArraySegment<byte> ioBuf = src.GetIoBuffer(readerIndex, len);
                return encoding.GetString(ioBuf.Array, ioBuf.Offset, ioBuf.Count);
            }
            else
            {
                int maxLength = encoding.GetMaxCharCount(len);
                IByteBuffer buffer = src.Allocator.HeapBuffer(maxLength);
                try
                {
                    buffer.WriteBytes(src, readerIndex, len);
                    ArraySegment<byte> ioBuf = buffer.GetIoBuffer();
                    return encoding.GetString(ioBuf.Array, ioBuf.Offset, ioBuf.Count);
                }
                finally
                {
                    // Release the temporary buffer again.
                    buffer.Release();
                }
            }
        }

        public static byte[] DecodeBytes(IByteBuffer src, int readerIndex, int len)
        {
            if (len == 0)
            {
                return new byte[0];
            }

            if (src.IoBufferCount == 1)
            {
                ArraySegment<byte> ioBuf = src.GetIoBuffer(readerIndex, len);
                byte[] rs = new byte[ioBuf.Count];
                Array.Copy(ioBuf.Array, ioBuf.Offset, rs, 0, ioBuf.Count);
                return rs;
            }
            else
            {
                IByteBuffer buffer = src.Allocator.HeapBuffer(0xFFFF);
                try
                {
                    buffer.WriteBytes(src, readerIndex, len);
                    ArraySegment<byte> ioBuf = buffer.GetIoBuffer();

                    byte[] rs = new byte[ioBuf.Count];
                    Array.Copy(ioBuf.Array, ioBuf.Offset, rs, 0, ioBuf.Count);
                    return rs;
                }
                finally
                {
                    buffer.Release();
                }
            }
        }

        protected override void ChannelRead0(IChannelHandlerContext context, object message)
        {
            IByteBuffer buffer = null;
            byte[] data = null;
            byte[] cmdbuf = null;

            int len = 0;
            ctx = context;
            PublishPacket publishPacket = null;

            if (!UseMqttBin)
            {
                buffer = message as IByteBuffer;
            }

            if (IsTls)
            {
                buffer = message as IByteBuffer;
                if (buffer == null) return;
                data = DecodeBytes(buffer, 0, buffer.ReadableBytes);
                len = data.Length;
            }
            else
            {
                if (!UseMqttBin)
                {
                    len = buffer.ReadableBytes;
                    data = new byte[len];
                    Array.Copy(buffer.Array, 0, data, 0, len);
                }
            }

            if (UseMqttBin)
            {
                Packet MqttPacket = message as Packet;

                if (MqttPacket.PacketType == PacketType.CONNECT)
                {
                    ConnectPacket connectPacket = message as ConnectPacket;
                    allControllers.EventHandle.ShowMsg(" Connect ", connectPacket.ClientId + " " + connectPacket.Username);

                    var connAckPacket = new ConnAckPacket();

                    connAckPacket.ReturnCode = ConnectReturnCode.Accepted;
                    context.WriteAndFlushAsync(connAckPacket);
                    return;
                }

                //if (MqttPacket.PacketType != PacketType.PUBLISH) return;

                if (MqttPacket.PacketType == PacketType.PUBLISH)
                {
                    publishPacket = message as PublishPacket;
                    // allControllers.EventHandle.ShowMsg(" Publish ", publishPacket.Payload.ToString());

                    buffer = publishPacket.Payload;
                    MqttPacketId = publishPacket.PacketId;
                    data = DecodeBytes(buffer, 0, buffer.ReadableBytes);
                    len = data.Length;
                }
            }
            if (buffer == null) return;

            allControllers.EventHandle.ContrlSendCmdHex(data);

            if (!StandTCPCmd.CheckRxDataCS(data)) return; // 校验接收的数据 

            if (data[2] == (byte)0x56)
            {
                RHeartStatus HeartStatus = StandTCPCmd.HeartBuf2Struct(data);
                String serial = HeartStatus.SerialNo;

                Controller = allControllers.GetController(serial);
                if (Controller == null)
                {
                    Controller = allControllers.AddControl(serial, serial);
                }
            }
            if (Controller == null) return;

            cmdbuf = Controller.TcpLink(data, this);
            if (cmdbuf == null) return;

            allControllers.EventHandle.SoftSendCmdHex(cmdbuf);

            if (UseMqttBin)
            {
                PubAckPacket pubAckPacket = new PubAckPacket();
                if (publishPacket != null)
                    pubAckPacket.PacketId = publishPacket.PacketId;
                context.WriteAndFlushAsync(pubAckPacket);

                MqttPacketId++;
                // rpublishPacket.PacketId = publishPacket.PacketId;
                PublishPacket rpublishPacket = new PublishPacket(QualityOfService.ExactlyOnce, false, false)
                {
                    TopicName = "Ack",
                    PacketId = MqttPacketId,
                    Payload = Unpooled.WrappedBuffer(cmdbuf)
                };


                context.WriteAndFlushAsync(rpublishPacket);

            }
            else
            {
                IByteBuffer buf = Unpooled.WrappedBuffer(cmdbuf);
                context.WriteAndFlushAsync(buf);//将接受到的消息写给发送者，而不冲刷出站消息·
            }
        }

        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            context.CloseAsync();
            ctx = context;
        }
    }
}