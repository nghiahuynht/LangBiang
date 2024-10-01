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

using TcpClass;

namespace TcpClass.Controller
{
    // 控制器
    public class TTCPController : TTCPControllerBase
    {
        public TTCPController(ITCPNet Net, IPullTCPCommand PullCmd)
        {
            TCPNet = Net;
            PullTCPCmd = PullCmd;
            Net.OnDataEvent += HandleMessage;
        }

        #region 数据结构处理

        //tcp 接收控制器的数据处理
        public void HandleMessage(byte[] buffRX, int len)
        {
            byte cmd = 0;
            try
            {
                Array.ConstrainedCopy(buffRX, 0, BufferRX, 0, len);
                if (ClassTCPCmdBase.CheckRxDataCS(BufferRX, len, ref cmd))
                {
                    TCPNet.SetTcpTick();
                    switch (cmd)
                    {
                        case 0x56: DoFormatStatusvent(BufferRX); break;

                        case 0x52: DoFormCardStatus(BufferRX); break;
                        case 0x53: DoFormCardevent(BufferRX); break;
                        case 0x54: DoFormAlarmEvent(BufferRX); break;

                        default:
                            if (cmd == ClassTCPCmdBase.LastCmd)
                                TCPNet.ClearWait();
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                string a = e.Source;
            }
        }

        public byte LastError()
        {
            return TCPNet.LastError();
        }
        #region heart data
        //心跳请求
        private void AskHeart(UInt32 indexCmd, byte CmdOK)
        {
            byte[] cmdrec;
            if (PullTCPCmd != null)
            {
                cmdrec = PullTCPCmd.GetNowPullCmd(SerialNo, ref indexCmd, CmdOK);

                if (cmdrec != null)
                    GetPullCommandData(cmdrec, indexCmd);
            }
            else
                cmdrec = new byte[0];

            byte[] Buf = ClassTCPCmd.AckHeart(indexCmd, OEMCode, cmdrec);
            TCPNet.SendAndNOReturn(Buf);
        }

        private void DoFormatStatusvent(byte[] buffer)
        {
            RAcsStatus Event = TCPBufAndStruct.HeartBuf2Struct(buffer);
            Ver = Event.Version;
            SerialNo = Event.SerialNo;
            SystemOption = Event.SystemOption;
            CardNumInPack = Event.CardNumInPack;
            StatusHandler(Event);

            AskHeart(Event.IndexCmd, Event.CmdOK);
        }
        #endregion

        #region   event data
        // 刷卡记录 card 
        private void DoFormCardevent(byte[] buffer)
        {
            byte ReturnIndex = 0;
            RAcsEvent Event = new RAcsEvent();

            Event = TCPBufAndStruct.CardEventBuf2Struct(ref buffer, ref ReturnIndex);
            Event.SerialNo = SerialNo;
            byte relay = Event.Reader;
            Event.Online = true;
            EventHandler(Event);

            AnsHistoryEvent(0x53,  ReturnIndex );//
        }

        // 防潜记录  card  Anti passback
        private void DoFormCardStatus(byte[] buffer)
        {
            byte ReturnIndex = 0;
            RAcsEvent Event = new RAcsEvent();

            Event = TCPBufAndStruct.CardStatusBuf2Struct(ref buffer, ref ReturnIndex);
            Event.SerialNo = SerialNo;
            byte relay = Event.Reader;
            Event.Online = true;
            EventHandler(Event);

            AnsHistoryEvent(0x52, ReturnIndex);
        }

        // 报警记录 alarm 
        private void DoFormAlarmEvent(byte[] buffer)
        {
            byte ReturnIndex = 0;
            RAcsEvent Event = new RAcsEvent();
            Event = TCPBufAndStruct.AlarmEventBuf2Struct(ref buffer, ref ReturnIndex);
            Event.SerialNo = SerialNo;
            byte relay = Event.Reader;

            Event.Online = true;

            EventHandler(Event);
            AnsHistoryEvent(0x54, ReturnIndex);
        }
        #endregion

        #endregion

        public Boolean SendBuffer(string value)
        {
            if (TCPNet.isWorking()) return false;
            if (string.IsNullOrEmpty(value)) return false;
            if (value.Length == 0) return false;

            byte[] Buf = UTF8Encoding.Default.GetBytes(value);
            return TCPNet.SendAndNOReturn(Buf);
        }

        #region 参数类指令
        public Boolean SetControl(byte SystemOption, UInt16 FireTime, UInt16 AlarmTime, string DuressPIN, byte LockEach)
        {
            if (TCPNet.isWorking()) return false;
            byte[] Buf = ClassTCPCmd.SetControl(SystemOption, FireTime, AlarmTime, DuressPIN, LockEach);
            return TCPNet.SendAndReturn(100, Buf);
        }

        public Boolean SetDoor(byte Door, UInt16 OpenTime, byte OutTime, Boolean DoublePath, Boolean ToolongAlarm, byte AlarmMask, UInt16 AlarmTime, byte MCards, byte MCardsInOut)
        {
            if (TCPNet.isWorking()) return false;
            byte[] Buf = ClassTCPCmd.SetDoor(Door, OpenTime, OutTime, DoublePath, ToolongAlarm, AlarmMask, AlarmTime, MCards, MCardsInOut);
            return TCPNet.SendAndReturn(100, Buf);
        }

        public Boolean DelTimeZone(byte Door)
        {
            if (TCPNet.isWorking()) return false;
            byte[] Buf = ClassTCPCmd.DelTimeZone(Door);
            return TCPNet.SendAndReturn(100, Buf);
        }

        public Boolean AddTimeZone(byte Door, byte Index, DateTime frmtime, DateTime totime, byte Week, Boolean PassBack, byte Indetify, DateTime Enddatetime, byte Group)
        {
            if (TCPNet.isWorking()) return false;
            byte[] Buf = ClassTCPCmd.AddTimeZone(Door, Index, frmtime, totime, Week, PassBack, Indetify, Enddatetime, Group);
            return TCPNet.SendAndReturn(100, Buf);
        }

        #endregion

        #region 系统类指令

        public bool SetTime(DateTime datetime)
        {
            if (TCPNet.isWorking()) return false;
            byte[] Buf = ClassTCPCmd.SetTime(datetime);
            return TCPNet.SendAndReturn(100, Buf);
        }

        public Boolean Reset()
        {
            if (TCPNet.isWorking()) return false;
            byte[] Buf = ClassTCPCmd.Reset();
            return TCPNet.SendAndReturn(3000, Buf);
        }

        public Boolean Restart()
        {
            if (TCPNet.isWorking()) return false;
            byte[] Buf = ClassTCPCmd.Restart();
            return TCPNet.SendAndReturn(100, Buf);
        }
        #endregion

        #region 控制类指令
        public Boolean SetPass(byte index, byte Reader, Boolean Pass)
        {
            if (TCPNet.isWorking()) return false;
            byte[] Buf = ClassTCPCmd.SetPass(index, Reader, Pass);
            return TCPNet.SendAndReturn(150, Buf);
        }

        public Boolean OpenDoor(byte index)
        {
            if (TCPNet.isWorking()) return false;
            byte[] Buf = ClassTCPCmd.Opendoor(index);
            return TCPNet.SendAndReturn(50, Buf);
        }

        public Boolean CloseDoor(byte index)
        {
            if (TCPNet.isWorking()) return false;
            byte[] Buf = ClassTCPCmd.Closedoor(index);
            return TCPNet.SendAndReturn(50, Buf);
        }

        public Boolean LockDoor(byte index, Boolean Lock)
        {
            if (TCPNet.isWorking()) return false;
            byte[] Buf = ClassTCPCmd.LockDoor(index, Lock);
            return TCPNet.SendAndReturn(50, Buf);
        }

        public Boolean OpenDoorLong(byte index)
        {
            if (TCPNet.isWorking()) return false;
            byte[] Buf = ClassTCPCmd.OpenDoorLong(index);
            return TCPNet.SendAndReturn(50, Buf);
        }

        public Boolean SetAlarm(Boolean AClose, Boolean ALong)
        {
            if (TCPNet.isWorking()) return false;
            byte[] Buf = ClassTCPCmd.SetAlarm(AClose, ALong);
            return TCPNet.SendAndReturn(50, Buf);
        }

        public Boolean SetFire(Boolean AClose, Boolean ALong)
        {
            if (TCPNet.isWorking()) return false;
            byte[] Buf = ClassTCPCmd.SetFire(AClose, ALong);
            return TCPNet.SendAndReturn(50, Buf);
        }
        #endregion

        #region 485接口指令
        public Boolean SendTo485(byte[] value)
        {
            if (TCPNet.isWorking()) return false;
            byte[] Buf = ClassTCPCmd.SendTo485(value);
            return TCPNet.SendAndNOReturn(Buf);
        }
        #endregion

        #region 应答记录
        private void AnsHistoryEvent(byte Command, byte index)
        {
            byte[] Buf = ClassTCPCmd.AnsHistoryEvent(Command, index);
            TCPNet.SendAndNOReturn(Buf);
        }
        #endregion

        #region 下载卡类指令
        // 不建议使用删除指令，用加卡指令代替
        public Boolean DeleteCard(byte SystemOption, UInt32 Index)
        {
            if (TCPNet.isWorking()) return false;
            byte[] Buf = ClassTCPCmd.DeleteCard(SystemOption, Index);
            return TCPNet.SendAndReturn(300, Buf);
        }

        public Boolean AddCard1Door(byte SystemOption, UInt32 Index, string Name, UInt32 CardNo, string Pin, UInt16 TZ, DateTime EnddTime)
        {
            if (TCPNet.isWorking()) return false;
            byte[] Buf = ClassTCPCmd.AddCard1Door(SystemOption, Index, Name, CardNo, Pin, TZ, 1, EnddTime);
            return TCPNet.SendAndReturn(300, Buf);
        }

        public Boolean AddCard2Door(byte SystemOption, UInt32 Index, string Name, UInt32 CardNo, string Pin, UInt16 TZ1, UInt16 TZ2, DateTime EnddTime)
        {
            if (TCPNet.isWorking()) return false;
            byte[] Buf = ClassTCPCmd.AddCard2Door(SystemOption, Index, Name, CardNo, Pin, TZ1, TZ2, 1, EnddTime);
            return TCPNet.SendAndReturn(300, Buf);
        }

        public Boolean AddCard4Door(byte SystemOption, UInt32 Index, string Name, UInt32 CardNo, string Pin, byte TZ1, byte TZ2, byte TZ3, byte TZ4, DateTime EnddTime)
        {
            if (TCPNet.isWorking()) return false;
            byte[] Buf = ClassTCPCmd.AddCard4Door(SystemOption, Index, Name, CardNo, Pin, TZ1, TZ2, TZ3, TZ4, 1, EnddTime);
            return TCPNet.SendAndReturn(300, Buf);
        }

        UInt16 PackIndex = 0;// 包序号 0..
        byte CardofPack = 0; // 卡在包中的序号 0..CardNumInPack-1
        UInt16 CardsDataLen = 0;
        public Boolean AddCards(byte SystemOption, byte CardNumInPack, Boolean isLastRecord, UInt32 CardIndex, string Name, UInt32 CardNo, string Pin, byte TZ1, byte TZ2, byte TZ3, byte TZ4, DateTime EnddTime)
        {
            Boolean result = false;
            if ((CardNumInPack < 15) || (CardNumInPack > 45)) return false;

            PackIndex = Convert.ToUInt16(Math.Floor(Convert.ToDouble(CardIndex / CardNumInPack)));
            CardofPack = Convert.ToByte(CardIndex % CardNumInPack);

            UInt16 DataLen = ClassTCPCmd.AddCards(SystemOption, ref CardsDataLen, PackIndex, CardofPack, CardIndex, Name, CardNo, Pin, TZ1, TZ2, TZ3, TZ4, EnddTime);

            if (((CardofPack + 1) >= CardNumInPack) || (isLastRecord))
            {
                CardsDataLen = 0;
                byte[] Buf = ClassTCPCmd.AddCardsEndSendCards(DataLen);

                result = TCPNet.SendAndReturn(1800, Buf);
                if (result)
                {
                    result = ClassTCPCmd.AddCardsCheckResult(PackIndex, BufferRX);
                }
                return result;
            }
            return true;
        }

        public Boolean ClearAllCards()
        {
            if (TCPNet.isWorking()) return false;
            byte[] Buf = ClassTCPCmd.ClearAllCards();
            return TCPNet.SendAndReturn(50, Buf);
        }
        #endregion

    }
}
