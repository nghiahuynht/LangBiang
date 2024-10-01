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
    // tcp 通讯协议的封包 基本类
    public class ClassTCPCmdBase
    {
        #region 常量
        public const byte Loc_Begin = 0;
        public const byte Loc_Temp = 1;
        public const byte Loc_Command = 2;
        public const byte Loc_Address = 3;
        public const byte Loc_DoorAddr = 4;
        public const byte Loc_Len = 5;
        public const byte Loc_Data = 7;
        #endregion

        static public byte LastCmd = 0;

        #region 基本函数
        public static string GetStringValue(object value)
        {
            return (value == null || value.ToString() == "") ? "" : value.ToString();
        }

        public static byte GetByteValue(object value)
        {
            try
            {
                return (value == null || value.ToString() == "") ? (byte)0 : Convert.ToByte(value.ToString());
            }
            catch { return 0; }
        }

        public static void SetBufCommand(byte command, ref UInt16 DataLen, byte[] Buffer)
        {
            LastCmd = command;
            Buffer[Loc_Begin] = 0x02;
            DataLen = Loc_Data;
            Buffer[Loc_Command] = command;
            Buffer[Loc_DoorAddr] = 1;
            Buffer[Loc_Len] = 0;
            Buffer[Loc_Len + 1] = 0;
            Buffer[Loc_Address] = 0xff;
        }

        public static void SetBufDoorAddr(byte ADoorAddr, byte[] Buffer)
        {
            Buffer[Loc_DoorAddr] = ADoorAddr;
        }

        public static void SetBufAddr(byte Addr, byte[] Buffer)
        {
            Buffer[Loc_Address] = Addr;
        }

        public static void PutBuf(byte AData, ref UInt16 DataLen, byte[] Buffer)
        {
            Buffer[DataLen] = AData;
            DataLen++;
        }

        public static void PutBuf0(byte Len, ref UInt16 DataLen, byte[] Buffer)
        {
            int i;
            for (i = 0; i < Len; i++)
                PutBuf((byte)0, ref DataLen, Buffer);
        }

        public static void PutBuf(byte[] data, ref UInt16 DataLen, byte[] Buffer)
        {
            for (int i = 0; i < data.Length; i++)
                PutBuf((byte)data[i], ref DataLen, Buffer);
        }

        public static void PutBufHourMinute(DateTime AData, ref UInt16 DataLen, byte[] Buffer)
        {
            PutBuf(Convert.ToByte(AData.Hour), ref DataLen, Buffer);
            PutBuf(Convert.ToByte(AData.Minute), ref DataLen, Buffer);
        }

        public static void PutBufDate(DateTime AData, ref UInt16 DataLen, byte[] Buffer)
        {
            if (AData.Year >= 2000)
                PutBuf(Convert.ToByte((AData.Year - 2000) & 0xff), ref DataLen, Buffer);
            else
                PutBuf(Convert.ToByte(AData.Year & 0xff), ref DataLen, Buffer);
            PutBuf(Convert.ToByte(AData.Month), ref DataLen, Buffer);
            PutBuf(Convert.ToByte(AData.Day), ref DataLen, Buffer);
        }

        public static void PutBufCard(string AData, ref UInt16 DataLen, byte[] Buffer)
        {
            UInt32 card = 0;
            try
            {
                card = Convert.ToUInt32(AData);
            }
            catch { }

            PutBuf(Convert.ToByte((card) & 0xff), ref DataLen, Buffer);
            PutBuf(Convert.ToByte((card >> 8) & 0xff), ref DataLen, Buffer);
            PutBuf(Convert.ToByte((card >> 16) & 0xff), ref DataLen, Buffer);
            PutBuf(Convert.ToByte((card >> 24) & 0xff), ref DataLen, Buffer);
        }

        public static void PutBufCard(UInt32 card, ref UInt16 DataLen, byte[] Buffer)
        {
            PutBuf(Convert.ToByte((card) & 0xff), ref DataLen, Buffer);
            PutBuf(Convert.ToByte((card >> 8) & 0xff), ref DataLen, Buffer);
            PutBuf(Convert.ToByte((card >> 16) & 0xff), ref DataLen, Buffer);
            PutBuf(Convert.ToByte((card >> 24) & 0xff), ref DataLen, Buffer);
        }

        public static void SetBufString(string Str, ref byte[] Buf)
        {
            int i, len;

            if (string.IsNullOrEmpty(Str)) Str = "";
            byte[] Value = UTF8Encoding.Default.GetBytes(Str);

            int Maxlen = Buf.Length;

            try
            {
                len = Value.Length;
                if (len > Maxlen) len = Maxlen;

                for (i = 0; i < Maxlen; i++)
                {
                    Buf[i] = 0;
                }

                for (i = 0; i < len; i++)
                    Buf[i] = Convert.ToByte(Value[i]);
            }
            catch
            {
            }
        }

        public static UInt32 GetBufPin4(string AData)
        {
            int i, len;
            byte[] p = new byte[8];
            byte[] v = new byte[4];

            if (string.IsNullOrEmpty(AData)) AData = "";
            byte[] ap = UTF8Encoding.UTF8.GetBytes(AData);

            len = ap.Length;
            for (i = 0; i < 8; i++) p[i] = 0xFF;

            if (len > 8) len = 8;
            for (i = 0; i < len; i++)
                p[i] = Convert.ToByte(ap[i] - 0x30);

            for (i = 0; i < 4; i++)
                v[i] = Convert.ToByte(((p[i * 2] << 4) & 0xF0) + (p[i * 2 + 1] & 0x0F));

            UInt32 value = (UInt32)v[0] + (UInt32)(v[1] << 8) + (UInt32)(v[2] << 16) + (UInt32)(v[3] << 24);
            return value;
        }

        public static void PutBufPin2(string AData, ref UInt16 DataLen, byte[] Buffer)
        {
            UInt32 vPin = Convert.ToUInt32(AData);
            PutBuf(Convert.ToByte((vPin >> 8) & 0xff), ref DataLen, Buffer);
            PutBuf(Convert.ToByte(vPin & 0xff), ref DataLen, Buffer);
        }

        public static void PutBufPin4(string AData, ref UInt16 DataLen, byte[] Buffer)
        {
            UInt32 v = GetBufPin4(AData);
            PutBuf(Convert.ToByte(v & 0xff), ref DataLen, Buffer);
            PutBuf(Convert.ToByte((v >> 8) & 0xff), ref DataLen, Buffer);
            PutBuf(Convert.ToByte((v >> 16) & 0xff), ref DataLen, Buffer);
            PutBuf(Convert.ToByte((v >> 24) & 0xff), ref DataLen, Buffer);
        }

        public static void PutBufString(string AData, int Maxlen, ref UInt16 DataLen, byte[] Buffer)
        {
            int i, len;
            if (string.IsNullOrEmpty(AData)) AData = "";
            byte[] Value = UTF8Encoding.Default.GetBytes(AData);
            byte[] p = new byte[Maxlen];
            try
            {
                len = Value.Length;
                if (len > Maxlen) len = Maxlen;
                for (i = 0; i < len; i++)
                    p[i] = Convert.ToByte(Value[i]);

                for (i = 0; i < Maxlen; i++)
                    PutBuf(Convert.ToByte(p[i]), ref DataLen, Buffer);
            }
            catch
            {
            }
        }

        public static void PutBufString(int Maxlen, ref byte[] Buffer)
        {
            int i, len;
            byte[] Value = Buffer;
            byte[] p = new byte[Maxlen];
            byte[] newBuffer = new byte[Maxlen];

            int intDataLen = 0;

            try
            {
                len = Value.Length;
                if (len > Maxlen) len = Maxlen;
                for (i = 0; i < len; i++)
                    p[i] = Convert.ToByte(Value[i]);

                for (i = 0; i < Maxlen; i++)
                {
                    newBuffer[intDataLen] = Convert.ToByte(p[i]);
                    intDataLen++;
                }
            }
            catch { }
            Buffer = newBuffer;
        }

        public static void PutBufStringMin(string AData, byte MaxLen, ref UInt16 DataLen, byte[] Buffer)
        {
            int i, len;
            byte[] aname = UTF8Encoding.Default.GetBytes(AData);

            byte[] p = new byte[MaxLen];
            try
            {
                len = aname.Length;
                if (len > MaxLen) len = MaxLen;

                for (i = 0; i < MaxLen; i++) p[i] = 0;

                for (i = 0; i < len; i++)
                    p[i] = Convert.ToByte(aname[i]);

                for (i = 0; i < len; i++)
                    PutBuf(Convert.ToByte(p[i]), ref  DataLen, Buffer);   // 178 
            }
            catch
            {
            }
        }

        public static byte GetStringLen(string AData, byte MaxLen)
        {
            int len;
            byte[] aname = UTF8Encoding.Default.GetBytes(AData);
            len = aname.Length;
            if (len > MaxLen) len = MaxLen;
            return Convert.ToByte(len);
        }

        public static DateTime GetDatetime(byte Second, byte Minute, byte Hour, byte Day, byte Month, int Year)
        {
            try
            {
                return new DateTime(Year, Month, Day, Hour, Minute, Second);
            }
            catch { return new DateTime(); }
        }

        public static void BuildCS(ref UInt16 DataLen, byte[] Buffer)
        {
            int i, datalen;
            byte OutBufferCS;

            datalen = DataLen - Loc_Data;
            Buffer[Loc_Len] = Convert.ToByte(datalen & 0xFF);
            Buffer[Loc_Len + 1] = Convert.ToByte((datalen >> 8) & 0xFF);

            OutBufferCS = 0;
            for (i = 0; i < DataLen; i++)
                OutBufferCS = Convert.ToByte(OutBufferCS ^ Buffer[i]);

            Buffer[DataLen] = OutBufferCS;
            Buffer[DataLen + 1] = 0x03;
            DataLen += (UInt16)2;
        }
        #endregion

        #region 接收数据校验
        private static Boolean CheckCs(byte[] buff, int loc)
        {
            int i;
            if (buff[loc] != 0x02) return false;
            if (buff[loc + 3] == 0x03)
                buff[loc + 3] = Convert.ToByte(0x03 + loc);

            int Bufferlen = buff[Loc_Len + 1 + loc] + buff[Loc_Len + 0 + loc] * 256 + Loc_Data + 2;
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

        public static Boolean CheckRxDataCS(byte[] buffRX, int len, ref byte Cmd)
        {
            if (len < 4) return false;
            bool re = CheckCs(buffRX, 0);
            Cmd = buffRX[Loc_Command];
            return re;
        }
        #endregion

    }
}