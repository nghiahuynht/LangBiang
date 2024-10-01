package StandTcp.StandTcpController;


import StandTcp.StandTcpProtocol.StandTCPCmd;
import StandTcp.StandTcpProtocol.TAcsTool;
import StandTcp.StandTcpProtocol.TCPCmdStruct;
import io.netty.buffer.ByteBuf;
import io.netty.buffer.Unpooled;
import io.netty.channel.ChannelHandlerContext;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

// 卡状态，用于防潜返功能
interface CardStatusInterface {
    void SetCardStatus(String Serial, int group, short Index, byte status);
}


// 单个控制器类 在这里处理每个控制器的业务
public class TCPController {
    private byte[] BufferTX = new byte[512];
    private byte[] BufferRX = new byte[512];

    protected PullCmd pullCmd = new PullCmd();// 拉指令管理
    private Object TcpAckStatus = new Object(); // 用于同步等待指令返回

    private byte LastCmd = 0;
    public TCPWorkStatus WorkStatus = TCPWorkStatus.Finished;
    protected LogCmdInterface LogShow;   // 用于显示日志或者界面显示的接口
    protected CardStatusInterface SendUpCardStatus = null;
    protected ChannelHandlerContext ChannelCtx = null;// 通讯管道
    protected TCPCmdStruct.RHeartStatus HeartStatus;  // 控制器发送回来的心跳数据  包括设备信息

    public short OEMCode;
    public String SerialNo;
    public String Name;
    public int Group;

    public TCPController(CardStatusInterface updateCardStatus, LogCmdInterface logShow) {
        LogShow = logShow;
        SendUpCardStatus = updateCardStatus;
    }

    // 界面显示当前控制器的状态和指令结果的字符串
    public String CmdResult() {
        switch (WorkStatus) {
            case Close:
                return "没有连接！";

            case Linked:
                return "已连接！";

            case Sending:
                return "工作中！";

            case OutTime:
                return "超时！";

            case Faild:
                return "失败！";

            case Finished:
                return "成功！";
        }
        return "";
    }

    // 发送指令前，检查控制器的状态
    private Boolean CheckStatus() {
        if (WorkStatus == TCPWorkStatus.Close) return false;

        if (ChannelCtx == null) {
            WorkStatus = TCPWorkStatus.Close;
            return false;
        }

        if (!ChannelCtx.channel().isActive()) {
            WorkStatus = TCPWorkStatus.Close;
            return false;
        }

        if (WorkStatus == TCPWorkStatus.Sending) return false;

        WorkStatus = TCPWorkStatus.Sending;
        return true;
    }

    // 把指令发给控制器 发送过程
    private boolean SendToTcp(byte[] cmdbuf) {
        boolean rs = this.CheckStatus();
        if (!rs) return false;

        ByteBuf buf = Unpooled.wrappedBuffer(cmdbuf);

        LogShow.SoftSendCmdHex(cmdbuf);
        ChannelCtx.writeAndFlush(buf);
        LastCmd = cmdbuf[2];
        return true;
    }

    // 发送指令后 等待控制器返回，或者超时
    private boolean BeginWait(long mstime, byte cmd, boolean CheckAck) {
        long futureTime = System.currentTimeMillis() + mstime;
        long remaining = mstime;

        synchronized (TcpAckStatus) {
            try {
                TcpAckStatus.wait(mstime);//阻塞
                remaining = futureTime - System.currentTimeMillis();

                if (remaining <= 0) {
                    WorkStatus = TCPWorkStatus.OutTime;
                    return false;
                } else {
                    if (StandTCPCmd.CheckRxCmdAck(BufferRX, LastCmd, CheckAck)) {
                        WorkStatus = TCPWorkStatus.Finished;
                    } else {
                        WorkStatus = TCPWorkStatus.Faild;
                    }
                    return true;
                }

            } catch (Exception e) {
                e.printStackTrace();
                WorkStatus = TCPWorkStatus.OutTime;
                return false;
            }
        }
    }

    // 通知等待的指令，控制器有数据返回
    private void OnTcpAckNotify() {
        synchronized (TcpAckStatus) {
            TcpAckStatus.notify();
        }
    }

    // 应答给控制器心跳
    public void AnswerHeart(boolean CanPull, int IndexCmd, boolean lastOK) {
        byte[] cmd = null;
        PullCmdData pullcmd;
        int index = 0;

        if (CanPull) {
            pullcmd = pullCmd.GetNextPullCmd(IndexCmd, lastOK);
            if (pullcmd != null) {
                cmd = pullcmd.CmdBytes;
                index = pullcmd.ID;
            }
        }

        byte[] cmdbuf = StandTCPCmd.AckHeart(index, (short) OEMCode, cmd);
        if (cmdbuf != null) {
            ByteBuf buf = Unpooled.wrappedBuffer(cmdbuf);
            ChannelCtx.writeAndFlush(buf);
            LogShow.SoftSendCmdHex(cmdbuf);
            WorkStatus = TCPWorkStatus.Linked;
        }
    }

