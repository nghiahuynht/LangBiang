package StandTcp.StandTcpController;

import StandTcp.StandTcpProtocol.StandTCPCmd;
import StandTcp.StandTcpProtocol.TAcsTool;

import StandTcp.StandTcpProtocol.TCPCmdStruct;
import io.netty.buffer.ByteBuf;
import io.netty.buffer.Unpooled;
import io.netty.channel.ChannelHandlerContext;
import io.netty.channel.SimpleChannelInboundHandler;
import java.time.LocalTime;
import java.util.*;


// 控制器管理类 管理所有的控制器
public class StandTCPControllerManager implements CardStatusInterface {
    // 如果控制器多，这里的ArrayList 请用更高效的管理模式。
    // 方便快速搜索和选择控制器。
    ArrayList<TCPController> list = new ArrayList<>();
    protected LogCmdInterface LogShow;

    public TCPLinkHandle LinkHandler() {
        return new TCPLinkHandle(this);
    }

    public StandTCPControllerManager(LogCmdInterface log) {
        LogShow = log;
    }

    private void Print(byte[] buf, String CmdName) {
        String str = TAcsTool.Bytes2Hex(buf);
        System.out.println(LocalTime.now().toString() + " " + CmdName + " = " + str);
    }

    // 更新所有其他相同group值的控制器里面，该卡的状态值
    public void SetCardStatus(String Serial, int group, short Index, byte status) {
        for (TCPController a : list) {
            if (a.Group == group)
                if (!a.SerialNo.equals(Serial)) {
                    a.pullCmd.AddPullCmd(true, StandTCPCmd.SetCardStatus(Index, status));
                }
        }
    }

    public TCPController GetController() {
        for (TCPController a : list) {
            if (a.WorkStatus != TCPWorkStatus.Close) {
                return a;
            }
        }
        return null;
    }

    public TCPController GetController(String serial) {
        for (TCPController a : list) {
            if (a.SerialNo.equals(serial) ) {
                return a;
            }
        }
        return null;
    }

    public  TCPController AddControl(String SerialNo, String name,short oemCode) {
        TCPController acs = new TCPController(this, LogShow);
        acs.SerialNo = SerialNo;
        acs.Name = name;
        acs.OEMCode = oemCode;
        list.add(acs);
        return acs;
    }
}

// 控制器接收通讯类
class TCPLinkHandle extends SimpleChannelInboundHandler<Object> {
    private TCPController Controller;
    StandTCPControllerManager allControllers;

    public TCPLinkHandle(StandTCPControllerManager value) {
        allControllers  = value;
    }

    @Override
    public void channelRead0(ChannelHandlerContext ctx, Object msg) throws Exception {
        ByteBuf in = (ByteBuf) msg;
        byte[] data = TAcsTool.ByteBufToBytes(in);

        allControllers.LogShow.ContrlSendCmdHex(data);
        if (!StandTCPCmd.CheckRxDataCS(data)) return ; // 校验接收的数据

        if (Controller == null)
        if(data[2] == (byte)0x56)
        {
            TCPCmdStruct.RHeartStatus vStatus = StandTCPCmd.HeartBuf2Struct(data);
            if (vStatus != null)
            {
                Controller = allControllers.GetController(vStatus.SerialNo);
                if (Controller == null)
                {
                    //Controller = allControllers.AddControl(vStatus.SerialNo, vStatus.SerialNo,(short)0);
                }
            }
        }
        if (Controller == null) return;

        byte[] cmdbuf = Controller.TcpLink(data, ctx);
        if (cmdbuf == null) return;

        ByteBuf buf = Unpooled.wrappedBuffer(cmdbuf);
        Controller.LogShow.SoftSendCmdHex(cmdbuf);
        ctx.writeAndFlush(buf);//将接受到的消息写给发送者，而不冲刷出站消息·
    }

    @Override
    public void exceptionCaught(ChannelHandlerContext ctx, Throwable cause) {
        // Close the connection when an exception is raised.
     //   cause.printStackTrace();
        ctx.pipeline().removeFirst();
        ctx.close();
    }
}



