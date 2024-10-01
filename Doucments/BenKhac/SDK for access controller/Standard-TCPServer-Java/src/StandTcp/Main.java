package StandTcp;

import StandTcp.StandTcpController.LogCmdInterface;
import StandTcp.StandTcpController.StandTCPControllerManager;
import StandTcp.StandTcpController.StandTCPServer;
import StandTcp.StandTcpController.TCPController;
import StandTcp.StandTcpProtocol.TAcsTool;
import StandTcp.StandTcpProtocol.TCPCmdStruct;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.time.LocalDateTime;

// 主程序入口
public class Main {
    public static void main(String[] args) {
        AllClass allObj = new AllClass();
    }
}

class AllClass {
    StandTCPControllerManager AllController;



    // 创建所有对象，启动服务器
    public AllClass() {
        MainForm form = new MainForm();

        StandTCPTest test = new StandTCPTest();
        test.Test();

        AllController = new StandTCPControllerManager(form);

        AllController.AddControl("1S0049","name",(short) 23456);

        // 控制器web界面-网络界面上中，配置网络， 通信模式需要选择“设备作为客户端”。
        // 服务器端口 和此处的端口一致，  注意需要检查服务器电脑的防火墙，让它通过该端口。
        ServerTcpRun ServerTcp = new ServerTcpRun(AllController,8001);
        ServerTcp.start();
    }

    // 使用线程创建一个服务器运行
    class ServerTcpRun implements Runnable {
        private int Port ;
        private Thread t;
        private StandTCPControllerManager allControllers;

        ServerTcpRun(StandTCPControllerManager Server,int port) {
            allControllers = Server;
            Port = port;
        }

        public void run() {
            try {
                StandTCPServer dserver = new StandTCPServer(Port, allControllers);

                dserver.run();
            } catch (Exception e) {
                System.out.println("ServerTcpRun." + e.getMessage());
            }
        }

        public void start() {
            if (t == null) {
                t = new Thread(this, "ServerTcpRun");
                t.start();
            }
        }
    }

    // 界面类型
    class MainForm extends JFrame implements LogCmdInterface {
        JPanel ToolPanel = null;
        JScrollPane LogPanel = null;
        JTextArea LogText = null;

        JPanel ButtonPanel = null;
        JButton ButtonPara;
        JButton ButtonOpen,ButtonClose, ButtonPullOpenDoor, ButtonClear;
        JButton Button_PullAddCard, Button_AddCard, Button_AddCards, Button_ClearCards, Button_AddTZ;

        public MainForm() {
            AddFormObj();
            AddButtonClick();
        }

        public void ShowMsg(String Caption, String Msg) {
            String str = TAcsTool.GetNowTime() + " " + Caption + " = " + Msg;
            System.out.println(str);
            AddLog(str);
        }

        public void ShowCmdHex(String Caption, byte[] data) {
            String str = TAcsTool.Bytes2Hex(data);
            str = TAcsTool.GetNowTime() + " " + Caption + " = " + str;
            System.out.println(str);
            AddLog(str);
        }

        public  void ShowHeartEvent(TCPCmdStruct.RHeartStatus HeartStatus){
            String str = "";
            str += "时间:" + HeartStatus.Datetime.toString() + ",  ";
            str += "序列号:" + (HeartStatus.SerialNo) + ",  ";
           // str += "输入状态:" + TAcsTool.Short2Hex(HeartStatus.Input) + ", ";
            str += "门状态:" + TAcsTool.Bytes2Hex(HeartStatus.DoorStatus) + ",\r\n";

            ShowMsg("心跳数据", str);
            AddLog("\r\n");
        }

        public void ShowCardEvent(TCPCmdStruct.RCardEvent CardEvent){
            String str = "";
            str += "时间:" +    CardEvent.Datetime.toString() + ", ";
            str += "卡号:" +  (CardEvent.CardNo) + ", ";
            str += "事件:" + Integer.toString(CardEvent.EventType)+ "\r\n";
            ShowMsg("收到刷卡记录", str);
        }
        public void ShowAlarmEvent(TCPCmdStruct.RAlarmEvent AlarmEvent){
            String str = "";
            str += "时间:" +    AlarmEvent.Datetime.toString() + ",";
            str += "事件:" + Integer.toString(AlarmEvent.EventType)+ "\r\n";
            ShowMsg("收到报警记录", str);
        }

        public void SoftSendCmdHex(byte[] data) {
            ShowCmdHex("软件发送", data);
            AddLog("\r\n");
        }

        public void ContrlSendCmdHex(byte[] data) {
            ShowCmdHex("控制器发送", data);
        }

        public void AddLog(String str) {
            LogText.insert(str + "\r\n", 0);
        }

