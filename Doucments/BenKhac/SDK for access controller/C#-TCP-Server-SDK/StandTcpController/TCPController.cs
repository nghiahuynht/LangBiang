using TcpStandard_Server.StandTcpProtocol;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DotNetty.Buffers;
using DotNetty.Transport.Channels;

namespace TcpStandard_Server.StandTcpController
{
    // 控制器的当前状态
    public enum TCPWorkStatus
    {
        Close,
        Linked,
        Sending,
        OutTime,
        Faild,
        Finished
    }

    // 卡状态，用于防潜返功能
    public interface CardStatusInterface
    {
        void SetCardStatus(String Serial, int group, UInt16 Index, byte status);
    }

    // 单个控制器类 在这里处理每个控制器的业务
    public class TCPController
    {
        #region 基本数据
        private byte[] BufferTX = new byte[512];
        private byte[] BufferTXU = new byte[2048];
        private byte[] BufferRX = new byte[512];
        private byte LastCmd = 0;
        private ManualResetEventSlim TcpAckSlim = new ManualResetEventSlim();// 用于同步等待指令返回
        private CardStatusInterface SendUpCardStatus = null;// 用于防潜返
        private EventHandleInterface EventHandle;   // 用于显示日志或者界面显示的接口
                                                    // private IChannelHandlerContext ChannelCtx = null;// 通讯管道 
        private TCPLinkHandle TCPHandle = null;


        private RHeartStatus HeartStatus;  // 控制器发送回来的心跳数据  包括设备信息

        public PullCmd pullCmd = new PullCmd();// 拉指令管理 
        public TCPWorkStatus WorkStatus = TCPWorkStatus.Finished;

        public String SerialNo;
        public String Name;
        public int Group;
        public UInt16 OemCode;
        public Boolean Online = false;
        #endregion

        #region 构建
        public TCPController(CardStatusInterface updateCardStatus, EventHandleInterface handle)
        {
            EventHandle = handle;
            SendUpCardStatus = updateCardStatus;
        }

        // 界面显示当前控制器的状态和指令结果的字符串
        public String CmdResult()
        {
            switch (WorkStatus)
            {
                case TCPWorkStatus.Close:
                    return "没有连接！";

                case TCPWorkStatus.Linked:
                    return "已连接！";

                case TCPWorkStatus.Sending:
                    return "工作中！";

                case TCPWorkStatus.OutTime:
                    return "超时！";

                case TCPWorkStatus.Faild:
                    return "失败！";

                case TCPWorkStatus.Finished:
                    return "成功！";
            }
            return "";
        }
        #endregion

        #region 立即发送的指令基础函数
        // 发送指令前，检查控制器的状态
        private Boolean CheckStatus()
        {
            if (WorkStatus == TCPWorkStatus.Close) return false;

            if (TCPHandle == null)
            {
                WorkStatus = TCPWorkStatus.Close;
                return false;
            }

            if (!TCPHandle.Connected())
            {
                WorkStatus = TCPWorkStatus.Close;
                return false;
            }

            if (WorkStatus == TCPWorkStatus.Sending) return false;

            WorkStatus = TCPWorkStatus.Sending;
            return true;
        }

        // 把指令发给控制器 发送过程
        private Boolean SendToTcp(byte[] cmdbuf)
        {
            Boolean rs = this.CheckStatus();
            if (!rs) return false;

            EventHandle.SoftSendCmdHex(cmdbuf);

            TCPHandle.Send(cmdbuf);
            LastCmd = cmdbuf[2];
            return true;
        }

