using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Timers;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

using TcpClass; 

namespace TcpClass.Controller
{
    // 网络通讯的客户端模式实现 的基类
    public class ClassTcpClientBase : ITCPNet
    {
        #region constdata
        public const byte TcpErr_OK = 0;
        public const byte TcpErr_NotExists = 1; // 对象不存在
        public const byte TcpErr_DataErr = 2; // 数据超出边界
        public const byte TcpErr_OutTime = 3; // 操作超时
        public const byte TcpErr_UnLink = 4; //
        public const byte TcpErr_ReData = 5; // 返回数据错误
        public const byte TcpErr_Working = 6; //
        public const byte TcpErr_Unknow = 7; //
        #endregion

        #region 内部变量
        public byte TCPLastError = 0;
        public string remoteHost = "192.168.0.71";
        public int remotePort = 8000;
        public string AESPIN = "abcdefgh20161234";
        public Boolean AES182 = false;

        private Socket sock;
        private IPEndPoint iep;
        private System.Timers.Timer timer;
        private Boolean Reconnet = false;
        private Boolean timerEnable = true;
        protected Boolean IsconnectSuccess = false; //异步连接情况，由异步连接回调函数置位 
        protected int StartTick = 0;

        protected byte[] BufferRX = new byte[512];
        protected byte[] BufferTX = new byte[512];

        protected byte isHeartTime = 0;

        protected String SockErrorStr = null;        
        #endregion

        #region 委托事件实现
        public event EventSocketConnected OnSocketConnected;
        public event TOnDataHandler OnDataEvent;
        public event TOnRxTxDataHandler OnRxTxDataEvent;        //声明事件  
        #endregion

        public ClassTcpClientBase()
        {
            StartTick = 0;
            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(timer_Tick);
            timer.Interval = 500;
            timer.Enabled = false;
        }

        #region 接口实现 interface
        public void SetTcpTick()
        {
            isHeartTime = 0;
        }

        public Boolean IsConnectSuccess()
        {
            return IsconnectSuccess;
        }
       
        public virtual Boolean isWorking()
        {
            return false;
        }

        public virtual void ClearWait()
        {
        }

        public virtual Boolean SendAndNOReturn(byte[] buffTX)
        {
            return false;
        }

        public virtual Boolean SendAndReturn(int delay, byte[] buffTX)
        {
            return false;
        }

        public void SetAES(string pin, Boolean UseAES128)
        {
            AESPIN = pin;
            AES182 = UseAES128;
        }

        public byte LastError()
        {
            return TCPLastError;
        }
        #endregion


        #region 测试调试信息 
        protected void DoOnDataEvent(byte[] buf, int len)
        {
            if (OnDataEvent != null)
            {
                OnDataEvent(buf, len);
            }
        }

        // Send and receive data debug
        protected void DoOnRxTxDataEvent(byte[] buf, int len,bool isSend)
        {
            if (OnRxTxDataEvent != null)
            {
                OnRxTxDataEvent(buf, len,isSend);
            }
        }

        protected void DoSocketConnected(bool link)
        {
            if (OnSocketConnected != null)
            {
                OnSocketConnected(link);
            }
        }
        #endregion

        #region Socket Connent
        protected int GetStartTick()
        {
            return StartTick;
        }

        private bool IsSocketConnected()
        {
            bool connectState = true;
            bool blockingState = sock.Blocking;
            try
            {
                byte[] tmp = new byte[1];

                sock.Blocking = false;
                sock.Send(tmp, 1, 0);
                connectState = true;  
            }
            catch (SocketException e)
            {
                if (e.NativeErrorCode.Equals(10035))
                {
                    connectState = true;
                }
                else
                {
                    SockErrorStr = e.ToString();
                    connectState = false;
                    IsconnectSuccess = false;
                }
            }
            finally
            {
                sock.Blocking = blockingState;
            }
            return connectState;
        }

        /// 另一种判断connected的方法，但未检测对端网线断开或ungraceful的情况 
        private bool IsSocketConnected(Socket s)
        {
            #region remarks
            /* As zendar wrote, it is nice to use the Socket.Poll and Socket.Available, but you need to take into consideration 
             * that the socket might not have been initialized in the first place. 
             * This is the last (I believe) piece of information and it is supplied by the Socket.Connected property. 
             * The revised version of the method would looks something like this: 
             * from：http://stackoverflow.com/questions/2661764/how-to-check-if-a-socket-is-connected-disconnected-in-c */
            #endregion

            try
            {
                if (s == null)
                    return false;
                return !((s.Poll(1000, SelectMode.SelectRead) && (s.Available == 0)) || !s.Connected);
            }
            catch (SocketException e)
            {
                IsconnectSuccess = false;
                SockErrorStr = e.ToString();
                return false;
            }
        }
        //================================================================================================================================
       
