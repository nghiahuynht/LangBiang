package StandTcp.StandTcpProtocol;

import struct.JavaStruct;

import java.nio.ByteOrder;
import java.time.*;
import java.time.LocalDateTime;

//控制器使用的公共结构和函数,  结构类对外使用
public class TCPCmdStruct {
    // 数据结构  data struct
    // 控制器门参数
    public static class DoorPara //
    {
        public short OpenTime = 5;
        public byte OutTime = 5;         //开门超时
        public boolean DoublePath = true;
        public boolean ToolongAlarm = true;
        public byte AlarmMask = 0;
        public short AlarmTime = 10;
        public byte MCards;
        public byte MCardsInOut;
    }

    // 控制器的开放时间
    public static class TimeZone //
    {
        public byte Index = 0;
        public byte FrmHour = 0;
        public byte FrmMinute = 0;
        public byte ToHour = 23;
        public byte ToMinute = 59;
        public byte Week = (byte) 255;
        public byte Indetify = (byte) 0;
        public boolean APB = false;  // 防潜返
        public boolean Holiday = true;
        public LocalDate EndDate = LocalDate.now().plusYears(10);
        public byte Group = 0;
    }

    // 单门加1个人的数据
    public static class CardData1Door {
        public byte FunctionOption;
        public int Index;
        public String Name, Pin;
        public int CardNo;
        public short TZ;
        public byte Status;
        public LocalDateTime EndTime;
    }

    // 2门加1个人的数据
    public static class CardData2Door {
        public byte FunctionOption;
        public int Index;
        public String Name, Pin;
        public int CardNo;
        public short TZ1, TZ2;
        public byte Status;
        public LocalDateTime EndTime;
    }

    // 4门加1个人的数据
    public static class CardData4Door {
        public byte FunctionOption;
        public int Index;
        public String Name, Pin;
        public int CardNo;
        public byte TZ1, TZ2, TZ3, TZ4, Status;
        public LocalDateTime EndTime;
    }

    // 内部使用卡数据信息
    public static class CardData {
        public byte FunctionOption;
        public int Index;
        public String Name, Pin;
        public int CardNo;
        public byte TZ1, TZ2, TZ3, TZ4, Status;
        public LocalDateTime EndTime;
    }

    // 控制器心跳信息
    public static class RHeartStatus {
        public LocalDateTime Datetime;
        public String SerialNo;
        public byte DoorStatus;
        public short Input;
        public Boolean Online;
        public byte TModel;
        public byte SystemOption;
        public byte CardNumInPack;

        public String Version;
        public String OEMCode;
        public int IndexCmd;
        public byte CmdOK;
    }

    //刷卡记录
    public static class RCardEvent {
        public LocalDateTime Datetime;
        public String CardNo;
        public byte Reader;
        public byte Door;
        public byte EventType;
        public int ReturnIndex;
        public String SerialNo;
    }

    // 报警记录
    public static class RAlarmEvent {
        public LocalDateTime Datetime;
        public byte Door;
        public byte EventType;
        public int ReturnIndex;
    }

    // 卡状态记录
    public static class RAcsCardStatus {
        public byte EventType;
        public short CardIndex;
        public byte AntiPassBackValue;
        public int ReturnIndex;
    }

    // 处理接收到的二进制数据数组，转换为对应的数据结构
    //  基础函数
    public static byte[] StructToBytes(Object structObj) {
        byte[] bytes;
        try {
            bytes = JavaStruct.pack(structObj, ByteOrder.LITTLE_ENDIAN);
            return bytes;
        } catch (Exception e) {
            return new byte[0];
        }
    }

    protected static Object ByteToStruct(Object obj, byte[] bytes) {
        try {
            JavaStruct.unpack(obj, bytes, ByteOrder.LITTLE_ENDIAN);
            return obj;
        } catch (Exception e) {
            return null;
        }
    }
}

