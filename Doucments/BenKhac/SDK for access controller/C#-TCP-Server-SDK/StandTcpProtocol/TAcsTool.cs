using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TcpStandard_Server.StandTcpProtocol
{
    public static class TAcsTool
    {
        public static void Print(byte[] buf, String CmdName)
        {
         //   String str = Bytes2Hex(buf);
         //   System.Console.WriteLine(DateTime.Now.ToString() + " " + CmdName + " = " + str);
        }

        public static void Print(String Cmd)
        {
           // System.Console.WriteLine(Cmd);
        }

        public static byte Bool2Byte(Boolean val)
        {
            return (val == false) ? (byte)0 : (byte)1;
        }

        private static char[] hexCode = "0123456789ABCDEF".ToCharArray();

        public static String Bytes2Hex(byte[] data)
        {
            if (data == null) return "";

            StringBuilder r = new StringBuilder(data.Length * 2);
            foreach (byte b in data)
            {
                r.Append(hexCode[(b >> 4) & 0xF]);
                r.Append(hexCode[(b & 0xF)]);
            }
            return r.ToString();
        }

        public static String Bytes2Hex(byte data)
        {
            String str;
            str = (hexCode[(data >> 4) & 0xF]).ToString();
            str += Char.ToString(hexCode[(data & 0xF)]);
            return str;
        }

        public static String Short2Hex(UInt16 data)
        {
            String str;
            str = Char.ToString(hexCode[(data >> 12) & 0xF]);
            str += Char.ToString(hexCode[(data >> 8) & 0xF]);
            str += Char.ToString(hexCode[(data >> 4) & 0xF]);
            str += Char.ToString(hexCode[(data & 0xF)]);
            return str;
        }

        public static String Int2Hex(int data)
        {
            String str;
            str = Char.ToString(hexCode[(data >> 28) & 0xF]);
            str += Char.ToString(hexCode[(data >> 24) & 0xF]);
            str += Char.ToString(hexCode[(data >> 20) & 0xF]);
            str += Char.ToString(hexCode[(data >> 16) & 0xF]);
            str += Char.ToString(hexCode[(data >> 12) & 0xF]);
            str += Char.ToString(hexCode[(data >> 8) & 0xF]);
            str += Char.ToString(hexCode[(data >> 4) & 0xF]);
            str += Char.ToString(hexCode[(data & 0xF)]);
            return str;
        }

        public static int bytesToInt(byte[] data)
        {
            int x = ((data[0] & 0xff) << 24) |
                    ((data[1] & 0xff) << 16) |
                    ((data[2] & 0xff) << 8) |
                    (data[3] & 0xff);
            return x;
        }

        public static byte[] bswap32(int x)
        {
            return new byte[]{
                (byte) (((x << 24) & 0xff000000) >> 24),
                (byte) (((x << 8) & 0x00ff0000) >> 16),
                (byte) (((x >> 8) & 0x0000ff00) >> 8),
                (byte) (((x >> 24) & 0x000000ff))
        };
        }

        public static int reverse(int x)
        {
            byte[] a = bswap32(x);
            return bytesToInt(a);
        }

        public static String GetNowTime()
        {
            return DateTime.Now.ToString("hh:mm:ss");
        }

        public static DateTime GetDatetime(byte Second, byte Minute, byte Hour, byte Day, byte Month, int Year)
        {
            try
            {
                return new DateTime(Year, Month, Day, Hour, Minute, Second);
            }
            catch 
            {
                return DateTime.Now;
            }
        }
        // 处理接收到的二进制数据数组，转换为对应的数据结构
        //  基础函数
        public static object ByteToStruct(byte[] bytes, Type type)
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
    }
}
