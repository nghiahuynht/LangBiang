using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TcpStandard_Server.StandTcpProtocol
{
    public class StandTCPCmd : StandTCPCmdBase
    {
        #region 基本函数
        private static byte[] TcpCmd0Byte(byte cmd, byte door)
        {
            RCmd0Byte bdata = new RCmd0Byte();

            bdata.Head = SetHeadCommand(cmd, door, bdata.Head);
            bdata.Head.Len = Convert.ToUInt16(Marshal.SizeOf(bdata) - Marshal.SizeOf(bdata.Head));
            byte[] buf = TAcsTool.StructToBytes(bdata, Marshal.SizeOf(bdata));

            UInt16 datalen = Convert.ToUInt16(buf.Length & 0xFFFF);
            byte[] Buffer = new byte[datalen + 2];
            Array.Copy(buf, 0, Buffer, 0, buf.Length);

            Buffer[datalen] = BuildCS(buf);
            Buffer[datalen + 1] = 0x03;
            return Buffer;
        }

        private static byte[] TcpCmd1Byte(byte cmd, byte door, byte value)
        {
            RCmd1Byte bdata = new RCmd1Byte();

            bdata.Head = SetHeadCommand(cmd, door, bdata.Head);
            bdata.Value = value;
            bdata.Head.Len = Convert.ToUInt16(Marshal.SizeOf(bdata) - Marshal.SizeOf(bdata.Head));
            byte[] buf = TAcsTool.StructToBytes(bdata, Marshal.SizeOf(bdata));

            UInt16 datalen = Convert.ToUInt16(buf.Length & 0xFFFF);
            byte[] Buffer = new byte[datalen + 2];
            Array.Copy(buf, 0, Buffer, 0, buf.Length);

            Buffer[datalen] = BuildCS(buf);
            Buffer[datalen + 1] = 0x03;
            return Buffer;
        }

        private static byte[] TcpCmdM2Byte(byte cmd, byte door, byte value1, byte value2)
        {
            RCmdMByte bdata = new RCmdMByte();

            bdata.Head = SetHeadCommand(cmd, door, bdata.Head);

            bdata.Value = new byte[128];
            bdata.Value[0] = value1;
            bdata.Value[1] = value2;
            bdata.Head.Len = 2;

            byte[] buf = TAcsTool.StructToBytes(bdata, Marshal.SizeOf(bdata));
            UInt16 datalen = Convert.ToUInt16(Marshal.SizeOf(bdata.Head) + bdata.Head.Len);
            byte[] Buffer = new byte[datalen + 2];
            Array.Copy(buf, 0, Buffer, 0, datalen);

            Buffer[datalen] = BuildCS(datalen, Buffer);
            Buffer[datalen + 1] = 0x03;
            return Buffer;
        }
         
        #endregion

        #region 防潜返for Anti passback
        public static byte[] SetCardStatus(UInt16 Index, byte status)
        {
            RBitCardStatus rs = new RBitCardStatus();
            rs.Index = Index;
            rs.Status = status;

            rs.Head = SetHeadCommand(0x66, 0, rs.Head);
            rs.Head.Len = Convert.ToUInt16(Marshal.SizeOf<RBitDoorPara>() - Marshal.SizeOf<RCmdHead>());
            byte[] buf = TAcsTool.StructToBytes(rs, Marshal.SizeOf(rs));

            UInt16 datalen = Convert.ToUInt16(buf.Length & 0xFFFF);
            byte[] Buffer = new byte[datalen + 2];
            Array.Copy(buf, 0, Buffer, 0, buf.Length);
            Buffer[datalen] = BuildCS(buf);
            Buffer[datalen + 1] = 0x03;
            return Buffer;
        }
        #endregion

        #region 卡片管理
        // 卡片 Card
        public static byte[] ClearAllCards()
        {
            return TcpCmd0Byte((byte)0x17, 0);
        }

        public static byte[] DelCard(UInt16 Index)
        {
            // 用 AddCard 代替
            //return  TcpCmdM2Byte((byte)0x16, 0,  (byte) (Index & 0xff), (byte) ((Index >> 8) & 0xFF)); 
            CardData data = new CardData();
            data.Index = Index;
            return AddCard(data);
        }

        public static byte[] AddCard1Door(CardData1Door data)
        {
            CardData value = MakeCardData(data);
            return AddCard(value);
        }

        public static byte[] AddCard2Door(CardData2Door data)
        {
            CardData value = MakeCardData(data);
            return AddCard(value);
        }

        public static byte[] AddCard4Door(CardData4Door data)
        {
            CardData value = MakeCardData(data);
            return AddCard(value);
        }

        // 加一个卡
        private static byte[] AddCard(CardData data)
        {
            UInt16 DataLen = 0;
            byte[] bufTX = new byte[512];
            Boolean isCardorPIN, isEndDate, isShowName;

            isCardorPIN = (data.FunctionOption & 0x30) > 0;
            isEndDate = (data.FunctionOption & 0x01) == 0x01;
            isShowName = (data.FunctionOption & 0x08) == 0x08;

            DataLen = PutBuf((byte)(data.Index & 0xff), DataLen, bufTX);
            DataLen = PutBuf((byte)((data.Index >> 8) & 0xff), DataLen, bufTX);
            DataLen = PutBufCard(data.CardNo, DataLen, bufTX);

            if (isCardorPIN)
            {
                DataLen = PutBufPin4(data.Pin, DataLen, bufTX);
            }
            else
                DataLen = PutBufPin2(data.Pin, DataLen, bufTX);

            DataLen = PutBuf((data.TZ1), DataLen, bufTX);
            DataLen = PutBuf((data.TZ2), DataLen, bufTX);
            DataLen = PutBuf((data.TZ3), DataLen, bufTX);
            DataLen = PutBuf((data.TZ4), DataLen, bufTX);

            if (isEndDate)
            {
                DataLen = PutBufDate(data.EndTime, DataLen, bufTX);
                DataLen = PutBuf((byte)(data.EndTime.Hour), DataLen, bufTX);
                DataLen = PutBuf((byte)(data.EndTime.Minute), DataLen, bufTX);
            }
            else
            {
                DataLen = PutBuf((byte)0, DataLen, bufTX);
                DataLen = PutBuf(((byte)0), DataLen, bufTX);
                DataLen = PutBuf(((byte)0), DataLen, bufTX);
                DataLen = PutBuf(((byte)0), DataLen, bufTX);
                DataLen = PutBuf((data.Status), DataLen, bufTX);
            }

            if (isShowName)
                DataLen = PutBufNameString(data.Name, (UInt16)8, DataLen, bufTX);

            RCmd0Byte rs = new RCmd0Byte();

            rs.Head = SetHeadCommand(0x62, (byte)(0), rs.Head);
            rs.Head.Len = Convert.ToUInt16(DataLen + Marshal.SizeOf<RCmd0Byte>() - Marshal.SizeOf<RCmdHead>());
            byte[] buf = TAcsTool.StructToBytes(rs, Marshal.SizeOf(rs));

            UInt16 datalen = Convert.ToUInt16(buf.Length + DataLen);
            byte[] Buffer = new byte[datalen + 2];
            Array.Copy(buf, 0, Buffer, 0, buf.Length);
            Array.Copy(bufTX, 0, Buffer, buf.Length, DataLen);

            Buffer[datalen] = BuildCS(datalen, Buffer);
            Buffer[datalen + 1] = 0x03;

            return Buffer;
        }

        #region 批量加卡 
        private static UInt16 SendEmpTcpOne(ref byte[] BufferTX, UInt16 DataLen, CardData data)
        {
            Boolean isCardorPIN, isEndDate, isShowName;
            isCardorPIN = (data.FunctionOption & 0x30) > 0;
            isEndDate = (data.FunctionOption & 0x01) == 0x01;
            isShowName = (data.FunctionOption & 0x08) == 0x08;

            DataLen = PutBufCard(data.CardNo, DataLen, BufferTX);
            if (isCardorPIN)
            {
                DataLen = PutBufPin4(data.Pin, DataLen, BufferTX);
            }
            else
                DataLen = PutBufPin2(data.Pin, DataLen, BufferTX);

            DataLen = PutBuf((data.TZ1), DataLen, BufferTX);
            DataLen = PutBuf((data.TZ2), DataLen, BufferTX);
            DataLen = PutBuf((data.TZ3), DataLen, BufferTX);
            DataLen = PutBuf((data.TZ4), DataLen, BufferTX);

            if (isEndDate)
            {
                DataLen = PutBufDate(data.EndTime, DataLen, BufferTX);
                DataLen = PutBuf((byte)(data.EndTime.Hour), DataLen, BufferTX);
                DataLen = PutBuf((byte)(data.EndTime.Minute), DataLen, BufferTX);
            }
            if (isShowName)
                DataLen = PutBufNameString(data.Name, (UInt16)8, DataLen, BufferTX);
             
           // Array.Copy(bufTX, 0, BufferTX, Loc, DataLen);
            return (UInt16)(DataLen );
        }
         
        public static Boolean AddCardsCheckResult(UInt16 PackIndex, byte[] BufferRX)
        {
            if (BufferRX[Loc_Len + 1] > 1)
            {
                return BufferRX[Loc_Data + 0] * 256 + BufferRX[Loc_Data + 1] == (PackIndex + 1);
            }
            return false;
        }
       
        static UInt16 AddCardsItem(ref byte[] BufferTX, UInt16 DataLen, UInt32 PackIndex, byte CardofPack, UInt16 CardIndex, CardData data)
        {
           // BufferTX[Loc_Command] = 0x88;
            BufferTX[Loc_Data + 0] = Convert.ToByte(((PackIndex + 1) & 0xFF)); //
            BufferTX[Loc_Data + 1] = Convert.ToByte(((PackIndex + 1) >> 8));
            BufferTX[Loc_Data + 2] = Convert.ToByte(CardofPack + 1); //

            if (CardofPack == 0)
            {
                DataLen = SetBufCommand((byte)0x88, 0, 0, BufferTX);
                DataLen = (UInt16)(Loc_Data + 3);
                DataLen = PutBuf(Convert.ToByte(CardIndex & 0xFF), DataLen, BufferTX);
                DataLen = PutBuf(Convert.ToByte((CardIndex >> 8) & 0xFF), DataLen, BufferTX);
            }
            DataLen = SendEmpTcpOne(ref BufferTX, DataLen, data);
            return DataLen;
        }

        public static int AddCards(ref byte[] BufferTX, out byte[] Buffer, ref UInt16 DataLen,ref UInt16 PackIndex, Boolean isLastRecord, byte CardNumInPack, UInt16 CardIndex, CardData data)
        {
            Buffer = null; 
            PackIndex = Convert.ToUInt16(Math.Floor(Convert.ToDouble(CardIndex / CardNumInPack)));
            byte CardofPack = Convert.ToByte(CardIndex % CardNumInPack);

            if (CardofPack == 0)
            {
              //  DataLen = 0;
            }

            DataLen = AddCardsItem(ref BufferTX, DataLen, PackIndex, CardofPack, CardIndex,  data);

            if (((CardofPack + 1) == CardNumInPack) || (isLastRecord))
            {
                DataLen = BuildCSAdd(DataLen, BufferTX);
                Buffer = new byte[DataLen];
                Array.Copy(BufferTX, Buffer, DataLen);
                DataLen = 0;
                return 1;
            }
            return -1;
        }
        #endregion
        
        #endregion

        #region 系统类指令   system
        public static byte[] Restart()
        {
            return TcpCmd0Byte((byte)0x05, 0);
        }

        public static byte[] Reset()
        {
            return TcpCmd0Byte((byte)0x04, 0);
        }

        public static byte[] SetSystemTime(DateTime dt)
        {
            RCmdSetSystime rs = new RCmdSetSystime();

            rs.Head = SetHeadCommand(0x07, 0, rs.Head);
            rs.sec = (byte)dt.Second;
            rs.min = (byte)dt.Minute;
            rs.hour = (byte)dt.Hour;
            rs.Week = (byte)(dt.DayOfWeek + 1);
            rs.day = (byte)dt.Day;
            rs.mon = (byte)dt.Month;
            rs.year = (byte)(dt.Year >= 2000 ? dt.Year - 2000 : dt.Year);

            rs.Head.Len = Convert.ToUInt16(Marshal.SizeOf(rs) - Marshal.SizeOf(rs.Head));
            byte[] buf = TAcsTool.StructToBytes(rs, Marshal.SizeOf(rs));

            UInt16 datalen = Convert.ToUInt16(buf.Length & 0xFFFF);
            byte[] Buffer = new byte[datalen + 2];
            Array.Copy(buf, 0, Buffer, 0, buf.Length);

            Buffer[datalen] = BuildCS(buf);
            Buffer[datalen + 1] = 0x03;
            return Buffer;
        }
        #endregion

        #region 控制类指令 control
        public static byte[] OpenDoor(byte door)
        {
            return TcpCmd0Byte((byte)0x2C, (byte)(door + 1));
        }

        public static byte[] CloseDoor(byte door)
        {
            return TcpCmd0Byte((byte)0x2E, (byte)(door + 1));
        }

        public static byte[] OpenDoorLong(byte door)
        {
            return TcpCmd0Byte((byte)0x2D, (byte)(door + 1));
        }

        public static byte[] LockDoor(byte door, Boolean Lock)
        {
            return TcpCmdM2Byte((byte)0x2F, (byte)(door + 1), TAcsTool.Bool2Byte(Lock), TAcsTool.Bool2Byte(Lock));
        }

        public static byte[] SetAlarm(Boolean AOpen)
        {
            return TcpCmdM2Byte((byte)0x18, 0, TAcsTool.Bool2Byte(!AOpen), TAcsTool.Bool2Byte(false));
        }

        public static byte[] SetFire(Boolean AOpen)
        {
            return TcpCmdM2Byte((byte)0x19, 0, TAcsTool.Bool2Byte(!AOpen), TAcsTool.Bool2Byte(false));
        }

        public static byte[] SetPass(byte Door, byte Reader, Boolean Pass)
        {
            RBitDoorPass rs = new RBitDoorPass();
            rs.Reader = Reader;
            rs.NPass = TAcsTool.Bool2Byte(!Pass);

            rs.Head = SetHeadCommand(0x5A, (byte)(Door + 1), rs.Head);
            rs.Head.Len = Convert.ToUInt16(Marshal.SizeOf<RBitDoorPass>() - Marshal.SizeOf<RCmdHead>());
            byte[] buf = TAcsTool.StructToBytes(rs, Marshal.SizeOf(rs));

            UInt16 datalen = Convert.ToUInt16(buf.Length & 0xFFFF);
            byte[] Buffer = new byte[datalen + 2];
            Array.Copy(buf, 0, Buffer, 0, buf.Length);
            Buffer[datalen] = BuildCS(buf);
            Buffer[datalen + 1] = 0x03;
            return Buffer;
        }
        #endregion

        #region 开放时间 Timezone
        public static byte[] DelTimeZone(byte Door)
        {
            return TcpCmd0Byte((byte)0x0F, (byte)(Door + 1));
        }

        public static byte[] AddTimeZone(byte Door, RTimeZone data)
        {
            RBitTimeZone rs = new RBitTimeZone();
            rs.Index = data.Index;
            rs.FrmHour = (byte)data.FrmTime.Hour;
            rs.FrmMinute = (byte)data.FrmTime.Minute;
            rs.ToHour = (byte)data.ToTime.Hour;
            rs.ToMinute = (byte)data.ToTime.Minute;
            rs.Week = data.Week;

            if (data.Holiday)
                rs.Week |= (byte)0x80;

            rs.Indetify = data.Indetify;
            if (data.APB)
                rs.Indetify |= (byte)0x80;

            rs.EndYear = (byte)(0xff & (data.EndDate.Year - 2000));
            rs.EndMonth = (byte)data.EndDate.Month;
            rs.EndDay = (byte)data.EndDate.Day;
            rs.Group = data.Group;

            rs.Head = SetHeadCommand(0x0D, (byte)(Door), rs.Head);
            rs.Head.Len = Convert.ToUInt16(Marshal.SizeOf<RBitTimeZone>() - Marshal.SizeOf<RCmdHead>());
            byte[] buf = TAcsTool.StructToBytes(rs, Marshal.SizeOf(rs));

            UInt16 datalen = Convert.ToUInt16(buf.Length & 0xFFFF);
            byte[] Buffer = new byte[datalen + 2];
            Array.Copy(buf, 0, Buffer, 0, buf.Length);

            Buffer[datalen] = BuildCS(buf);
            Buffer[datalen + 1] = 0x03;
            return Buffer;
        }
        #endregion

        #region 参数类指令  controller
        public static byte[] SetControl(byte SystemOption, UInt16 FireTime, UInt16 AlarmTime, String DuressPIN, byte LockEach)
        {
            UInt32 vPin;
            Boolean isCardorPIN;
            isCardorPIN = (SystemOption & 0x30) > 0;

            if (isCardorPIN)
            {
                vPin = GetBufPin4(DuressPIN);
            }
            else vPin = Convert.ToUInt32(DuressPIN);

            RBitControlPara rs = new RBitControlPara();
            rs.LockEach = LockEach;
            rs.FireTime = FireTime;
            rs.AlarmTime = AlarmTime;
            rs.DuressPIN = vPin;

            rs.Head = SetHeadCommand(0x63, (byte)(0), rs.Head);
            rs.Head.Len = Convert.ToUInt16(Marshal.SizeOf<RBitControlPara>() - Marshal.SizeOf<RCmdHead>());
            byte[] buf = TAcsTool.StructToBytes(rs, Marshal.SizeOf(rs));

            UInt16 datalen = Convert.ToUInt16(buf.Length & 0xFFFF);
            byte[] Buffer = new byte[datalen + 2];
            Array.Copy(buf, 0, Buffer, 0, buf.Length);
            Buffer[datalen] = BuildCS(buf);
            Buffer[datalen + 1] = 0x03;
            return Buffer;
        }

        public static byte[] SetDoor(byte Door, DoorPara data)
        {
            RBitDoorPara rs = new RBitDoorPara();
            rs.AlarmMask = data.AlarmMask;
            rs.OpenTimeL = (byte)(data.OpenTime & 0xff);
            rs.OutTime = data.OutTime;
            rs.DoublePath = TAcsTool.Bool2Byte(data.DoublePath);
            rs.ToolongAlarm = TAcsTool.Bool2Byte(data.ToolongAlarm);
            rs.OpenTimeH = (byte)((data.OpenTime >> 8) & 0xff);
            rs.AlarmMask = data.AlarmMask;
            rs.AlarmTime = data.AlarmTime;
            rs.MCards = data.MCards;
            rs.MCardsInOut = data.MCardsInOut;

            rs.Head = SetHeadCommand(0x61, (byte)(Door + 1), rs.Head);
            rs.Head.Len = Convert.ToUInt16(Marshal.SizeOf<RBitDoorPara>() - Marshal.SizeOf<RCmdHead>());
            byte[] buf = TAcsTool.StructToBytes(rs, Marshal.SizeOf(rs));

            UInt16 datalen = Convert.ToUInt16(buf.Length & 0xFFFF);
            byte[] Buffer = new byte[datalen + 2];
            Array.Copy(buf, 0, Buffer, 0, buf.Length);
            Buffer[datalen] = BuildCS(buf);
            Buffer[datalen + 1] = 0x03;
            return Buffer;
        }

        public static byte[] DelHoliday()
        {
            return TcpCmd0Byte((byte)0x0C, 0);
        }

        public static byte[] AddHoliday(byte Index, DateTime frmdate, DateTime todate)
        {
            RBitHoliday rs = new RBitHoliday();

            rs.Index = Index;
            rs.FrmYear = (byte)(frmdate.Year - 2000);
            rs.FrmMonth = (byte)frmdate.Month;
            rs.FrmDay = (byte)frmdate.Day;

            rs.EndYear = (byte)(todate.Year - 2000);
            rs.EndMonth = (byte)todate.Month;
            rs.EndDay = (byte)todate.Day;

            rs.Head = SetHeadCommand(0x09, (byte)(0), rs.Head);
            rs.Head.Len = Convert.ToUInt16(Marshal.SizeOf<RBitHoliday>() - Marshal.SizeOf<RCmdHead>());
            byte[] buf = TAcsTool.StructToBytes(rs, Marshal.SizeOf(rs));

            UInt16 datalen = Convert.ToUInt16(buf.Length & 0xFFFF);
            byte[] Buffer = new byte[datalen + 2];
            Array.Copy(buf, 0, Buffer, 0, buf.Length);
            Buffer[datalen] = BuildCS(buf);
            Buffer[datalen + 1] = 0x03;

            return Buffer;
        }
        #endregion

        #region 串口485转发指令 Send com and 485
        public static byte[] SendTo485(byte[] value)
        {
            UInt16 Cmdln = 0;
            if (value != null)
            {
                Cmdln = (UInt16)value.Length;
            }

            RCmd0Byte rs = new RCmd0Byte();

            rs.Head = SetHeadCommand(0xB1, 0, rs.Head);
            rs.Head.Len = Convert.ToUInt16(Cmdln + Marshal.SizeOf<RCmd0Byte>() - Marshal.SizeOf<RCmdHead>());

            byte[] buf = TAcsTool.StructToBytes(rs, Marshal.SizeOf(rs));

            UInt16 datalen = Convert.ToUInt16(buf.Length + Cmdln);
            byte[] Buffer = new byte[datalen + 2];

            Array.Copy(buf, 0, Buffer, 0, buf.Length);
            if (Cmdln > 0) Array.Copy(value, 0, Buffer, buf.Length, value.Length);

            Buffer[datalen] = BuildCS(datalen, Buffer);
            Buffer[datalen + 1] = 0x03;
            return Buffer;
        }
        #endregion

        #region 事件处理和接收的封包和解包
        //   事件处理返回   Event ack 
        public static byte[] AckHeart(UInt32 indexCmd, UInt16 OEMCode, byte[] rec)
        {
            UInt16 Cmdln = 0;
            if (rec != null)
            {
                Cmdln = (UInt16)rec.Length;
            }
            RBitAckHeart rs = new RBitAckHeart();

            rs.OEMCodeH = (byte)((OEMCode >> 8) & 0xFF);
            rs.OEMCodeL = (byte)(OEMCode & 0xFF);
            rs.IndexCmd = indexCmd;

            rs.Head = SetHeadCommand(0x56, 0, rs.Head);
            rs.Head.Len = Convert.ToUInt16(Cmdln + Marshal.SizeOf<RBitAckHeart>() - Marshal.SizeOf<RCmdHead>());

            byte[] buf = TAcsTool.StructToBytes(rs, Marshal.SizeOf(rs));

            UInt16 datalen = Convert.ToUInt16(buf.Length + Cmdln);
            byte[] Buffer = new byte[datalen + 2];

            Array.Copy(buf, 0, Buffer, 0, buf.Length);
            if (Cmdln > 0) Array.Copy(rec, 0, Buffer, buf.Length, rec.Length);

            Buffer[datalen] = BuildCS(datalen, Buffer);
            Buffer[datalen + 1] = 0x03;
            return Buffer;
        }

        public static byte[] AnsHistoryEvent(byte Command, byte index)
        {
            return TcpCmd1Byte((byte)Command, 0, index);
        }

        //  心跳  heart status
        public static RHeartStatus HeartBuf2Struct(byte[] buffer)
        {
            RHeartStatus Event = new RHeartStatus();

            int len = 43;
            if (buffer.Length < len) len = buffer.Length;

            byte[] head = new byte[len];
            Array.Copy(buffer, head, len);

            RTCPHeartStatus Status = (RTCPHeartStatus)TAcsTool.ByteToStruct(head, typeof(RTCPHeartStatus));

            Event.SerialNo = Encoding.ASCII.GetString(Status.Serial);
            Event.CardNumInPack = Status.CardNumInPack;
            Event.DoorStatus = Status.DoorStatus;
            Event.Version = Status.Ver.ToString();
            Event.SystemOption = Status.SystemOption;

            Event.OEMCode = Status.OEMCODE.ToString();

            Event.Datetime = TAcsTool.GetDatetime(Status.second, Status.minute, Status.hour, Status.day, Status.month, Status.year + 2000);

            Event.Input = (UInt16)(Status.Input & 0xffff);

            Event.Online = true;
            Event.IndexCmd = (int)(Status.IndexCmd & 0xffffffff);
            Event.CmdOK = Status.CmdOK;
            return Event;
        }

        //   刷卡记录
        public static RCardEvent CardEventBuf2Struct(byte[] buffer)
        {
            RCardEvent Event = new RCardEvent();

            int len = 21;
            if (buffer.Length < len) len = buffer.Length;

            byte[] Eventbuf = new byte[len];
            Array.Copy(buffer, Eventbuf, len);
            
            RTCPCardEvent CardEvent = (RTCPCardEvent)TAcsTool.ByteToStruct(Eventbuf, typeof(RTCPCardEvent));

            Event.CardNo = TAcsTool.reverse(CardEvent.Card).ToString();

            Event.CardNo = CardEvent.Card.ToString();

            Event.EventType = (byte)(CardEvent.Event & 0x7F);
            Event.Reader = (byte)((CardEvent.Event & 0x80) >> 7);
            Event.Door = CardEvent.Door;
            Event.ReturnIndex = CardEvent.index;
            Event.Datetime = TAcsTool.GetDatetime(CardEvent.second, CardEvent.minute, CardEvent.hour, CardEvent.day, CardEvent.month, CardEvent.year + 2000);
            return Event;
        }

        //    报警记录 alarm event
        public static RAlarmEvent AlarmEventBuf2Struct(byte[] buffer)
        {
            RAlarmEvent Event = new RAlarmEvent();

            int len = 17;
            if (buffer.Length < len) len = buffer.Length;

            byte[] Eventbuf = new byte[len];
            Array.Copy(buffer, Eventbuf, len);

            RTCPAlarmEvent AlarmEvent = (RTCPAlarmEvent)TAcsTool.ByteToStruct(Eventbuf, typeof(RTCPAlarmEvent));
            Event.EventType = (byte)(AlarmEvent.Event & 0x7F);
            Event.Door = (byte)(AlarmEvent.Door & 0x0F);
            Event.ReturnIndex = AlarmEvent.index;
            Event.Datetime = TAcsTool.GetDatetime(AlarmEvent.second, AlarmEvent.minute, AlarmEvent.hour, AlarmEvent.day, AlarmEvent.month, AlarmEvent.year + 2000);
            return Event;
        }

        //   防潜返记录  Anti passback
        public static RAcsCardStatus CardStatusBuf2Struct(byte[] buffer)
        {
            RAcsCardStatus Event = new RAcsCardStatus();

            int len = 12;
            if (buffer.Length < len) len = buffer.Length;

            byte[] Eventbuf = new byte[len];
            Array.Copy(buffer, Eventbuf, len);

            RTCPCardStatus CardStatus = (RTCPCardStatus)TAcsTool.ByteToStruct(Eventbuf, typeof(RTCPCardStatus));

            Event.CardIndex = CardStatus.CardIndex;
            Event.AntiPassBackValue = CardStatus.AntiPassBackValue;
            Event.ReturnIndex = CardStatus.index;
            return Event;
        }
        #endregion
    }
}