        /// 创建套接字+异步连接函数
        private bool socket_create_connect()
        {
            if (remoteHost == "") return false;
            try
            {
                IPAddress serverIp = IPAddress.Parse(remoteHost);
                int serverPort = Convert.ToInt32(remotePort);
                iep = new IPEndPoint(serverIp, serverPort);

                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.SendTimeout = 500;
                sock.BeginConnect(iep, new AsyncCallback(connectedCallback), sock);
            }
            catch (Exception err)
            {
                SockErrorStr = err.ToString();
                return false;
            }
            return true;
        }

        /// 异步连接回调函数
        private void connectedCallback(IAsyncResult iar)
        {
            Socket client = (Socket)iar.AsyncState;
            try
            {
                timer.Enabled = true;
                if (sock.Connected)
                {
                    sock.EndConnect(iar);
                    IsconnectSuccess = true;
                    DoSocketConnected(true);
                    sock.BeginReceive(BufferRX, 0, BufferRX.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), sock);
                }
                else
                {
                    IsconnectSuccess = false;
                }
            }
            catch (Exception e)
            {
                SockErrorStr = e.ToString();
                IsconnectSuccess = false;
            }
        }

        private bool Reconnect()
        {
            try
            {
                sock.Shutdown(SocketShutdown.Both);
                sock.Disconnect(true);
                IsconnectSuccess = false;
                sock.Close();
            }
            catch (Exception ex)
            {
                SockErrorStr = ex.ToString();
            }
            return socket_create_connect();
        }

        #endregion

        #region Open or Close IP
        public bool OpenIP(string ip, int port)
        {
            if (ip == "") return false;
            Reconnet = true;
            if (IsconnectSuccess) return true;

            remoteHost = ip;
            remotePort = port;
            return socket_create_connect();
        }

        public bool CloseTcpip()
        {
            timer.Enabled = false;
            Reconnet = false;
            DoSocketConnected(false);
            lock (this)
            {
                if (sock != null)
                    if (IsconnectSuccess)
                    {
                        try
                        {
                            timer.Enabled = false;
                            sock.Disconnect(false);
                            IsconnectSuccess = false;
                        }
                        catch (Exception ex)
                        {
                            SockErrorStr = ex.ToString();
                        }
                    }
            }
            timer.Enabled = false;
            return true;
        }
        #endregion

        #region 加密解密
        public static byte[] Decrypt(byte[] value, string key, int len)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            Aes Aes = Aes.Create();
            Aes.KeySize = 128;
            Aes.Key = keyArray;
            Aes.Mode = CipherMode.ECB;
            Aes.Padding = PaddingMode.Zeros;