        private void AddButtonClick() {
            ButtonClear.addActionListener(new ActionListener() {
                @Override
                public void actionPerformed(ActionEvent e) {
                    LogText.setText("");
                }
            });

            ButtonOpen.addActionListener(new ActionListener() {
                @Override
                public void actionPerformed(ActionEvent e) {
                    TCPController Cntrl = AllController.GetController();
                    boolean re = false;
                    if (Cntrl != null) {
                        re = Cntrl.OpenDoor(false, (byte) 0);
                        AddLog(Cntrl.CmdResult());
                    }
                }
            });

            ButtonClose.addActionListener(new ActionListener() {
                @Override
                public void actionPerformed(ActionEvent e) {
                    TCPController Cntrl = AllController.GetController();
                    boolean re = false;
                    if (Cntrl != null) {
                        re = Cntrl.CloseDoor(false,(byte) 0);
                        AddLog(Cntrl.CmdResult());
                    }
                }
            });


            ButtonPullOpenDoor.addActionListener(new ActionListener() {
                @Override
                public void actionPerformed(ActionEvent e) {
                    TCPController Cntrl = AllController.GetController();
                    if (Cntrl != null) {
                        Cntrl.OpenDoor(true,(byte) 0);
                    }
                }
            });

            Button_AddTZ.addActionListener(new ActionListener() {
                @Override
                public void actionPerformed(ActionEvent e) {
                    TCPController Cntrl = AllController.GetController();
                    boolean re = false;
                    if (Cntrl != null) {
                        re = Cntrl.AddTimezone(false );
                        AddLog(Cntrl.CmdResult());
                    }
                }
            });

            Button_ClearCards.addActionListener(new ActionListener() {
                @Override
                public void actionPerformed(ActionEvent e) {
                    TCPController Cntrl = AllController.GetController();
                    if (Cntrl != null) {
                        Cntrl.ClearCards(false );
                        AddLog(Cntrl.CmdResult());
                    } else AddLog("没有活动控制器");
                }
            });

            Button_AddCard.addActionListener(new ActionListener() {
                @Override
                public void actionPerformed(ActionEvent e) {
                    TCPController Cntrl = AllController.GetController();
                    if (Cntrl != null) {
                        Cntrl.AddCard(false);
                        AddLog(Cntrl.CmdResult());
                    }
                }
            });

            Button_PullAddCard.addActionListener(new ActionListener() {
                @Override
                public void actionPerformed(ActionEvent e) {
                    TCPController Cntrl = AllController.GetController();
                    if (Cntrl != null) {
                        TCPCmdStruct.CardData data = new TCPCmdStruct.CardData();
                        data.Index = 0;
                        data.EndTime = LocalDateTime.now().plusYears(1);
                        data.Name = "姓名pull";
                        data.TZ1 = 1;
                        data.TZ2 = 1;
                        data.Pin = "888888";
                        data.CardNo = 444855280;

                        Cntrl.PullCmdAddCard(20);

                        Cntrl.PullCmdAddCard(data);
                    }
                }
            });

            Button_AddCards.addActionListener(new ActionListener() {
                @Override
                public void actionPerformed(ActionEvent e) {
                    TCPController Cntrl = AllController.GetController();
                    if (Cntrl == null) return;

                    TCPCmdStruct.CardData data = new TCPCmdStruct.CardData();
                    data.EndTime = LocalDateTime.now().plusYears(1);
                    data.TZ1 = 1;
                    data.TZ2 = 1;
                    data.TZ3 = 1;
                    data.TZ4 = 1;
                    data.Status = 1;
                    Boolean re;

                    int i;
                    int Len = 100;

                    for (i = 0; i < Len; i++) {
                        data.Index = i;
                        data.CardNo = i + 1 + 2000;
                        data.Pin = Integer.toString(i + 5000);
                        data.Name = "姓名" + Integer.toString(i + 1);

                        re = Cntrl.AddCards(i == (Len - 1), data);

                        AddLog("批量加卡 " + Integer.toString(i));

                        if (!re) {
                            AddLog("批量加卡失败 " + Integer.toString(i));
                            break;
                        }
                    }

                    AddLog(Cntrl.CmdResult());
                }
            });

            ButtonPara.addActionListener(new ActionListener() {
                @Override
                public void actionPerformed(ActionEvent e) {
                    TCPController Cntrl = AllController.GetController();
                    if (Cntrl != null) {
                        Cntrl.SetAllPara(true);
                        AddLog(Cntrl.CmdResult());
                    } else AddLog("没有活动控制器");
                }
            });
        }

        private void AddFormObj() {
            ButtonClear = new JButton("清除");
            ToolPanel = new JPanel();
            ToolPanel.add(ButtonClear);
            this.add(ToolPanel, BorderLayout.NORTH);

            LogText = new JTextArea();
            LogPanel = new JScrollPane(LogText);

            ButtonOpen = new JButton("开门");
            ButtonClose = new JButton("关门");
            Button_AddTZ = new JButton("加一个开放时间");
            Button_ClearCards = new JButton("删除全部卡");
            Button_AddCard = new JButton("加一个卡");
            Button_AddCards = new JButton("批量加卡");
            Button_PullAddCard = new JButton("Pull加卡");
            ButtonPullOpenDoor = new JButton("Pull开门");
            ButtonPara = new JButton("Pull更新参数");

            ButtonPanel = new JPanel();
            ButtonPanel.add(ButtonOpen);
            ButtonPanel.add(ButtonClose);
            ButtonPanel.add(Button_AddTZ);
            ButtonPanel.add(ButtonPara);
            ButtonPanel.add(Button_ClearCards);
            ButtonPanel.add(Button_AddCard);
            ButtonPanel.add(Button_AddCards);
            ButtonPanel.add(Button_PullAddCard);
            ButtonPanel.add(ButtonPullOpenDoor);

            this.add(LogPanel);
            this.add(ButtonPanel, BorderLayout.SOUTH);

            this.setLocation(600, 400);
            this.setSize(900, 550);
            this.setTitle("TCP控制器 通讯协议测试 java");
            this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            this.setVisible(true);
        }
    }
}