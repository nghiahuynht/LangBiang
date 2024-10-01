using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;
using System.IO; 

using System.Runtime.InteropServices;
using System.Reflection.Emit;
using System.Security.Cryptography;

namespace TcpClass.Controller
{
    #region 心跳 heart data struct
    public struct RAcsStatus
    {
        public DateTime Datetime;
        public string SerialNo;
        public byte DoorStatus;
        public UInt16 Input;
        public Boolean Online;
        public byte TModel;
        public byte SystemOption;
        public byte CardNumInPack;

        public string Version;
        public string OEMCode;
        public UInt32 IndexCmd;
        public byte CmdOK;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct RTCPStatus
    {
        public byte stx;
        public byte temp;
        public byte cmd;
        public byte addr;
        public byte door;
        public UInt16 len;
        public byte N1;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] Time;
        public byte DoorStatus;

        public byte CardNumInPack;
        public byte DirPass;
        public byte SystemOption;
        public byte ControlType;
        public byte RelayOut;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] N3;
        public byte Output;
        public byte Ver;
        public UInt16 OEMCODE;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] Serial;
        public UInt16 Input;

        public UInt32 IndexCmd;
        public byte CmdOK;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct RTCPStatusAck
    {
        public byte stx;
        public byte temp;
        public byte cmd;
        public byte addr;
        public byte door;
        public UInt16 len;
        public UInt16 OEM;
        public UInt16 Nc;

        public UInt32 IndexCmd;  //附带指令 本次指令序列号 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public byte[] PCCmd;
    }   // 心跳应答
    #endregion

    #region 报警  alarm event struct
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct RTCPAlarmEvent
    {
        public byte stx;
        public byte temp;
        public byte cmd;
        public byte addr;
        public byte doorAdr;
        public UInt16 len;

        public byte second;
        public byte minute;
        public byte hour;
        public byte day;
        public byte month;
        public byte year;

        public byte Event;
        public byte Door;
        public byte hasEvent;
        public byte index;
    }
    #endregion

    #region 刷卡记录 card event struct
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct RTCPCardEvent
    {
        public byte stx;
        public byte temp;
        public byte cmd;
        public byte addr;
        public byte doorAdr;
        public UInt16 len;

        public UInt32 Card;

        public byte second;
        public byte minute;
        public byte hour;
        public byte day;
        public byte month;
        public byte year;

        public byte Event;
        public byte Door;
        public byte hasEvent;
        public byte index;
    }
    #endregion

    #region 防潜返记录 card  Anti passback
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct RTCPCardStatus
    {
        public byte stx;
        public byte temp;
        public byte cmd;
        public byte addr;
        public byte doorAdr;
        public UInt16 len;

        public UInt16 CardIndex;
        public byte AntiPassBackValue;
        public byte index;
        public byte hasEvent;        
    }
    #endregion
    public struct RAcsEvent
    {
        public byte EType;
        public DateTime Datetime;
        public string SerialNo;
        public byte DoorStatus;

        public Boolean Online;
        
        public byte Reader;
        public byte Door;
        public byte EventType;
        public UInt16 CardIndex;
        public byte AntiPassBackValue;
        public string Value;
    }

    // 处理接收到的二进制数据数组，转换为对应的数据结构
    // tcp data  to struct
    public static class TCPBufAndStruct
    {
        #region 基础函数
        private static object ByteToStruct(byte[] bytes, Type type)
        {
            int size = Marshal.SizeOf(type);
            if (size > bytes.Length)
            {
                return null;
            }
            //分配结构体内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将byte数组拷贝到分配好的内存空间
            Marshal.Copy(bytes, 0, structPtr, size);
            //将内存空间转换为目标结构体
            object obj = Marshal.PtrToStructure(structPtr, type);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            return obj;
        }

        public static byte[] StructToBytes(object structObj, int size)
        {
            byte[] bytes = new byte[size];
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将结构体拷到分配好的内存空间
            Marshal.StructureToPtr(structObj, structPtr, false);
            //从内存空间拷贝到byte 数组
            Marshal.Copy(structPtr, bytes, 0, size);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            return bytes;
        }

        private static DateTime GetDatetime(byte Second, byte Minute, byte Hour, byte Day, byte Month, int Year)
        {
            try
            {
                return new DateTime(Year, Month, Day, Hour, Minute, Second);
            }
            catch { return new DateTime(); }
        }

        #endregion

        #region 心跳  heart status
        public static RAcsStatus HeartBuf2Struct(byte[] buffer)
        {
            byte Second, Minute, Hour, Day, Month;
            int Year;
            RAcsStatus Event = new RAcsStatus();
            RTCPStatus Status = new RTCPStatus();

            Status = (RTCPStatus)ByteToStruct(buffer, typeof(RTCPStatus));
            Event.SerialNo = Encoding.ASCII.GetString(Status.Serial);

            Event.CardNumInPack = Status.CardNumInPack;
            Event.DoorStatus = Status.DoorStatus;
            Event.Version = Status.Ver.ToString();
            Event.SystemOption = Status.SystemOption;

            Event.OEMCode = Status.OEMCODE.ToString();
            Second = Status.Time[5];
            Minute = Status.Time[4];
            Hour = Status.Time[3];
            Day = Status.Time[2];
            Month = Status.Time[1];
            Year = Status.Time[0] + 2000;
            Event.Datetime = GetDatetime(Second, Minute, Hour, Day, Month, Year);
            Event.Version = Status.Ver.ToString();
            Event.Input = Status.Input;
            Event.Online = true;
            Event.IndexCmd = Status.IndexCmd;
            Event.CmdOK = Status.CmdOK;

            return Event;
        }
        #endregion

        #region 刷卡记录 card event
        public static RAcsEvent CardEventBuf2Struct(ref byte[] buffer, ref byte ReturnIndex)
        {
            RAcsEvent Event = new RAcsEvent();
            RTCPCardEvent CardEvent = (RTCPCardEvent)ByteToStruct(buffer, typeof(RTCPCardEvent));

            Event.Value = Convert.ToString(CardEvent.Card);

            Event.EventType = Convert.ToByte(CardEvent.Event & 0x7F);
            Event.Reader = Convert.ToByte((CardEvent.Event & 0x80) >> 7);
            Event.Door = CardEvent.Door;
            ReturnIndex = CardEvent.index;

            Event.Online = true;
            Event.Datetime = GetDatetime(CardEvent.second, CardEvent.minute, CardEvent.hour, CardEvent.day, CardEvent.month, CardEvent.year + 2000);

            Event.EType = 1;
            return Event;
        }
        #endregion


        #region 防潜返记录  Anti passback
        public static RAcsEvent CardStatusBuf2Struct(ref byte[] buffer, ref byte ReturnIndex)
        {
            RAcsEvent Event = new RAcsEvent();
            RTCPCardStatus CardStatus = (RTCPCardStatus)ByteToStruct(buffer, typeof(RTCPCardStatus));

            Event.CardIndex = CardStatus.CardIndex;
            Event.AntiPassBackValue = CardStatus.AntiPassBackValue;

            ReturnIndex = CardStatus.index;
            Event.Online = true;
            Event.Datetime = DateTime.Now;
            Event.EType = 3;
            return Event;
        }
        #endregion

        #region 报警记录 alarm event
        public static RAcsEvent AlarmEventBuf2Struct(ref byte[] buffer, ref byte ReturnIndex)
        {
            RAcsEvent Event = new RAcsEvent();
            RTCPAlarmEvent AlarmEvent = (RTCPAlarmEvent)ByteToStruct(buffer, typeof(RTCPAlarmEvent));

            Event.EventType = Convert.ToByte(AlarmEvent.Event & 0x7F);
            Event.Reader = Convert.ToByte((AlarmEvent.Door >> 4) & 0x0f);
            Event.Door = Convert.ToByte(AlarmEvent.Door & 0x0F);
            ReturnIndex = AlarmEvent.index;
            Event.Online = true;

            Event.Datetime = GetDatetime(AlarmEvent.second, AlarmEvent.minute, AlarmEvent.hour, AlarmEvent.day, AlarmEvent.month, AlarmEvent.year + 2000);

            Event.EType = 2;
            return Event;
        }
        #endregion

    }
}