            ICryptoTransform cTransform = Aes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(value, 0, len);
            return resultArray;
        }

        public static byte[] Encrypt(byte[] value, string key, int len)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            Aes Aes = Aes.Create();
            Aes.KeySize = 128;
            Aes.Key = keyArray;
            Aes.Mode = CipherMode.ECB;
            Aes.Padding = PaddingMode.Zeros;

            ICryptoTransform cTransform = Aes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(value, 0, len);
            return resultArray;
        }
        #endregion
        
        
        #region 接收数据  Receive data   
        private void ReceiveCallBack(IAsyncResult ar)
        {
            try
            {
                lock (BufferRX)
                {
                    Socket peerSock = (Socket)ar.AsyncState;
                    int BytesRead = peerSock.EndReceive(ar);
                    if (BytesRead > 0)
                    {
                        if (BytesRead > 512)
                            BytesRead = 512;

                        if (AES182)
                        {
                            byte[] rbuf = Decrypt(BufferRX, AESPIN, BytesRead);
                            Array.Copy(rbuf, BufferRX, rbuf.Length);
                        } 

                        DoOnRxTxDataEvent(BufferRX, BytesRead, false);
                        DoOnDataEvent(BufferRX, BytesRead);
                        
                    }
                    else//对端gracefully关闭一个连接
                    {
                        if (sock.Connected)//上次socket的状态
                        {
                            DoSocketConnected(true);
                            return;
                        }
                    }
                    sock.BeginReceive(BufferRX, 0, BufferRX.Length, 0, new AsyncCallback(ReceiveCallBack), sock);
                } 
            }
            catch (Exception ex)
            {
                SockErrorStr = ex.ToString();
                DoSocketConnected(false);
                return;
            }
        }

        private void SendDataEnd(IAsyncResult iar)
        {
            Socket remote = (Socket)iar.AsyncState;
            int sent = remote.EndSend(iar);
        }

        public byte DoSendData(byte[] buffTX, int WriteNum)
        {
            byte[] bufTX;
            StartTick = Environment.TickCount;
            try
            {
                if (IsconnectSuccess)
                    lock (buffTX)
                    {
                        Array.ConstrainedCopy(buffTX, 0, BufferTX, 0, WriteNum);

                        DoOnRxTxDataEvent(BufferTX, WriteNum,true);

                        if (AES182)
                        {
                            bufTX = Encrypt(BufferTX, AESPIN, WriteNum);
                            WriteNum = bufTX.Length;
                            lock (sock)
                                sock.BeginSend(bufTX, 0, WriteNum, SocketFlags.None, new AsyncCallback(SendDataEnd), sock);
                        }
                        else
                        {
                            lock (sock)
                                sock.BeginSend(buffTX, 0, WriteNum, SocketFlags.None, new AsyncCallback(SendDataEnd), sock);
                        }
                        return 0;
                    }
                return 4;
            }
            catch (Exception ex)
            {
                SockErrorStr = ex.ToString();
                return 7;
            }
        }
        #endregion

        private void timer_Tick(object sender, ElapsedEventArgs e)
        {
            if (!timerEnable) { timer.Enabled = false; return; }
            if (!Reconnet) { timer.Enabled = Reconnet; return; }
            try
            {
                isHeartTime++;
                if (isHeartTime > 10)
                {
                    isHeartTime = 0;

                    if (sock == null)
                    {
                        timer.Enabled = false;
                        DoSocketConnected(false);
                        socket_create_connect();
                    }
                    else
                        if ((!sock.Connected) || (!IsSocketConnected(sock)) || (!IsSocketConnected()))
                        {
                            DoSocketConnected(false);
                            timer.Enabled = false;
                            IsconnectSuccess = false;
                            Reconnect();
                        }
                }
            }
            catch (Exception ex)
            {
                SockErrorStr = ex.ToString();
                IsconnectSuccess = false;
                timer.Enabled = true;
            }
        }
    }
    

    // 网络通讯的客户端模式实现 TCPClinet 类
    public class ClassTcpClientWorker : ClassTcpClientBase
    {        
        #region 内部变量
        private Boolean Busy;
        private volatile Boolean FisWaiting;
        #endregion
        public ClassTcpClientWorker() : base()
        { 
        }

        #region 接口实现      
        
        public override Boolean isWorking()
        {
            if (Busy) TCPLastError = TcpErr_Working;
            return Busy;
        }

        public override void ClearWait()
        {
            FisWaiting = false;
        }
        public override Boolean SendAndNOReturn(byte[] buffTX)
        {
            byte re;
            re = DoSendData(buffTX, buffTX.Length);
            TCPLastError = re;
            return (re == 0);
        }

        public override Boolean SendAndReturn(int delay, byte[] buffTX)
        {
            Boolean result = false;
            byte re;
            Busy = true;
            try
            {
                FisWaiting = true;
                re = DoSendData(buffTX, buffTX.Length);
                TCPLastError = re;
                if (re == 0) 
                {
                    result = WaitReturn(delay);
                }    
                
            }
            finally
            {
                Busy = false;
                
            }
            return result;
        }
        #endregion

        #region 发送数据
        
        private Boolean WaitReturn(int delay)
        {
            Boolean te, result;

            while (FisWaiting)
            {
                Thread.Sleep(2);

                SetTcpTick();

                int StartTick = Environment.TickCount - GetStartTick();

                te = StartTick > (200 + delay);
                if (te)
                {
                    break;
                }
            }
            result = (!FisWaiting);
            if (result)
            {
                FisWaiting = false;
            }
            else
                TCPLastError = TcpErr_OutTime;
            return result;
        }

        private Boolean WaitReturnx(int delay)
        {
            Boolean te, result;
            int t1 = 0;
            while (FisWaiting)
            {
                Thread.Sleep(2);
                SetTcpTick();
                t1++;
                te = t1 > (300 + delay);
                if (te)
                {
                    break;
                }
            }
            result = (!FisWaiting);
            if (result)
            {
                FisWaiting = false;
            }
            else
                TCPLastError = TcpErr_OutTime;
            return result;
        }

        #endregion
    }



}