        // 发送指令后 等待控制器返回，或者超时
        private Boolean BeginWait(int mstime, byte cmd, Boolean CheckAck)
        {
            DateTime futureTime = DateTime.Now;
            double remaining;

            mstime += 200;

            try
            {
                TcpAckSlim.Reset();

                TcpAckSlim.Wait(mstime);//阻塞

                remaining = (DateTime.Now - futureTime).TotalMilliseconds;

                if (remaining > mstime)
                {
                    WorkStatus = TCPWorkStatus.OutTime;
                    return false;
                }
                else
                {
                    if (StandTCPCmd.CheckRxCmdAck(BufferRX, LastCmd, CheckAck))
                    {
                        WorkStatus = TCPWorkStatus.Finished;
                    }
                    else
                    {
                        WorkStatus = TCPWorkStatus.Faild;
                    }
                    return true;
                }
            }
            catch
            {
                WorkStatus = TCPWorkStatus.OutTime;
                return false;
            }
        }

        // 通知等待的指令，控制器有数据返回
        private void OnTcpAckNotify()
        {
            TcpAckSlim.Set();
        }
        #endregion

        #region 接收数据
        // 应答给控制器心跳
        private byte[] AnswerHeart(Boolean CanPull, int IndexCmd, Boolean lastOK)
        {
            byte[] cmd = null;
            PullCmdData pullcmd;
            UInt32 index = 0;

            if (CanPull)
            {
                pullcmd = pullCmd.GetNextPullCmd(IndexCmd, lastOK);
                if (pullcmd != null)
                {
                    cmd = pullcmd.CmdBytes;
                    index = pullcmd.ID;
                    this.EventHandle.ShowPullCmd(cmd, pullCmd.Count);
                }
                else
                    this.EventHandle.ShowPullCmd(null, 0);
            }

            byte[] cmdbuf = StandTCPCmd.AckHeart(index, OemCode, cmd);
            if (cmdbuf != null)
            {
                WorkStatus = TCPWorkStatus.Linked;
            }
            return cmdbuf;
        }

        // 处理控制器发送来的数据，包括是事件和应答
        private byte[] RevDataController(byte[] data)
        {
            byte[] cmdbuf = null;

            byte cmd = data[2];
            switch (cmd)
            {
                case 0x56: // 心跳
                    RHeartStatus vStatus = StandTCPCmd.HeartBuf2Struct(data);
                    {
                        HeartStatus = vStatus;
                        cmdbuf = AnswerHeart(true, HeartStatus.IndexCmd, HeartStatus.CmdOK == 1);

                        if (!Online)
                        {
                            Online = true;
                            EventHandle.ShowNetChange(this);
                        }
                        //处理心跳后的业务
                        EventHandle.ShowHeartEvent(vStatus, this);
                    }
                    break;

                case 0x53: // 刷卡记录
                    RCardEvent vCardEvent = StandTCPCmd.CardEventBuf2Struct(data);
                    {
                        EventHandle.ShowCardEvent(vCardEvent, this);
                        cmdbuf = StandTCPCmd.AnsHistoryEvent(cmd, (byte)vCardEvent.ReturnIndex);
                    }
                    break;

                case 0x54: // 报警记录
                    RAlarmEvent vAlarmEvent = StandTCPCmd.AlarmEventBuf2Struct(data);
                    {
                        EventHandle.ShowAlarmEvent(vAlarmEvent, this);
                        cmdbuf = StandTCPCmd.AnsHistoryEvent(cmd, (byte)vAlarmEvent.ReturnIndex);
                    }
                    break;

                case 0x52: // 防潜返
                    RAcsCardStatus vCardStatusEvent = StandTCPCmd.CardStatusBuf2Struct(data);
                    {
                        cmdbuf = StandTCPCmd.AnsHistoryEvent(cmd, (byte)vCardStatusEvent.ReturnIndex);
                        // 发给接口 ， 更新其他控制器的值，拉指令处理
                        if (SendUpCardStatus != null)
                            SendUpCardStatus.SetCardStatus(this.SerialNo, this.Group, vCardStatusEvent.CardIndex, vCardStatusEvent.AntiPassBackValue);
                    }
                    break;

                default:
                    TAcsTool.Print("recd");
                    OnTcpAckNotify();
                    break;
            }
            return cmdbuf;
        }

