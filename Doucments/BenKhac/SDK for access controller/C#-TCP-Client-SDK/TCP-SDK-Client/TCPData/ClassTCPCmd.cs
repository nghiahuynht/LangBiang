using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using System.Runtime.InteropServices;
using System.Reflection.Emit;
using System.Security.Cryptography;

namespace TcpClass.Controller
{
    // 控制器的指令封包集合 
    // Get cmmand array 

    #region 数据结构  data struct
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct RDoorPara // 控制器门参数
    {
        public byte OpenTimeL;
        public byte OutTime;         //开门超时
        public byte DoublePath;
        public byte ToolongAlarm;
        public byte OpenTimeH;

        public byte AlarmMask;
        public UInt16 AlarmTime;
        public byte MCards;
        public byte MCardsInOut;
    }
    #endregion

    public class ClassTCPCmd : ClassTCPCmdBase
    {
        private static byte[] BufferTX = new byte[2048];
        private static byte[] BufferCardsTX = new byte[2048];

        public static byte[] AckHeart(UInt32 indexCmd, UInt16 OEMCode, byte[] rec)
        {
            UInt16 DataLen = 0;
            SetBufCommand(0x56, ref DataLen, BufferTX);
            PutBuf(Convert.ToByte((OEMCode >> 8) & 0xFF), ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(OEMCode & 0xFF), ref DataLen, BufferTX);

            PutBuf(Convert.ToByte(0), ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(0), ref DataLen, BufferTX);

            PutBuf(Convert.ToByte(indexCmd & 0xFF), ref DataLen, BufferTX);
            PutBuf(Convert.ToByte((indexCmd >> 8) & 0xFF), ref DataLen, BufferTX);
            PutBuf(Convert.ToByte((indexCmd >> 16) & 0xFF), ref DataLen, BufferTX);
            PutBuf(Convert.ToByte((indexCmd >> 24) & 0xFF), ref DataLen, BufferTX);

            if (rec != null)
            {
                PutBuf(rec, ref DataLen, BufferTX);
            }

            BuildCS(ref DataLen, BufferTX);
            byte[] Buffer = new byte[DataLen];
            Array.Copy(BufferTX, Buffer, DataLen);
            return Buffer;
        }

        #region 卡片 Card
        public static byte[] ClearAllCards()
        {
            UInt16 DataLen = 0;
            SetBufCommand(0x17, ref DataLen, BufferTX);
            BuildCS(ref DataLen, BufferTX);
            byte[] Buffer = new byte[DataLen];
            Array.Copy(BufferTX, Buffer, DataLen);
            return Buffer;
        }

        public static byte[] DelCard(UInt16 Index)
        {
            UInt16 DataLen = 0;
            SetBufCommand(0x16, ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(Index & 0xff), ref DataLen, BufferTX);
            PutBuf(Convert.ToByte((Index >> 8) & 0xFF), ref DataLen, BufferTX);

            BuildCS(ref DataLen, BufferTX);
            byte[] Buffer = new byte[DataLen];
            Array.Copy(BufferTX, Buffer, DataLen);
            return Buffer;
        }

        //for Anti passback
        public static byte[] SetCardStatus(UInt16 Index, byte status)
        {
            UInt16 DataLen = 0;
            SetBufCommand(0x66, ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(Index & 0xff), ref DataLen, BufferTX);
            PutBuf(Convert.ToByte((Index >> 8) & 0xFF), ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(status), ref DataLen, BufferTX);

            BuildCS(ref DataLen, BufferTX);
            byte[] Buffer = new byte[DataLen];
            Array.Copy(BufferTX, Buffer, DataLen);
            return Buffer;
        }

        public static byte[] DeleteCard(byte SystemOption, UInt32 Index)
        {
            UInt16 DataLen = 0;
            Boolean isCardorPIN, isEndDate, isShowName; 

            SetBufCommand(0x16, ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(Index & 0xff), ref DataLen, BufferTX);
            PutBuf(Convert.ToByte((Index >> 8) & 0xff), ref DataLen, BufferTX);   

            BuildCS(ref DataLen, BufferTX);
            byte[] Buffer = new byte[DataLen];
            Array.Copy(BufferTX, Buffer, DataLen);
            return Buffer; 
        }

        public static byte[] AddCard1Door(byte SystemOption, UInt32 Index, string name, UInt32 CardNo, string pin, UInt16 TZ, byte Status, DateTime enddatetime)
        {
            return AddCard(SystemOption, Index, name, CardNo, pin, Convert.ToByte(TZ & 0xff), Convert.ToByte((TZ >> 8) & 0xFF), 0, 0, Status, enddatetime);
        }

