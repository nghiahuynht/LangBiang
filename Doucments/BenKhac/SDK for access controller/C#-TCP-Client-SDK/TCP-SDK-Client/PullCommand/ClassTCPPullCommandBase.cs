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

using System.Collections;
using System.Reflection;

using System.IO;

namespace TcpClass.Controller
{
    //拉指令管理基础类
    public class TTCPPullCommandBase : IPullTCPCommand
    {
        public static ArrayList AllCmdList;
        public static UInt16 SelfIndexCmd;

        public TTCPPullCommandBase()
        {
            AllCmdList = new ArrayList();
        }

        public int GetPullCmdNum()
        {
            return AllCmdList.Count;
        }

        public byte[] GetNowPullCmd(string SerialNo, ref UInt32 IndexCmd, byte CmdOK)
        {
            if (CmdOK > 0)
                if (IndexCmd > 0)
                    if (SelfIndexCmd == IndexCmd)
                        if (AllCmdList.Count > 0)
                        {
                            AllCmdList.RemoveAt(0);
                        }

            if (AllCmdList.Count > 0)
            {
                Random r = new Random();
                int s = r.Next(1, 65535);
                SelfIndexCmd = (UInt16)s;
                IndexCmd = SelfIndexCmd;

                Hashtable re = (Hashtable)AllCmdList[0];

                string cmd = GetStringValue(re["CmdValue"]);

                return strToToHexByte(cmd);
            }
            else IndexCmd = 0;

            return null;
        }

        #region 基本函数 base function
        private static string GetStringValue(object value)
        {
            return (value == null || value.ToString() == "") ? "" : value.ToString();
        }

        private static string bytesToHexString(byte[] src)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (src == null || src.Length <= 0)
            {
                return null;
            }
            for (int i = 0; i < src.Length; i++)
            {
                int v = src[i] & 0xFF;

                String hv = v.ToString("X2");
                if (hv.Length < 2)
                {
                    stringBuilder.Append(0);
                }
                stringBuilder.Append(hv);
            }
            return stringBuilder.ToString();
        }

        public static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        public static Hashtable GetDataSet(byte Priority, byte cmd, byte[] value)
        {
            Hashtable rec = new Hashtable();
            rec["Priority"] = Priority.ToString();
            rec["Cmd"] = cmd.ToString();
            rec["CmdValue"] = bytesToHexString(value);//.ToString(); 
            return rec;
        }
        #endregion 
    }
}