        public byte[] TcpDataAnly(byte[] data)
        {
            if (data == null) return null;
            byte[] cmdbuf;

            int len = data.Length;
            if (len > BufferRX.Length) len = BufferRX.Length;

            if (data[2] != 0x56)
                Array.Copy(data, 0, BufferRX, 0, len);

            cmdbuf = RevDataController(data);

            return cmdbuf;
        }

        //通讯函数 接收控制器的数据 并且处理后返回要应答的数据包
        public byte[] TcpLink(byte[] data, TCPLinkHandle ctx)
        {
            TCPHandle = ctx;
            if (data == null) return null;
            return TcpDataAnly(data);
        }
        #endregion

        #region 控制指令
        public Boolean OpenDoor(Boolean pull, byte door)
        {
            byte[] cmdbuf = StandTCPCmd.OpenDoor((byte)door);

            if (pull)
            {
                pullCmd.AddPullCmd(true, cmdbuf);
                return true;
            }
            Boolean rs = SendToTcp(cmdbuf);
            if (rs)
                rs = BeginWait(100, cmdbuf[2], true);
            return rs;
        }

        public Boolean CloseDoor(Boolean pull, byte door)
        {
            byte[] cmdbuf = StandTCPCmd.CloseDoor((byte)door);

            if (pull)
            {
                pullCmd.AddPullCmd(true, cmdbuf);
                return true;
            }

            Boolean rs = SendToTcp(cmdbuf);
            if (rs)
                rs = BeginWait(100, cmdbuf[2], true);
            return rs;
        }

        public Boolean SetAlarm(Boolean pull, Boolean open)
        {
            byte[] cmdbuf = StandTCPCmd.SetAlarm(open);

            if (pull)
            {
                pullCmd.AddPullCmd(true, cmdbuf);
                return true;
            }
            Boolean rs = SendToTcp(cmdbuf);
            if (rs)
                rs = BeginWait(100, cmdbuf[2], true);
            return rs;
        }

        public Boolean SetFire(Boolean pull, Boolean open)
        {
            byte[] cmdbuf = StandTCPCmd.SetFire(open);

            if (pull)
            {
                pullCmd.AddPullCmd(true, cmdbuf);
                return true;
            }

            Boolean rs = SendToTcp(cmdbuf);
            if (rs)
                rs = BeginWait(100, cmdbuf[2], true);
            return rs;
        }

        public Boolean OpenDoorLong(Boolean pull, byte door)
        {
            byte[] cmdbuf = StandTCPCmd.OpenDoorLong(door);

            if (pull)
            {
                pullCmd.AddPullCmd(true, cmdbuf);
                return true;
            }
            Boolean rs = SendToTcp(cmdbuf);
            if (rs)
                rs = BeginWait(100, cmdbuf[2], true);
            return rs;
        }

        public Boolean LockDoor(Boolean pull, byte door, Boolean alock)
        {
            byte[] cmdbuf = StandTCPCmd.LockDoor(door, alock);

            if (pull)
            {
                pullCmd.AddPullCmd(true, cmdbuf);
                return true;
            }

            Boolean rs = SendToTcp(cmdbuf);
            if (rs)
                rs = BeginWait(100, cmdbuf[2], true);
            return rs;
        }

        public Boolean SetPass(Boolean pull, byte door, byte Reader, Boolean Pass)
        {
            byte[] cmdbuf = StandTCPCmd.SetPass(door, Reader, Pass);
            if (pull)
            {
                pullCmd.AddPullCmd(true, cmdbuf);
                return true;
            }

            Boolean rs = SendToTcp(cmdbuf);
            if (rs)
                rs = BeginWait(100, cmdbuf[2], true);
            return rs;
        }
        #endregion

        #region 开放时间指令
        public Boolean DelTimeZone(Boolean pull, byte Door)
        {
            byte[] cmdbuf = StandTCPCmd.DelTimeZone((byte)Door);
            if (pull)
            {
                pullCmd.AddPullCmd(false, cmdbuf);
                return true;
            }

            Boolean rs = SendToTcp(cmdbuf);
            if (rs)
                rs = BeginWait(100, cmdbuf[2], true);
            return rs;
        }

