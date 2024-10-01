using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TcpClass.Controller
{ 
    public delegate void EventSocketConnected(bool link);
    public delegate void TOnDataHandler(byte[] buffRX, int len);
    public delegate void TOnRxTxDataHandler(byte[] buffRX, int len,bool isSend);   //声明委托
  
    // 用于控制器TCP网络传输的接口
    public interface ITCPNet
    { 
        event EventSocketConnected OnSocketConnected;
        event TOnDataHandler OnDataEvent;
        event TOnRxTxDataHandler OnRxTxDataEvent;        //声明事件  

        Boolean SendAndNOReturn(byte[] buffTX);
        Boolean SendAndReturn(int delay, byte[] buffTX);
        Boolean isWorking();
        void ClearWait();
        void SetTcpTick();
        byte LastError();
        bool OpenIP(string ip, int port);
        void SetAES(string AESPIN, Boolean AES182);
        bool CloseTcpip();
        Boolean IsConnectSuccess();
    }
}