        public static byte[] AddCard2Door(byte SystemOption, UInt32 Index, string name, UInt32 CardNo, string pin, UInt16 TZ1, UInt16 TZ2, byte Status, DateTime enddatetime)
        {
            return AddCard(SystemOption, Index, name, CardNo, pin, Convert.ToByte(TZ1 & 0xff), Convert.ToByte((TZ1 >> 8) & 0xFF), Convert.ToByte(TZ2 & 0xff), Convert.ToByte(TZ2 >> 8), Status, enddatetime);
        }

        public static byte[] AddCard4Door(byte SystemOption, UInt32 Index, string name, UInt32 CardNo, string pin, byte TZ1, byte TZ2, byte TZ3, byte TZ4, byte Status, DateTime enddatetime)
        {
            return AddCard(SystemOption, Index, name, CardNo, pin, TZ1, TZ2, TZ3, TZ4, Status, enddatetime);
        }

        private static byte[] AddCard(byte SystemOption, UInt32 Index, string name, UInt32 CardNo, string pin, byte TZ1, byte TZ2, byte TZ3, byte TZ4, byte Status, DateTime enddatetime)
        {
            UInt16 DataLen = 0;
            Boolean isCardorPIN, isEndDate, isShowName;

            isCardorPIN = (SystemOption & 0x30) > 0;
            isEndDate = (SystemOption & 0x01) == 0x01;
            isShowName = (SystemOption & 0x08) == 0x08;
            Boolean OEM = (SystemOption & 0x02) == 0x02;

            SetBufCommand(0x62, ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(Index & 0xff), ref DataLen, BufferTX);
            PutBuf(Convert.ToByte((Index >> 8) & 0xff), ref DataLen, BufferTX);

            PutBufCard(CardNo, ref DataLen, BufferTX);

            if (isCardorPIN)
            {
                PutBufPin4(pin, ref DataLen, BufferTX);
            }
            else
                PutBufPin2(pin, ref DataLen, BufferTX);


            PutBuf((TZ1), ref DataLen, BufferTX);
            PutBuf((TZ2), ref DataLen, BufferTX);
            PutBuf((TZ3), ref DataLen, BufferTX);
            PutBuf((TZ4), ref DataLen, BufferTX);

            if (isEndDate)
            {
                PutBufDate(enddatetime, ref DataLen, BufferTX);
                PutBuf(Convert.ToByte(enddatetime.Hour), ref DataLen, BufferTX);
                PutBuf(Convert.ToByte(enddatetime.Minute), ref DataLen, BufferTX);
            }
            else
            {
                PutBuf((0), ref DataLen, BufferTX);
                PutBuf((0), ref DataLen, BufferTX);
                PutBuf((0), ref DataLen, BufferTX);
                PutBuf((0), ref DataLen, BufferTX);
                PutBuf((Status), ref DataLen, BufferTX);
            }

            if (isShowName)
                PutBufString(name, 8, ref DataLen, BufferTX);

            BuildCS(ref DataLen, BufferTX);
            byte[] Buffer = new byte[DataLen];
            Array.Copy(BufferTX, Buffer, DataLen);
            return Buffer;
        }

        // Addcards not support pull command model
        public static UInt16 AddCards(byte SystemOption, ref UInt16 DataLen, UInt32 PackIndex, byte CardofPack, UInt32 CardIndex, string Name, UInt32 CardNo, string pin, byte TZ1, byte TZ2, byte TZ3, byte TZ4, DateTime enddatetime)
        {
            BufferCardsTX[Loc_Command] = 0x88;
            BufferCardsTX[Loc_Data + 0] = Convert.ToByte(((PackIndex + 1) & 0xFF)); //
            BufferCardsTX[Loc_Data + 1] = Convert.ToByte((((PackIndex + 1) >> 8) & 0xFF));
            BufferCardsTX[Loc_Data + 2] = Convert.ToByte(CardofPack + 1); //

            if (CardofPack == 0)
            {
                SetBufCommand(0x88, ref DataLen, BufferCardsTX);
                DataLen = Loc_Data + 3;
                PutBuf(Convert.ToByte(CardIndex & 0xFF), ref DataLen, BufferCardsTX);
                PutBuf(Convert.ToByte((CardIndex >> 8) & 0xFF), ref DataLen, BufferCardsTX);
            }
            SendEmpTcpOne(ref DataLen, SystemOption, Name, CardNo, pin, TZ1, TZ2, TZ3, TZ4, enddatetime);
            return DataLen;
        }