        public Boolean AddTimezone(Boolean pull, byte door, RTimeZone data)
        {
            Boolean rs = false;

            byte[] cmdbuf = StandTCPCmd.AddTimeZone((byte)door, data);
            if (pull)
            {
                pullCmd.AddPullCmd(false, cmdbuf);
                return true;
            }

            rs = SendToTcp(cmdbuf);
            if (rs)
                rs = BeginWait(150, cmdbuf[2], true);
            return rs;
        }
        #endregion

        #region 参数
        // 设置门参数  有默认值可以不需要更新，可以在web界面配置
        public Boolean SetDoor(Boolean pull, byte door, DoorPara data)
        {
            byte[] cmdbuf = StandTCPCmd.SetDoor((byte)door, data);

            if (pull)
            {
                pullCmd.AddPullCmd(false, cmdbuf);
                return true;
            }

            Boolean rs = SendToTcp(cmdbuf);
            if (rs)
                rs = BeginWait(100, cmdbuf[2], true);
            return rs;
        }

        // 设置控制器参数  有默认值可以不需要更新，可以在web界面配置
        public Boolean SetControl(Boolean pull, UInt16 FireTime, UInt16 AlarmTime, String DuressPIN, byte LockEach)
        {
            byte[] cmdbuf = StandTCPCmd.SetControl(HeartStatus.SystemOption, FireTime, AlarmTime, DuressPIN, LockEach);

            if (pull)
            {
                pullCmd.AddPullCmd(false, cmdbuf);
                return true;
            }

            Boolean rs = SendToTcp(cmdbuf);
            if (rs)
                rs = BeginWait(100, cmdbuf[2], true);
            return rs;
        }

        // 删除全部假日
        public Boolean DelHoliday(Boolean pull)
        {
            byte[] cmdbuf = StandTCPCmd.DelHoliday();
            if (pull)
            {
                pullCmd.AddPullCmd(false, cmdbuf);
                return true;
            }

            Boolean rs = SendToTcp(cmdbuf);
            if (rs)
                rs = BeginWait(150, cmdbuf[2], true);
            return rs;
        }

        // index 从1开始
        public Boolean AddHoliday(Boolean pull, byte Index, DateTime frmdate, DateTime todate)
        {
            byte[] cmdbuf = StandTCPCmd.AddHoliday(Index, frmdate, todate);
            if (pull)
            {
                pullCmd.AddPullCmd(false, cmdbuf);
                return true;
            }

            Boolean rs = SendToTcp(cmdbuf);
            if (rs)
                rs = BeginWait(150, cmdbuf[2], true);
            return rs;
        }

        //更新全部参数， 每个指令都可以使用默认配置，而不需要执行，除了假日以外。不需要的请注释掉
        public Boolean SetAllPara(Boolean pull)
        {
            Boolean rs = false;
            /*
            rs = SetDoor(pull);
            EventHandle.ShowMsg("更新门参数", (rs.ToString()));

            rs = SetControl(pull, (UInt16)100, (UInt16)10, "ABCD", (byte)0);
            EventHandle.ShowMsg("更新控制器参数", (rs.ToString()));

            rs = DelTimeZone(pull, (byte)0);
            EventHandle.ShowMsg("删除全部开放时间", (rs.ToString()));

            rs = AddTimezone(pull,new RTimeZone());
            EventHandle.ShowMsg("增加开放时间", (rs.ToString()));

            rs = DelHoliday(pull);
            EventHandle.ShowMsg("删除假日", (rs.ToString()));

            // index 从1开始
            rs = AddHoliday(pull, (byte)1, DateTime.Now, DateTime.Now);
            EventHandle.ShowMsg("增加假日", (rs.ToString()));
            */
            return rs;
        }
        #endregion