    // 处理控制器发送来的数据，包括是事件和应答
    private byte[] RevDataController(byte[] data) {
        byte[] cmdbuf = null;

        byte cmd = data[2];
        switch (cmd) {
            case 0x56: // 心跳
                TCPCmdStruct.RHeartStatus vStatus = StandTCPCmd.HeartBuf2Struct(data);
                if (vStatus != null) {
                    HeartStatus = vStatus;
                    AnswerHeart(true, HeartStatus.IndexCmd, HeartStatus.CmdOK == 1);
                    //处理心跳后的业务
                    LogShow.ShowHeartEvent(vStatus);
                } else
                    AnswerHeart(false, 0, false);
                break;

            case 0x53: // 刷卡记录
                TCPCmdStruct.RCardEvent vCardEvent = StandTCPCmd.CardEventBuf2Struct(data);
                if (vCardEvent != null) {
                    //
                    vCardEvent.SerialNo = HeartStatus.SerialNo;

                    LogShow.ShowCardEvent(vCardEvent);  // 这里回调可以加一个控制器对象，返回给处理函数

                    cmdbuf = StandTCPCmd.AnsHistoryEvent(cmd, (byte) vCardEvent.ReturnIndex);
                }
                break;

            case 0x54: // 报警记录
                TCPCmdStruct.RAlarmEvent vAlarmEvent = StandTCPCmd.AlarmEventBuf2Struct(data);
                if (vAlarmEvent != null) {
                    //
                    LogShow.ShowAlarmEvent(vAlarmEvent);

                    cmdbuf = StandTCPCmd.AnsHistoryEvent(cmd, (byte) vAlarmEvent.ReturnIndex);
                }
                break;

            case 0x52: // 防潜返
                TCPCmdStruct.RAcsCardStatus vCardStatusEvent = StandTCPCmd.CardStatusBuf2Struct(data);
                if (vCardStatusEvent != null) {
                    //
                    cmdbuf = StandTCPCmd.AnsHistoryEvent(cmd, (byte) vCardStatusEvent.ReturnIndex);

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

    //通讯函数 接收控制器的数据 并且处理后返回要应答的数据包
    protected byte[] TcpLink(byte[] data, ChannelHandlerContext ctx) {
        ChannelCtx = ctx;
        if (data == null) return null;

       // if (!StandTCPCmd.CheckRxDataCS(data)) return null; // 校验接收的数据

        int len = data.length;
        if (len > BufferRX.length) len = BufferRX.length;
        System.arraycopy(data, 0, BufferRX, 0, len);

        byte[] cmdbuf = RevDataController(data);

        if (cmdbuf != null) {
            ByteBuf buf = Unpooled.wrappedBuffer(cmdbuf);
            ChannelCtx.writeAndFlush(buf);
            LogShow.SoftSendCmdHex(cmdbuf);
        }
        return null;
    }

    public boolean OpenDoor(boolean pull, byte index) {
        byte[] cmdbuf = StandTCPCmd.OpenDoor((byte) 0);

        if (pull) {
            pullCmd.AddPullCmd(true, cmdbuf);
            return true;
        }
        boolean rs = SendToTcp(cmdbuf);
        if (rs)
            rs = BeginWait(100, cmdbuf[2], true);

        return rs;
    }

    public boolean CloseDoor(boolean pull, byte index) {
        byte[] cmdbuf = StandTCPCmd.CloseDoor((byte) 0);

        if (pull) {
            pullCmd.AddPullCmd(true, cmdbuf);
            return true;
        }

        boolean rs = SendToTcp(cmdbuf);
        if (rs)
            rs = BeginWait(100, cmdbuf[2], true);

        return rs;
    }

    public boolean DelTimeZone(boolean pull, byte Door) {
        byte[] cmdbuf = StandTCPCmd.DelTimeZone((byte) Door);
        if (pull) {
            pullCmd.AddPullCmd(false, cmdbuf);
            return true;
        }

        boolean rs = SendToTcp(cmdbuf);
        if (rs)
            rs = BeginWait(100, cmdbuf[2], true);
        return rs;
    }

    public boolean AddTimezone(boolean pull) {
        boolean rs = false;
        TCPCmdStruct.TimeZone data = new TCPCmdStruct.TimeZone();

        data.Index = 0;
        data.FrmHour = 0;
        data.FrmMinute = 0;
        data.ToHour = 23;
        data.ToMinute = 59;
        data.Week = (byte) 0xff;
        data.Indetify = 1;
        data.APB = true;
        data.EndDate = LocalDate.now().plusYears(10);
        data.Group = 0;

        byte[] cmdbuf = StandTCPCmd.AddTimeZone((byte) 0, data);
        if (pull) {
            pullCmd.AddPullCmd(false, cmdbuf);
            return true;
        }

        rs = SendToTcp(cmdbuf);
        if (rs)
            rs = BeginWait(100, cmdbuf[2], true);
        return rs;
    }

    // 设置门参数  有默认值可以不需要更新，可以在web界面配置
    public boolean SetDoor(boolean pull) {
        TCPCmdStruct.DoorPara data = new TCPCmdStruct.DoorPara();
        byte[] cmdbuf = StandTCPCmd.SetDoor((byte) 0, data);

        if (pull) {
            pullCmd.AddPullCmd(false, cmdbuf);
            return true;
        }

        boolean rs = SendToTcp(cmdbuf);
        if (rs)
            rs = BeginWait(100, cmdbuf[2], true);
        return rs;
    }

    // 设置控制器参数  有默认值可以不需要更新，可以在web界面配置
    public boolean SetControl(boolean pull, short FireTime, short AlarmTime, String DuressPIN, byte LockEach) {
        byte[] cmdbuf = StandTCPCmd.SetControl(HeartStatus.SystemOption, FireTime, AlarmTime, DuressPIN, LockEach);

        if (pull) {
            pullCmd.AddPullCmd(false, cmdbuf);
            return true;
        }

        boolean rs = SendToTcp(cmdbuf);
        if (rs)
            rs = BeginWait(100, cmdbuf[2], true);
        return rs;
    }

    // 删除全部假日
    public boolean DelHoliday(boolean pull) {
        byte[] cmdbuf = StandTCPCmd.DelHoliday();
        if (pull) {
            pullCmd.AddPullCmd(false, cmdbuf);
            return true;
        }

        boolean rs = SendToTcp(cmdbuf);
        if (rs)
            rs = BeginWait(150, cmdbuf[2], true);
        return rs;
    }

    // index 从1开始
    public boolean AddHoliday(boolean pull, byte Index, LocalDateTime frmdate, LocalDateTime todate) {
        byte[] cmdbuf = StandTCPCmd.AddHoliday(Index, frmdate, todate);
        if (pull) {
            pullCmd.AddPullCmd(false, cmdbuf);
            return true;
        }

        boolean rs = SendToTcp(cmdbuf);
        if (rs)
            rs = BeginWait(150, cmdbuf[2], true);
        return rs;
    }

    //更新全部参数， 每个指令都可以使用默认配置，而不需要执行，除了假日以外。不需要的请注释掉
    public boolean SetAllPara(boolean pull) {
        boolean rs;

        rs = SetDoor(pull);
        LogShow.ShowMsg("更新门参数", String.valueOf(rs));

        rs = SetControl(pull, (short) 100, (short) 10, "ABCD", (byte) 0);
        LogShow.ShowMsg("更新控制器参数", String.valueOf(rs));

        rs = DelTimeZone(pull, (byte) 0);
        LogShow.ShowMsg("删除全部开放时间", String.valueOf(rs));

        rs = AddTimezone(pull);
        LogShow.ShowMsg("增加开放时间", String.valueOf(rs));

        rs = DelHoliday(pull);
        LogShow.ShowMsg("删除假日", String.valueOf(rs));

        // index 从1开始
        rs = AddHoliday(pull, (byte) 1, LocalDateTime.now(), LocalDateTime.now());
        LogShow.ShowMsg("增加假日", String.valueOf(rs));

        return rs;
    }

    // 删除全部卡
    public boolean ClearCards(boolean pull) {
        byte[] cmdbuf = StandTCPCmd.ClearAllCards();
        if (pull) {
            pullCmd.AddPullCmd(false, cmdbuf);
            return true;
        }
        boolean rs = SendToTcp(cmdbuf);
        if (rs)
            rs = BeginWait(2000, cmdbuf[2], true);

        return rs;
    }

    public boolean AddCard(boolean pull) {
        TCPCmdStruct.CardData data = new TCPCmdStruct.CardData();

        data.Index = 0;
        data.EndTime = LocalDateTime.now().plusYears(1);
        data.Name = "姓名";
        data.TZ1 = 1;
        data.TZ2 = 1;
        data.CardNo = 444855280;
        data.FunctionOption = HeartStatus.SystemOption;
        data.Status = 1;

        byte[] cmdbuf = StandTCPCmd.AddCard(data);
        if (pull) {
            pullCmd.AddPullCmd(false, cmdbuf);
            return true;
        }

        boolean rs = SendToTcp(cmdbuf);
        if (rs)
            rs = BeginWait(100, cmdbuf[2], true);

        return rs;
    }

    private short PackIndex = 0;// 包序号 0..
    private byte CardofPack = 0; // 卡在包中的序号 0..CardNumInPack-1
    private short CardsDataLen = 0;

    // 批量加卡，不支持拉指令
    public Boolean AddCards(Boolean isLastRecord, TCPCmdStruct.CardData data) {
        int CardIndex = data.Index;
        byte CardNumInPack = HeartStatus.CardNumInPack;

        boolean rs;

        if ((CardNumInPack < 15) || (CardNumInPack > 45)) return false;

        PackIndex = (short) (CardIndex / CardNumInPack);
        CardofPack = (byte) (CardIndex % CardNumInPack);

        data.FunctionOption = HeartStatus.SystemOption;
        CardsDataLen = StandTCPCmd.AddCards(this.BufferTX, CardsDataLen, PackIndex, CardofPack, data);

        if (((CardofPack + 1) >= CardNumInPack) || (isLastRecord)) {
            byte[] cmdbuf = StandTCPCmd.AddCardsEndSendCards(BufferTX, CardsDataLen);

            CardsDataLen = 0;
            rs = this.CheckStatus();

            if (!rs) return false;

            rs = SendToTcp(cmdbuf);
            if (rs)
                rs = BeginWait(1800, cmdbuf[2], false);

            if (rs) {
                rs = StandTCPCmd.AddCardsCheckResult(PackIndex, BufferRX);
            }
            return rs;
        }
        return true;
    }


    //拉指令  增加卡
    public void PullCmdAddCard(TCPCmdStruct.CardData data) {
        data.Status = 1;
        data.FunctionOption = HeartStatus.SystemOption;
        byte[] cmdbuf = StandTCPCmd.AddCard(data);
        pullCmd.AddPullCmd(false, cmdbuf);
    }

    // 拉指令  增加卡
    public void PullCmdAddCard(int num) {
        int i;
        TCPCmdStruct.CardData data = new TCPCmdStruct.CardData();
        data.FunctionOption = HeartStatus.SystemOption;

        for (i = 0; i < num; i++) {
            data.Index = i;
            data.EndTime = LocalDateTime.now().plusYears(1);
            data.Name = "pname" + Integer.toString(i + 1);
            data.TZ1 = 1;
            data.TZ2 = 1;
            data.TZ3 = 1;
            data.TZ4 = 1;
            data.CardNo = 2000 + i;
            data.Pin = 8000 + Integer.toString(i + 1);

            byte[] cmdbuf = StandTCPCmd.AddCard(data);
            pullCmd.AddPullCmd(false, cmdbuf);
        }
    }
}


// 控制器的当前状态
enum TCPWorkStatus {
    Close,
    Linked,
    Sending,
    OutTime,
    Faild,
    Finished
}

// 拉指令数据结构
class PullCmdData {
    public int ID;  // 指令ID，心跳通过该值判断 对应指令是否执行完成
    public byte[] CmdBytes;  // 指令数据
}

// 用于管理拉指令的类 ， 建议除了立即要执行的指令外，都使用拉指令，也就是都缓存在这里， 由心跳来执行
class PullCmd {
    private int IDNow = 0;

    // 指令队列，使用先进先出，但可以插入高优先级记录
    private List<PullCmdData> PullCmdList = new ArrayList<>();

    // 加入一个拉指令，等待执行，
    public void AddPullCmd(boolean priority, byte[] Cmd) {
        PullCmdData value = new PullCmdData();
        value.CmdBytes = Cmd;
        IDNow++;
        value.ID = IDNow;
        if (priority) {
            PullCmdList.add(0, value);// 高优先级插入
        } else
            PullCmdList.add(value);
    }

    // 由心跳来获取一个需要执行的指令
    public PullCmdData GetNextPullCmd(int lastid, boolean lastOK) {
        PullCmdData cmd;

        if (lastid > 0 && lastOK) {
            for (int i = 0; i < PullCmdList.size(); i++) {
                cmd = PullCmdList.get(i);
                if (cmd.ID == lastid) {
                    PullCmdList.remove(i);
                    break;
                }
            }
        }

        if (PullCmdList.size() > 0) {
            cmd = PullCmdList.get(0);
            return cmd;
        } else return null;
    }
}
