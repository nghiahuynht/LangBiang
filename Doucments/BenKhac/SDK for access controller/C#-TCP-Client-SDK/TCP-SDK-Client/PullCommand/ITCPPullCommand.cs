using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TcpClass.Controller
{
    // 用于拉取指令数据
    public interface IPullTCPCommand
    {
        byte[] GetNowPullCmd(string SerialNo, ref UInt32 IndexCmd, byte CmdOK);
    }
}