        #region 卡管理类指令
        // 删除全部卡
        public Boolean ClearCards(Boolean pull)
        {
            byte[] cmdbuf = StandTCPCmd.ClearAllCards();
            if (pull)
            {
                pullCmd.AddPullCmd(false, cmdbuf);
                return true;
            }
            Boolean rs = SendToTcp(cmdbuf);
            if (rs)
                rs = BeginWait(2000, cmdbuf[2], true);
            return rs;
        }

        public Boolean DelCard(Boolean pull, UInt16 Index)
        {
            byte[] cmdbuf = StandTCPCmd.DelCard(Index);
            if (pull)
            {
                pullCmd.AddPullCmd(false, cmdbuf);
                return true;
            }
            Boolean rs = SendToTcp(cmdbuf);
            if (rs)
                rs = BeginWait(2000, cmdbuf[2], true);
            return rs;
        }

        public Boolean AddCard1Door(Boolean pull, CardData1Door data)
        {
            data.FunctionOption = HeartStatus.SystemOption;
            data.Status = 1;
            byte[] cmdbuf = StandTCPCmd.AddCard1Door(data);
            if (pull)
            {
                pullCmd.AddPullCmd(false, cmdbuf);
                return true;
            }
            Boolean rs = SendToTcp(cmdbuf);
            if (rs)
                rs = BeginWait(450, cmdbuf[2], true);

            return rs;
        }

        public Boolean AddCard2Door(Boolean pull, CardData2Door data)
        {
            data.FunctionOption = HeartStatus.SystemOption;
            data.Status = 1;
            byte[] cmdbuf = StandTCPCmd.AddCard2Door(data);
            if (pull)
            {
                pullCmd.AddPullCmd(false, cmdbuf);
                return true;
            }
            Boolean rs = SendToTcp(cmdbuf);
            if (rs)
                rs = BeginWait(300, cmdbuf[2], true);
            return rs;
        }

        public Boolean AddCard4Door(Boolean pull, CardData4Door data)
        {
            data.FunctionOption = HeartStatus.SystemOption;
            data.Status = 1;
            byte[] cmdbuf = StandTCPCmd.AddCard4Door(data);
            if (pull)
            {
                pullCmd.AddPullCmd(false, cmdbuf);
                return true;
            }
            Boolean rs = SendToTcp(cmdbuf);
            if (rs)
                rs = BeginWait(300, cmdbuf[2], true);
            return rs;
        }

        #region 批量加卡 
        public Boolean AddCards(Boolean isLastRecord, ref UInt16 DataLen, UInt16 CardIndex, CardData data)
        {
            UInt16 PackIndex = 0;
            byte[] Buffer;

            byte CardNumInPack = HeartStatus.CardNumInPack;
            if ((CardNumInPack < 15) || (CardNumInPack > 45)) return false;

            data.FunctionOption = HeartStatus.SystemOption;
            int r = StandTCPCmd.AddCards(ref BufferTXU, out Buffer, ref DataLen, ref PackIndex, isLastRecord, CardNumInPack, CardIndex, data);

            if (r > 0)
                if (Buffer != null)
                {
                    Boolean rs = SendToTcp(Buffer);
                    if (rs)
                        rs = BeginWait(1800, Buffer[2], false);

                    if (rs)
                    {
                        rs = StandTCPCmd.AddCardsCheckResult(PackIndex, BufferRX);
                    }

                    return rs;
                }
            return true;
        }

        public Boolean AddCardsBytes(Boolean isLastRecord, ref UInt16 DataLen, UInt16 CardIndex, CardData data)
        {
            UInt16 PackIndex = 0;
            byte[] Buffer;
            byte CardNumInPack = HeartStatus.CardNumInPack;
            if ((CardNumInPack < 15) || (CardNumInPack > 45)) return false;

            data.FunctionOption = HeartStatus.SystemOption;
            int r = StandTCPCmd.AddCards(ref BufferTXU, out Buffer, ref DataLen, ref PackIndex, isLastRecord, CardNumInPack, CardIndex, data);

            if (r > 0)
                if (Buffer != null)
                {
                    pullCmd.AddPullCmd(false, Buffer);
                    return true;
                }
            return true;
        }
        #endregion

