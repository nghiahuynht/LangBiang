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
    //拉指令管理类 Pull commmand save to buffer
    public class TTCPPullCommand : TTCPPullCommandBase
    {
        public TTCPPullCommand()
            : base()
        {

        }

        #region 控制类指令 Control commmand
        public void OpenDoor(byte index)
        {
            byte[] Buf = ClassTCPCmd.Opendoor(index);
            Hashtable rec = GetDataSet(0, 0x2c, Buf);
            AllCmdList.Add(rec);
        }

        public void CloseDoor(byte index)
        {
            byte[] Buf = ClassTCPCmd.Closedoor(index);
            Hashtable rec = GetDataSet(0, 0x2e, Buf);
            AllCmdList.Add(rec);
        }

        public void OpenDoorLong(byte index)
        {
            byte[] Buf = ClassTCPCmd.OpenDoorLong(index);
            Hashtable rec = GetDataSet(0, 0x2D, Buf);
            AllCmdList.Add(rec);
        }

        public void LockDoor(byte index, bool isLock)
        {
            byte[] Buf = ClassTCPCmd.LockDoor(index, isLock);
            Hashtable rec = GetDataSet(0, 0x2f, Buf);
            AllCmdList.Add(rec);
        }

        public void SetAlarm(Boolean AClose, Boolean ALong)
        {
            byte[] Buf = ClassTCPCmd.SetAlarm(AClose, ALong);
            Hashtable rec = GetDataSet(0, 0x18, Buf);
            AllCmdList.Add(rec);
        }

        public void SetFire(Boolean AClose, Boolean ALong)
        {
            byte[] Buf = ClassTCPCmd.SetFire(AClose, ALong);
            Hashtable rec = GetDataSet(0, 0x19, Buf);
            AllCmdList.Add(rec);
        }

        public void SetPass(byte index, byte Reader, Boolean Pass)
        {
            byte[] Buf = ClassTCPCmd.SetPass(index, Reader, Pass);
            Hashtable rec = GetDataSet(0, 0x5a, Buf);
            AllCmdList.Add(rec);
        }

        #endregion

        #region 485接口指令
        public void SendTo485(byte[] value)
        {
            byte[] Buf = ClassTCPCmd.SendTo485(value);
            Hashtable rec = GetDataSet(0, 0xB1, Buf);
            AllCmdList.Add(rec);
        }
        #endregion

        #region 参数类指令 parameter
        public void SetControl(byte SystemOption, UInt16 FireTime, UInt16 AlarmTime, string DuressPIN, byte LockEach)
        {
            byte[] Buf = ClassTCPCmd.SetControl(SystemOption, FireTime, AlarmTime, DuressPIN, LockEach);
            Hashtable rec = GetDataSet(0, 0x63, Buf);
            AllCmdList.Add(rec);
        }

        public void SetDoor(byte Door, UInt16 OpenTime, byte OutTime, Boolean DoublePath, Boolean ToolongAlarm, byte AlarmMask, UInt16 AlarmTime, byte MCards, byte MCardsInOut)
        {
            byte[] Buf = ClassTCPCmd.SetDoor(Door, OpenTime, OutTime, DoublePath, ToolongAlarm, AlarmMask, AlarmTime, MCards, MCardsInOut);
            Hashtable rec = GetDataSet(0, 0x61, Buf);
            AllCmdList.Add(rec);
        }

        public void DelTimeZone(byte Door)
        {
            byte[] Buf = ClassTCPCmd.DelTimeZone(Door);
            Hashtable rec = GetDataSet(0, 0x0f, Buf);
            AllCmdList.Add(rec);
        }

        public void AddTimeZone(byte Door, byte Index, DateTime frmtime, DateTime totime, byte Week, Boolean PassBack, byte Indetify, DateTime Enddatetime, byte Group)
        {
            byte[] Buf = ClassTCPCmd.AddTimeZone(Door, Index, frmtime, totime, Week, PassBack, Indetify, Enddatetime, Group);
            Hashtable rec = GetDataSet(0, 0x0d, Buf);
            AllCmdList.Add(rec);
        }

        #endregion

        #region 系统类指令 system command
        public void SetTime(DateTime datetime)
        {
            byte[] Buf = ClassTCPCmd.SetTime(datetime);
            Hashtable rec = GetDataSet(0, 0x07, Buf);
            AllCmdList.Add(rec);
        }

        public void Reset()
        {
            byte[] Buf = ClassTCPCmd.Reset();
            Hashtable rec = GetDataSet(0, 0x04, Buf);
            AllCmdList.Add(rec);
        }

        public void Restart()
        {
            byte[] Buf = ClassTCPCmd.Restart();
            Hashtable rec = GetDataSet(0, 0x05, Buf);
            AllCmdList.Add(rec);
        }
        #endregion

        #region 下载卡类指令  Card command   
        public void AddCard1Door(byte SystemOption, UInt32 Index, string Name, UInt32 CardNo, string Pin, UInt16 TZ, DateTime EnddTime)
        {
            byte[] Buf = ClassTCPCmd.AddCard1Door(SystemOption, Index, Name, CardNo, Pin, TZ, 1, EnddTime);             
            Hashtable rec = GetDataSet(0, 0x62, Buf);
            AllCmdList.Add(rec);
        }

        public void AddCard2Door(byte SystemOption, UInt32 Index, string Name, UInt32 CardNo, string Pin, UInt16 TZ1, UInt16 TZ2, DateTime EnddTime)
        {
            byte[] Buf = ClassTCPCmd.AddCard2Door(SystemOption, Index, Name, CardNo, Pin, TZ1, TZ2, 1, EnddTime);             
            Hashtable rec = GetDataSet(0, 0x62, Buf);
            AllCmdList.Add(rec);
        }

        public void AddCard4Door(byte SystemOption, UInt32 Index, string Name, UInt32 CardNo, string Pin, byte TZ1, byte TZ2, byte TZ3, byte TZ4, DateTime EnddTime)
        {
            byte[] Buf = ClassTCPCmd.AddCard4Door(SystemOption, Index, Name, CardNo, Pin, TZ1, TZ2, TZ3, TZ4, 1, EnddTime);           
            Hashtable rec = GetDataSet(0, 0x62, Buf);
            AllCmdList.Add(rec);
        }

        public void SetCardAPB(UInt16 Index, byte Value)
        {
            byte[] Buf = ClassTCPCmd.SetCardStatus(Index, Value);
            Hashtable rec = GetDataSet(0, 0x66, Buf);
            AllCmdList.Add(rec);
        }

        public void ClearAllCards()
        {
            byte[] Buf = ClassTCPCmd.ClearAllCards();
            Hashtable rec = GetDataSet(0, 0x17, Buf);
            AllCmdList.Add(rec);
        }
        #endregion

    }
}