        private static void SendEmpTcpOne(ref UInt16 DataLen, byte SystemOption, string name, UInt32 CardNo, string pin, byte TZ1, byte TZ2, byte TZ3, byte TZ4, DateTime enddatetime)
        {
            Boolean isCardorPIN, isEndDate, isShowName;

            isCardorPIN = (SystemOption & 0x30) > 0;
            isEndDate = (SystemOption & 0x01) == 0x01;
            isShowName = (SystemOption & 0x08) == 0x08;

            PutBufCard(CardNo, ref DataLen, BufferCardsTX);

            if (isCardorPIN)
            {
                PutBufPin4(pin, ref DataLen, BufferCardsTX);
            }
            else
                PutBufPin2(pin, ref DataLen, BufferCardsTX);

            PutBuf((TZ1), ref DataLen, BufferCardsTX);
            PutBuf((TZ2), ref DataLen, BufferCardsTX);
            PutBuf((TZ3), ref DataLen, BufferCardsTX);
            PutBuf((TZ4), ref DataLen, BufferCardsTX);

            if (isEndDate)
            {
                PutBufDate(enddatetime, ref DataLen, BufferCardsTX);
                PutBuf(Convert.ToByte(enddatetime.Hour), ref DataLen, BufferCardsTX);
                PutBuf(Convert.ToByte(enddatetime.Minute), ref DataLen, BufferCardsTX);
            }
            if (isShowName)
                PutBufString(name, 8, ref DataLen, BufferCardsTX);
        }

        public static byte[] AddCardsEndSendCards(UInt16 DataLen)
        {
            BuildCS(ref DataLen, BufferCardsTX);
            byte[] Buffer = new byte[DataLen];
            Array.Copy(BufferCardsTX, Buffer, DataLen);
            return Buffer;
        }

        public static Boolean AddCardsCheckResult(UInt16 PackIndex, byte[] BufferRX)
        {
            if (BufferRX[Loc_Len + 1] > 1)
            {
                return BufferRX[Loc_Data + 0] * 256 + BufferRX[Loc_Data + 1] == (PackIndex + 1);
            }
            return false;
        }

        #endregion

        #region 系统类指令   system
        public static byte[] Restart()
        {
            UInt16 DataLen = 0;
            SetBufCommand(0x05, ref DataLen, BufferTX);
            BuildCS(ref DataLen, BufferTX);
            byte[] Buffer = new byte[DataLen];
            Array.Copy(BufferTX, Buffer, DataLen);
            return Buffer;
        }

        public static byte[] Reset()
        {
            UInt16 DataLen = 0;
            SetBufCommand(0x04, ref DataLen, BufferTX);
            BuildCS(ref DataLen, BufferTX);
            byte[] Buffer = new byte[DataLen];
            Array.Copy(BufferTX, Buffer, DataLen);
            return Buffer;
        }

        public static byte[] SetTime(DateTime datetime)
        {
            UInt16 DataLen = 0;
            DateTime dt = datetime;
            SetBufCommand(0x07, ref DataLen, BufferTX);

            PutBuf(Convert.ToByte(dt.Second), ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(dt.Minute), ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(dt.Hour), ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(dt.DayOfWeek + 1), ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(dt.Day), ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(dt.Month), ref DataLen, BufferTX);

            if (dt.Year >= 2000)
            {
                PutBuf(Convert.ToByte((dt.Year - 2000) & 0xff), ref DataLen, BufferTX);
            }
            else
            {
                PutBuf(Convert.ToByte(dt.Year & 0xff), ref DataLen, BufferTX);
            }

            BuildCS(ref DataLen, BufferTX);
            byte[] Buffer = new byte[DataLen];
            Array.Copy(BufferTX, Buffer, DataLen);
            return Buffer;
        }

        #endregion

        #region 控制类指令 control

        public static byte[] Opendoor(byte index)
        {
            UInt16 DataLen = 0;
            SetBufCommand(0x2C, ref DataLen, BufferTX);
            SetBufDoorAddr(Convert.ToByte(index + 1), BufferTX);

            BuildCS(ref DataLen, BufferTX);
            byte[] Buffer = new byte[DataLen];
            Array.Copy(BufferTX, Buffer, DataLen);
            return Buffer;
        }

