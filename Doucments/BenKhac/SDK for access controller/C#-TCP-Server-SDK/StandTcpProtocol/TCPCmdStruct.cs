using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TcpStandard_Server.StandTcpProtocol
{
    public struct DoorPara //
    {
        public UInt16 OpenTime;
        public byte OutTime;         //开门超时
        public Boolean DoublePath;
        public Boolean ToolongAlarm;
        public byte AlarmMask;
        public UInt16 AlarmTime;
        public byte MCards;
        public byte MCardsInOut;
    }

    // 控制器的开放时间
    public struct RTimeZone //
    {
        public byte Index;
        public DateTime FrmTime;
        public DateTime ToTime;
        public byte Week;
        public byte Indetify;
        public Boolean APB;  // 防潜返
        public Boolean Holiday;
        public DateTime EndDate;
        public byte Group;
    }

    // 单门加1个人的数据
    public struct CardData1Door
    {
        public UInt16 Index;
        public String Name, Pin;
        public UInt32 CardNo;
        public UInt16 TZ;
        public byte Status;
        public DateTime EndTime;
        public byte FunctionOption;// 函数中间自动赋值，不需要修改
    }

    // 2门加1个人的数据
    public struct CardData2Door
    {
        public UInt16 Index;
        public String Name, Pin;
        public UInt32 CardNo;
        public UInt16 TZ1, TZ2;
        public byte Status;
        public DateTime EndTime;
        public byte FunctionOption;// 函数中间自动赋值，不需要修改
    }

    // 4门加1个人的数据
    public struct CardData4Door
    {
        public UInt16 Index;
        public String Name, Pin;
        public UInt32 CardNo;
        public byte TZ1, TZ2, TZ3, TZ4, Status;
        public DateTime EndTime;
        public byte FunctionOption;// 函数中间自动赋值，不需要修改
    }

    // 卡数据信息
    public struct CardData  // 批量加卡，和内部使用
    {
        public UInt16 Index;
        public String Name, Pin;
        public UInt32 CardNo;
        public byte TZ1, TZ2, TZ3, TZ4, Status;
        public DateTime EndTime;
        public byte FunctionOption;// 函数中间自动赋值，不需要修改
    }

    // 控制器心跳信息
    public struct RHeartStatus
    {
        public DateTime Datetime;
        public String SerialNo;
        public byte DoorStatus;
        public UInt16 Input;
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
    public struct RCardEvent
    {
        public DateTime Datetime;
        public String CardNo;
        public byte Reader;
        public byte Door;
        public byte EventType;
        public int ReturnIndex;
    }

    // 报警记录
    public struct RAlarmEvent
    {
        public DateTime Datetime;
        public byte Door;
        public byte EventType;
        public int ReturnIndex;
    }

    // 卡状态记录
    public struct RAcsCardStatus
    {
        public byte EventType;
        public UInt16 CardIndex;
        public byte AntiPassBackValue;
        public int ReturnIndex;
    }
     
}
