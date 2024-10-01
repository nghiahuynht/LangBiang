using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TcpStandard_Server.StandTcpProtocol
{
    public class StandTCPCmdBase
    { 
        #region 通讯数据结构 内部使用 data struct 
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct RCmdHead //
        {
            public byte stx;
            public byte temp;
            public byte cmd;
            public byte addr;
            public byte door;
            public UInt16 Len;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct RCmdEnd //
        {
            public byte cs;
            public byte etx;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct RCmd0Byte //
        {
            public RCmdHead Head;
        }

        //02fe2c0000010000d103
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct RCmd1Byte //
        {
            public RCmdHead Head;
            public byte Value;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct RCmdMByte //
        {
            public RCmdHead Head;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
            public byte[] Value;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct RCmdSetSystime //
        {
            public RCmdHead Head;
            public byte sec;
            public byte min;
            public byte hour;
            public byte Week;
            public byte day;
            public byte mon;
            public byte year; //  - 2000 
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        protected struct RBitDoorPara // 控制器门参数
        {
            public RCmdHead Head;
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

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        protected struct RBitControlPara // 控制器参数
        {
            public RCmdHead Head;
            public byte LockEach;
            public UInt16 FireTime;
            public UInt16 AlarmTime;
            public UInt32 DuressPIN;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        protected struct RBitHoliday
        {
            public RCmdHead Head;
            public byte Index;
            public byte FrmYear;
            public byte FrmMonth;
            public byte FrmDay;

            public byte EndYear;
            public byte EndMonth;
            public byte EndDay;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        protected struct RBitTimeZone //
        {
            public RCmdHead Head;
            public byte Index;
            public byte FrmHour;
            public byte FrmMinute;
            public byte ToHour;
            public byte ToMinute;
            public byte Week;
            public byte Indetify;
            public byte EndYear;
            public byte EndMonth;
            public byte EndDay;
            public byte Group;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        protected struct RBitDoorPass //
        {
            public RCmdHead Head;
            public byte N;
            public byte Reader;
            public byte N2;
            public byte NPass;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        protected struct RTCPHeartStatus
        {
            public RCmdHead Head;
            public byte N1;

            public byte year;
            public byte month;
            public byte day;
            public byte hour;
            public byte minute;
            public byte second;

            public byte DoorStatus;
            public byte CardNumInPack;
            public byte DirPass;
            public byte SystemOption;
            public byte ControlType;
            public byte RelayOut;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] N4;
            public byte Output;
            public byte Ver;
            public UInt16 OEMCODE;  //28 
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Serial;  // 34 
            public UInt16 Input;
            public int IndexCmd;
            public byte CmdOK;  //31 41   14 + 27    27+6
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        protected struct RBitAckHeart //
        {
            public RCmdHead Head;
            public byte OEMCodeH;
            public byte OEMCodeL;
            public byte N1;
            public byte N2;
            public UInt32 IndexCmd;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        protected struct RBitCardStatus
        {
            public RCmdHead Head;
            public UInt16 Index;
            public byte Status;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct RAddCmdCards //
        {
            public RCmdHead Head;
            public UInt16 PackIndex;
            public byte CardofPack;
            public   UInt16 Index;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        protected struct RTCPAlarmEvent
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Head;

            public byte second;
            public byte minute;
            public byte hour;
            public byte day;
            public byte month;
            public byte year;

            public byte Event;
            public byte Door;
            public byte hasEvent;
            public byte index;  // 17
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        protected struct RTCPCardEvent
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Head;
            public int Card;

            public byte second;
            public byte minute;
            public byte hour;
            public byte day;
            public byte month;
            public byte year;

            public byte Event;
            public byte Door;
            public byte hasEvent;
            public byte index; // 14 + 7  = 21
        }

        //防潜返记录 card  Anti passback
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        protected struct RTCPCardStatus
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Head;
            public UInt16 CardIndex;
            public byte AntiPassBackValue;
            public byte index;
            public byte hasEvent;//12
        }
        #endregion

        protected static byte Loc_Begin = 0;
        protected static byte Loc_Temp = 1;
        protected static byte Loc_Command = 2;
        protected static byte Loc_Address = 3;
        protected static byte Loc_DoorAddr = 4;
        protected static byte Loc_Len = 5;
        protected static byte Loc_Data = 7;

        #region  基本函数
        protected static UInt16 SetBufCommand(byte command, byte door, byte addr, byte[] Buffer)
        {
            Buffer[Loc_Begin] = 0x02;
            Buffer[Loc_Command] = command;
            Buffer[Loc_DoorAddr] = door;
            Buffer[Loc_Len] = 0;
            Buffer[Loc_Len + 1] = 0;
            Buffer[Loc_Address] = (byte)addr;
            return Loc_Data;
        }

        protected static RCmdHead SetHeadCommand(byte cmd, byte door, RCmdHead Head)
        {
            Random r1 = new Random();
            Head.stx = 0x02;
            Head.temp = Convert.ToByte(r1.Next(255));
            Head.door = door;
            Head.cmd = cmd;
            Head.Len = 0;
            return Head;
        } 

        protected static UInt16 PutBuf(byte AData, UInt16 DataLen, byte[] Buffer)
        {
            Buffer[DataLen] = AData;
            DataLen++;
            return DataLen;
        }

        protected static UInt16 PutBufDate(DateTime AData, UInt16 DataLen, byte[] Buffer)
        {
            if (AData.Year >= 2000)
                DataLen = PutBuf((byte)((AData.Year - 2000) & 0xff), DataLen, Buffer);
            else
                DataLen = PutBuf((byte)(AData.Year & 0xff), DataLen, Buffer);
            DataLen = PutBuf((byte)(AData.Month), DataLen, Buffer);
            DataLen = PutBuf((byte)(AData.Day), DataLen, Buffer);
            return DataLen;
        } 

        protected static UInt16 PutBufCard(UInt32 card, UInt16 DataLen, byte[] Buffer)
        {
            DataLen = PutBuf((byte)((card) & 0xff), DataLen, Buffer);
            DataLen = PutBuf((byte)((card >> 8) & 0xff), DataLen, Buffer);
            DataLen = PutBuf((byte)((card >> 16) & 0xff), DataLen, Buffer);
            DataLen = PutBuf((byte)((card >> 24) & 0xff), DataLen, Buffer);
            return DataLen;
        }

        public static UInt32 GetBufPin4(String AData)
        {
            int i, len;
            byte[] p = new byte[8];
            byte[] v = new byte[4];

            if (String.IsNullOrEmpty(AData)) AData = "";
            byte[] ap = UTF8Encoding.UTF8.GetBytes(AData);

            len = ap.Length;
            for (i = 0; i < 8; i++) p[i] = (byte)0xFF;

            if (len > 8) len = 8;
            for (i = 0; i < len; i++)
                p[i] = (byte)(ap[i] - 0x30);

            for (i = 0; i < 4; i++)
                v[i] = (byte)(((p[i * 2] << 4) & 0xF0) + (p[i * 2 + 1] & 0x0F));

            UInt32 value = (UInt32)v[0] + (UInt32)(v[1] << 8) + (UInt32)(v[2] << 16) + (UInt32)(v[3] << 24);
            return value;
        }

        protected static UInt16 PutBufPin2(String AData, UInt16 DataLen, byte[] Buffer)
        {
            if (String.IsNullOrEmpty(AData)) AData = "0";
            UInt32 vPin = Convert.ToUInt32(AData);

            DataLen = PutBuf((byte)((vPin >> 8) & 0xff), DataLen, Buffer);
            DataLen = PutBuf((byte)(vPin & 0xff), DataLen, Buffer);
            return DataLen;
        }

        protected static UInt16 PutBufPin4(String AData, UInt16 DataLen, byte[] Buffer)
        {
            UInt32 v = GetBufPin4(AData);
            DataLen = PutBuf((byte)(v & 0xff), DataLen, Buffer);
            DataLen = PutBuf((byte)((v >> 8) & 0xff), DataLen, Buffer);
            DataLen = PutBuf((byte)((v >> 16) & 0xff), DataLen, Buffer);
            DataLen = PutBuf((byte)((v >> 24) & 0xff), DataLen, Buffer);
            return DataLen;
        }

        protected static UInt16 PutBufNameString(String AData, UInt16 Maxlen, UInt16 DataLen, byte[] Buffer)
        {
            int len;
            if (String.IsNullOrEmpty(AData)) AData = "";
            byte[] Value;

            Value = UTF8Encoding.Default.GetBytes(AData);

            len = Value.Length;
            if (len > Maxlen) len = Maxlen;

            Array.Copy(Value, 0, Buffer, DataLen, len);

            DataLen += Maxlen;
            return DataLen;
        }
        #endregion

        #region 数据校验
        protected static byte BuildCS(UInt16 DataLen, byte[] Buffer)
        {
            int i;
            byte OutBufferCS = 0;
            for (i = 0; i < DataLen; i++)
                OutBufferCS = (byte)(OutBufferCS ^ Buffer[i]);
            return OutBufferCS;
        }

        protected static UInt16 BuildCSAdd(UInt16 DataLen, byte[] Buffer)
        {
            int i, datalen;
            byte OutBufferCS = 0;
            datalen = DataLen - Loc_Data;
            Buffer[Loc_Len] = (byte)(datalen & 0xFF);
            Buffer[Loc_Len + 1] = (byte)((datalen >> 8) & 0xFF);

            for (i = 0; i < DataLen; i++)
                OutBufferCS = (byte)(OutBufferCS ^ Buffer[i]);

            Buffer[DataLen] = OutBufferCS;
            Buffer[DataLen + 1] = 0x03;
            DataLen += (UInt16)2;
            return DataLen;
        }

        protected static byte BuildCS(byte[] Buffer)
        {
            int i;
            byte cs = 0;

            if (Buffer == null) return 0;
            if (Buffer.Length == 0) return 0;
            for (i = 0; i < Buffer.Length; i++)
                cs = (byte)(cs ^ Buffer[i]);
            return cs;
        }

        private static Boolean CheckCs(byte[] buff, int loc)
        {
            int i;
            if (buff[loc] != 0x02) return false;
            if (buff[loc + 3] == 0x03)
                buff[loc + 3] = (byte)(0x03 + loc);

            int Bufferlen = (buff[Loc_Len + 1 + loc] & 0xff) + (buff[Loc_Len + 0 + loc] & 0xff) * 256 + Loc_Data + 2;
            if (Bufferlen > buff.Length) return false;
            if (buff[Bufferlen - 1 + loc] != 0x03) return false;

            Boolean result = false;
            byte cs = 0;
            int len = Bufferlen - 2;
            for (i = 0; i < len; i++)
            {
                cs ^= buff[i + loc];
            }
            result = (cs == buff[Bufferlen + loc - 2]);
            return result;
        }

        public static Boolean CheckRxDataCS(byte[] buffRX)
        {
            if (buffRX.Length < 4) return false;
            Boolean re = CheckCs(buffRX, 0);
            return re;
        }

        public static Boolean CheckRxCmdAck(byte[] buffRX, byte LastCmd, Boolean CheckAck)
        {
            if (buffRX.Length < 9) return false;
            if (CheckAck)
                return (LastCmd == buffRX[2] && buffRX[7] == 0x06);
            else
                return (LastCmd == buffRX[2]);
        }
        #endregion

        #region 转换 卡信息
        protected static CardData MakeCardData(CardData1Door data)
        {
            CardData value = new CardData();
            value.FunctionOption = data.FunctionOption;
            value.Index = data.Index;
            value.Name = data.Name;
            value.Pin = data.Pin;
            value.CardNo = data.CardNo;
            value.TZ1 = (byte)(data.TZ & 0x0ff);
            value.TZ2 = (byte)((data.TZ >> 8) & 0x0ff);
            value.Status = data.Status;
            value.EndTime = data.EndTime;
            return value;
        }

        protected static CardData MakeCardData(CardData2Door data)
        {
            CardData value = new CardData();
            value.FunctionOption = data.FunctionOption;
            value.Index = data.Index;
            value.Name = data.Name;
            value.Pin = data.Pin;
            value.CardNo = data.CardNo;
            value.TZ1 = (byte)(data.TZ1 & 0x0ff);
            value.TZ2 = (byte)((data.TZ1 >> 8) & 0x0ff);
            value.TZ3 = (byte)(data.TZ2 & 0x0ff);
            value.TZ4 = (byte)((data.TZ2 >> 8) & 0x0ff);
            value.Status = data.Status;
            value.EndTime = data.EndTime;
            return value;
        }

        protected static CardData MakeCardData(CardData4Door data)
        {
            CardData value = new CardData();
            value.FunctionOption = data.FunctionOption;
            value.Index = data.Index;
            value.Name = data.Name;
            value.Pin = data.Pin;
            value.CardNo = data.CardNo;
            value.TZ1 = data.TZ1;
            value.TZ2 = data.TZ2;
            value.TZ3 = data.TZ3;
            value.TZ4 = data.TZ4;
            value.Status = data.Status;
            value.EndTime = data.EndTime;
            return value;
        }
        #endregion
    }
}