        public static byte[] Closedoor(byte index)
        {
            UInt16 DataLen = 0;
            SetBufCommand(0x2e, ref DataLen, BufferTX);
            SetBufDoorAddr(Convert.ToByte(index + 1), BufferTX);
            BuildCS(ref DataLen, BufferTX);
            byte[] Buffer = new byte[DataLen];
            Array.Copy(BufferTX, Buffer, DataLen);
            return Buffer;
        }

        public static byte[] OpenDoorLong(byte index)
        {
            UInt16 DataLen = 0;
            SetBufCommand(0x2d, ref DataLen, BufferTX);
            SetBufDoorAddr(Convert.ToByte(index + 1), BufferTX);
            BuildCS(ref DataLen, BufferTX);
            byte[] Buffer = new byte[DataLen];
            Array.Copy(BufferTX, Buffer, DataLen);
            return Buffer;
        }

        public static byte[] SetPass(byte index, byte Reader, Boolean Pass)
        {
            UInt16 DataLen = 0;
            SetBufCommand(0x5A, ref DataLen, BufferTX);
            SetBufDoorAddr(Convert.ToByte(index + 1), BufferTX);
            PutBuf(Convert.ToByte(0), ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(Reader), ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(0), ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(!Pass), ref DataLen, BufferTX);
            BuildCS(ref DataLen, BufferTX);
            byte[] Buffer = new byte[DataLen];
            Array.Copy(BufferTX, Buffer, DataLen);
            return Buffer;
        }

        public static byte[] LockDoor(byte index, Boolean Lock)
        {
            UInt16 DataLen = 0;
            SetBufCommand(0x2f, ref DataLen, BufferTX);
            SetBufDoorAddr(Convert.ToByte(index + 1), BufferTX);
            PutBuf(Convert.ToByte(Lock), ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(Lock), ref DataLen, BufferTX);
            BuildCS(ref DataLen, BufferTX);
            byte[] Buffer = new byte[DataLen];
            Array.Copy(BufferTX, Buffer, DataLen);
            return Buffer;
        }

        public static byte[] SetAlarm(Boolean AClose, Boolean ALong)
        {
            UInt16 DataLen = 0;
            SetBufCommand(0x18, ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(AClose), ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(ALong), ref DataLen, BufferTX);
            BuildCS(ref DataLen, BufferTX);
            byte[] Buffer = new byte[DataLen];
            Array.Copy(BufferTX, Buffer, DataLen);
            return Buffer;
        }

        public static byte[] SetFire(Boolean AClose, Boolean ALong)
        {
            UInt16 DataLen = 0;
            SetBufCommand(0x19, ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(AClose), ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(ALong), ref DataLen, BufferTX);
            BuildCS(ref DataLen, BufferTX);
            byte[] Buffer = new byte[DataLen];
            Array.Copy(BufferTX, Buffer, DataLen);
            return Buffer;
        }

        #endregion

        #region 开放时间 Timezone
        public static byte[] DelTimeZone(byte Door)
        {
            UInt16 DataLen = 0;
            SetBufCommand(0x0f, ref DataLen, BufferTX);
            SetBufDoorAddr(Convert.ToByte(Door + 1), BufferTX);
            BuildCS(ref DataLen, BufferTX);
            byte[] Buffer = new byte[DataLen];
            Array.Copy(BufferTX, Buffer, DataLen);
            return Buffer;
        }

        public static byte[] AddTimeZone(byte Door, byte Index, DateTime frmtime, DateTime totime, byte Week, Boolean PassBack, byte Indetify, DateTime Enddatetime, byte Group)
        {
            UInt16 DataLen = 0;
            byte vIndetify = Indetify;
            SetBufCommand(0x0d, ref DataLen, BufferTX);
            SetBufDoorAddr(Convert.ToByte(Door + 1), BufferTX);

            PutBuf(Convert.ToByte(Index), ref DataLen, BufferTX);
            PutBufHourMinute(frmtime, ref DataLen, BufferTX);
            PutBufHourMinute(totime, ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(Week), ref DataLen, BufferTX);

            if (PassBack)
                vIndetify |= 0x80;
            PutBuf(Convert.ToByte(vIndetify), ref DataLen, BufferTX);
            PutBufDate(Enddatetime, ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(Group), ref DataLen, BufferTX);

            BuildCS(ref DataLen, BufferTX);
            byte[] Buffer = new byte[DataLen];
            Array.Copy(BufferTX, Buffer, DataLen);
            return Buffer;
        }
        #endregion