        #endregion

        #region 系统指令
        public Boolean Restart(Boolean pull)
        {
            byte[] cmdbuf = StandTCPCmd.Restart();
            if (pull)
            {
                pullCmd.AddPullCmd(false, cmdbuf);
                return true;
            }
            Boolean rs = SendToTcp(cmdbuf);
            if (rs)
                rs = BeginWait(200, cmdbuf[2], true);
            return rs;
        }

        public Boolean Reset(Boolean pull)
        {
            byte[] cmdbuf = StandTCPCmd.Reset();
            if (pull)
            {
                pullCmd.AddPullCmd(false, cmdbuf);
                return true;
            }
            Boolean rs = SendToTcp(cmdbuf);
            if (rs)
                rs = BeginWait(200, cmdbuf[2], true);
            return rs;
        }

        public Boolean SetSystemTime(Boolean pull, DateTime dt)
        {
            byte[] cmdbuf = StandTCPCmd.SetSystemTime(dt);
            if (pull)
            {
                pullCmd.AddPullCmd(false, cmdbuf);
                return true;
            }
            Boolean rs = SendToTcp(cmdbuf);
            if (rs)
                rs = BeginWait(200, cmdbuf[2], true);
            return rs;
        }
        #endregion

        #region 辅助指令 
        // 通过485发送数据，485输出就是本指令的数据部分，该指令控制器没有返回，如果485有数据输入，则会通过对应的指令0xB1,返回。
        // 或者随时产生tcp指令输入。

        public Boolean SendTo485(Boolean pull, byte[] value)
        {
            byte[] cmdbuf = StandTCPCmd.SendTo485(value);
            if (pull)
            {
                pullCmd.AddPullCmd(false, cmdbuf);
                return true;
            }
            Boolean rs = SendToTcp(cmdbuf);
            if (rs)
                rs = BeginWait(200, cmdbuf[2], false);

            if (rs)
            {
                // 处理接收的数据
            }
            return rs;
        }
        #endregion
    }

    // 拉指令数据结构
    public class PullCmdData
    {
        public UInt32 ID;  // 指令ID，心跳通过该值判断 对应指令是否执行完成
        public byte[] CmdBytes;  // 指令数据
    }

    // 用于管理拉指令的类 ， 建议除了立即要执行的指令外，都使用拉指令，也就是都缓存在这里， 由心跳来执行
    public class PullCmd
    {
        private UInt32 IDNow = 0;

        // 指令队列，使用先进先出，但可以插入高优先级记录
        private List<PullCmdData> PullCmdList = new List<PullCmdData>();

        // 加入一个拉指令，等待执行，
        public void AddPullCmd(Boolean priority, byte[] Cmd)
        {
            PullCmdData value = new PullCmdData();
            value.CmdBytes = Cmd;
            IDNow++;
            value.ID = IDNow;
            if (priority)
            {
                PullCmdList.Insert(0, value);// 高优先级插入
            }
            else
                PullCmdList.Add(value);
        }

        // 由心跳来获取一个需要执行的指令
        public PullCmdData GetNextPullCmd(int lastid, Boolean lastOK)
        {
            PullCmdData cmd;

            if (lastid > 0 && lastOK)
            {
                for (int i = 0; i < PullCmdList.Count(); i++)
                {
                    cmd = PullCmdList[i];
                    if (cmd.ID == lastid)
                    {
                        PullCmdList.RemoveAt(i);
                        break;
                    }
                }
            }

            if (PullCmdList.Count() > 0)
            {
                cmd = PullCmdList[0];
                return cmd;
            }
            else return null;
        }

        public int Count { get { return this.PullCmdList.Count(); } }
    }
}
