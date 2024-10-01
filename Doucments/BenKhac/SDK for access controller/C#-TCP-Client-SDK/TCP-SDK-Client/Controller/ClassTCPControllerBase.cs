using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Security.Cryptography; 

using TcpClass; 

namespace TcpClass.Controller
{  
    // 控制器基类
    public class TTCPControllerBase
    {
        public ITCPNet TCPNet;
        public IPullTCPCommand PullTCPCmd;
        #region 变量

        public string SerialNo;
        public string Ver;
        public byte SystemOption;
        public byte CardNumInPack;
        
        public UInt16 OEMCode;
        protected byte[] BufferRX = new byte[512];
        #endregion
        

        #region 事件
        public delegate void TOnEventHandler(RAcsEvent Event, TTCPControllerBase Object);   //声明委托 
        public event TOnEventHandler OnEventHandler;        //声明事件

        public delegate void TOnStatusHandler(RAcsStatus Status, TTCPControllerBase Object);   //声明委托        
        public event TOnStatusHandler OnStatusHandler;        //声明事件

        public delegate void TOnGetPullCommandData(byte[] CmdData,UInt32 Index);   //         
        public event TOnGetPullCommandData OnGetPullCommandData;        // 
        #endregion

        #region TCP Net   连接
        public bool OpenIP(string ip, int port,UInt16 oemcode)
        {
            OEMCode = oemcode;
            return TCPNet.OpenIP(ip, port);
        }

        public bool CloseTcpip()
        {
            return TCPNet.CloseTcpip();
        }
        #endregion

        #region 事件
        public void EventHandler(RAcsEvent Event)
        {
            if (OnEventHandler != null)
                OnEventHandler(Event,this );
        }
         
        public void StatusHandler(RAcsStatus Event)
        {
            if (OnStatusHandler != null)
                OnStatusHandler(Event,this);
        }

        public void GetPullCommandData(byte[] CmdData, UInt32 Index )
        {
            if (OnGetPullCommandData != null)
                OnGetPullCommandData(CmdData, Index);
        }
        #endregion
    }

    
}