        #region 串口485转发指令 Send com and 485
        public static byte[] SendTo485(byte[] value)
        {
            UInt16 DataLen = 0;
            SetBufCommand(0xB1, ref DataLen, BufferTX);
            PutBuf(value, ref DataLen, BufferTX);
            BuildCS(ref DataLen, BufferTX);
            byte[] Buffer = new byte[DataLen];
            Array.Copy(BufferTX, Buffer, DataLen);
            return Buffer;
        }
        #endregion

        #region 参数类指令  controller

        public static byte[] SetControl(byte SystemOption, UInt16 FireTime, UInt16 AlarmTime, string DuressPIN, byte LockEach)
        {
            UInt16 DataLen = 0;
            Boolean isCardorPIN;
            isCardorPIN = (SystemOption & 0x30) > 0;

            SetBufCommand(0x63, ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(LockEach), ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(FireTime & 0xFF), ref DataLen, BufferTX);
            PutBuf(Convert.ToByte((FireTime >> 8) & 0xFF), ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(AlarmTime & 0xFF), ref DataLen, BufferTX);
            PutBuf(Convert.ToByte((AlarmTime >> 8) & 0xFF), ref DataLen, BufferTX);


            if (string.IsNullOrEmpty(DuressPIN)) DuressPIN = "0";

            if (isCardorPIN)
            {
                PutBufPin4(DuressPIN, ref DataLen, BufferTX);
            }
            else
                PutBufPin2(DuressPIN, ref DataLen, BufferTX);

            BuildCS(ref DataLen, BufferTX);
            byte[] Buffer = new byte[DataLen];
            Array.Copy(BufferTX, Buffer, DataLen);
            return Buffer;
        }

        public static byte[] SetDoor(byte Door, UInt16 OpenTime, byte OutTime, Boolean DoublePath, Boolean ToolongAlarm, byte AlarmMask, UInt16 AlarmTime, byte MCards, byte MCardsInOut)
        {
            RDoorPara Data;

            Data.OpenTimeL = Convert.ToByte(OpenTime & 0xff);
            Data.OutTime = OutTime;
            Data.DoublePath = Convert.ToByte(DoublePath);
            Data.ToolongAlarm = Convert.ToByte(ToolongAlarm);
            Data.OpenTimeH = Convert.ToByte((OpenTime >> 8) & 0xFF);
            Data.AlarmMask = AlarmMask;
            Data.AlarmTime = AlarmTime;
            Data.MCards = MCards;
            Data.MCardsInOut = MCardsInOut;

            byte[] buf = TCPBufAndStruct.StructToBytes(Data, Marshal.SizeOf(Data));

            UInt16 DataLen = 0;
            SetBufCommand(0x61, ref DataLen, BufferTX);
            SetBufDoorAddr(Convert.ToByte(Door + 1), BufferTX);

            PutBuf(buf, ref DataLen, BufferTX);
            BuildCS(ref DataLen, BufferTX);
            byte[] Buffer = new byte[DataLen];
            Array.Copy(BufferTX, Buffer, DataLen);
            return Buffer;
        }

        public static byte[] DelHoliday()
        {
            UInt16 DataLen = 0;
            SetBufCommand(0x0c, ref DataLen, BufferTX);
            BuildCS(ref DataLen, BufferTX);
            byte[] Buffer = new byte[DataLen];
            Array.Copy(BufferTX, Buffer, DataLen);
            return Buffer;
        }

        public static byte[] AddHoliday(byte Index, DateTime frmdate, DateTime todate)
        {
            UInt16 DataLen = 0;
            SetBufCommand(0x09, ref DataLen, BufferTX);
            PutBuf(Convert.ToByte(Index), ref DataLen, BufferTX);
            PutBufDate(frmdate, ref DataLen, BufferTX);
            PutBufDate(todate, ref DataLen, BufferTX);
            BuildCS(ref DataLen, BufferTX);
            byte[] Buffer = new byte[DataLen];
            Array.Copy(BufferTX, Buffer, DataLen);
            return Buffer;
        }
        #endregion

        #region 事件处理返回   Event ack
        public static byte[] AnsHistoryEvent(byte Command, byte index)
        {
            UInt16 DataLen = 0;
            SetBufCommand(Command, ref DataLen, BufferTX);
            PutBuf(index, ref DataLen, BufferTX);
            BuildCS(ref DataLen, BufferTX);
            byte[] Buffer = new byte[DataLen];
            Array.Copy(BufferTX, Buffer, DataLen);
            return Buffer;
        }
        #endregion

    }
}
