using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using TcpClass.Controller;

namespace TcpipIntface
{
    public partial class Form1 : Form
    {
        Int32 ShowIndex = 0;

        TTCPController TCPClientWorker;
        TTCPPullCommand PullTCPCmd;

        public Form1()
        {
            InitializeComponent();
            //Control.CheckForIllegalCrossThreadCalls =  false;
        }

        #region 实时记录  Event Data
        void EventHandler(RAcsEvent Event, TTCPControllerBase  Object)
        {
            string dt = Event.Datetime.ToString();
            switch (Event.EType)
            {
                // card event 
                case 1:
                    ShowMsg("");

                    //  ShowMsg("SerialNo  : " + Event.SerialNo);
                    ShowMsg("Card      : " + Event.Value.ToString());
                    ShowMsg("EventType : " + Event.EventType.ToString());
                    ShowMsg("Door      : " + Event.Door.ToString());
                    ShowMsg("Time      : " + dt);
                    ShowMsg("Card Event");
                    ShowMsg("");
                    break;

                //alarm
                case 2:
                    ShowMsg("");
                    //  ShowMsg("SerialNo  : " + Event.SerialNo);
                    ShowMsg("EventType : " + Event.EventType.ToString());
                    ShowMsg("Time      : " + dt);
                    ShowMsg("Alarm Event");
                    ShowMsg("");
                    break;

                case 3:
                    ShowMsg("");
                    //  ShowMsg("Time      : " + dt);
                    // ShowMsg("SerialNo  : " + Event.SerialNo);
                    ShowMsg("CardIndex : " + Event.CardIndex.ToString());
                    ShowMsg("Value     : " + Event.AntiPassBackValue.ToString());
                    ShowMsg("Anti passback Event");
                    ShowMsg("");

                    // send the APB data to other controller;
                    PullTCPCmd.SetCardAPB(Event.CardIndex, Event.AntiPassBackValue);


                    setmsg();
                    break;
            }
        }

        void StatusHandler(RAcsStatus Event, TTCPControllerBase Object)
        {
            if (Event.IndexCmd == 0)
            {
                TimeSpan ds = DateTime.Now - Event.Datetime;
                if (System.Math.Abs(ds.Seconds) >= 10) // 10 must more then the heart time;
                {
                    PullTCPCmd.SetTime(DateTime.Now.AddSeconds(4)); // becase the pull commmand will be run later, so add some seconds
                    setmsg();
                }
            }

            string dt = Event.Datetime.ToString();
            ShowMsg("");
            ShowMsg("DoorStatus  :" + Event.DoorStatus.ToString() + ",Version:" + Event.Version.ToString() + ",SystemOption:" + Event.SystemOption.ToString());
            ShowMsg("SerialNo    : " + Event.SerialNo +  "  Input :" + Event.Input.ToString("X2"));
            ShowMsg("Time        : " + dt);
            ShowMsg("");
        }
        #endregion

        #region 调试信息 debug information
        private delegate void ThreadShowConnectMsg(string st);
        void ShowConnectMsg(string str)
        {
            if (this.InvokeRequired)
            {
                ThreadShowConnectMsg fc = new ThreadShowConnectMsg(ShowMsg);
                this.BeginInvoke(fc, new object[] { str });
            }
            else
            {
                label2.Text = str;
            }
        }

        private delegate void ThreadShowMsg(string st);
        void ShowMsg(string str)
        {
            if (this.InvokeRequired)
            {
                ThreadShowMsg fc = new ThreadShowMsg(ShowMsg);
                this.BeginInvoke(fc, new object[] { str });
            }
            else
            {
                ShowIndex++;
                listBox1.BeginUpdate();
                listBox1.Items.Insert(0, str);
                listBox1.EndUpdate();
                PullcmdNumLabel.Text = PullTCPCmd.GetPullCmdNum().ToString();
            }
        }

        void EventSocketConnected(bool link)
        {
            if (link)
                ShowConnectMsg("连接 link");
            else ShowConnectMsg("断开 unlink ");

            if (!link) ShowMsg("状态:false");
        }

        private delegate void TShowHexMsg(byte[] buff, int len, string st);
        void ShowHexMsg(byte[] buff, int len, string str)
        {
            byte[] returnBytes = new byte[len];
            Array.ConstrainedCopy(buff, 0, returnBytes, 0, len);
            string Hex = BitConverter.ToString(returnBytes).Replace("-", " ");

            if (this.InvokeRequired)//等待异步 
            {
                TShowHexMsg fc = new TShowHexMsg(ShowHexMsg);
                this.BeginInvoke(fc, new object[] { buff, len, str });//通过代理调用刷新方法 
            }
            else
            {
                ShowIndex++;
                str = string.Concat(ShowIndex.ToString(), "  " + str, Hex);
                listBox1.BeginUpdate();
                listBox1.Items.Insert(0, " ");
                listBox1.Items.Insert(0, str);
                listBox1.EndUpdate();
                LogLabel.Text = ShowIndex.ToString();
            }
        }

        void OnRxTxDataHandler(byte[] buff, int len, bool isSend)
        {
            if (isSend)
                ShowHexMsg(buff, len, " Send:");
            else
                ShowHexMsg(buff, len, " Rec:");
        }

        void setmsg()
        {
            ResultLabel.Text = "";
            PullcmdNumLabel.Text = PullTCPCmd.GetPullCmdNum().ToString();
        }

        void showResult(Boolean result, byte lasterror)
        {
            string msg = "成功 OK ";

            if (!result)
            {
                msg = "";
                switch (lasterror)
                {
                    case 1: msg = "对象不存在 NotExists"; break;
                    case 2: msg = "数据超出边界 DataErr"; break;
                    case 3: msg = "操作超时 OutTime"; break;
                    case 4: msg = "断开 UnLink "; break;
                    case 5: msg = "返回数据错误 Receive data error"; break;
                    default:
                        msg = "未知错误 Unknow error"; break;
                }
            }
            ResultLabel.Text = msg;
        }

        void ShowPress(UInt32 step, int max)
        {
            progressBar.Value = Convert.ToInt32(step);
            //   progressBar1.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TCPClientWorker.TCPNet.IsConnectSuccess())
                label2.Text = "online";
            else label2.Text = "offline";
        }
        #endregion

        #region 初始化 Initialization system
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxTZIdentify.SelectedIndex = 0;
            comboBoxMCardDir.SelectedIndex = 2;

            PullTCPCmd = new TTCPPullCommand();

            ITCPNet Net = new ClassTcpClientWorker();
            Net.OnRxTxDataEvent += OnRxTxDataHandler;
            Net.OnSocketConnected += EventSocketConnected;

            TCPClientWorker = new TTCPController(Net, PullTCPCmd);
            TCPClientWorker.OnEventHandler += EventHandler;
            TCPClientWorker.OnStatusHandler += StatusHandler;

            TCPClientWorker.OnGetPullCommandData += OnGetPullCommandData;
        }

        private delegate void TOnGetPullCommandData(byte[] CmdData, UInt32 Index);
        public void OnGetPullCommandData(byte[] CmdData, UInt32 Index)
        {
            int len = CmdData.Length;

            byte[] returnBytes = new byte[len];
            Array.ConstrainedCopy(CmdData, 0, returnBytes, 0, len);
            string Hex = BitConverter.ToString(returnBytes).Replace("-", " ");

            if (this.InvokeRequired)
            {
                TOnGetPullCommandData fc = new TOnGetPullCommandData(OnGetPullCommandData);
                this.BeginInvoke(fc, new object[] { CmdData, Index });
            }
            else
            {
                string str = string.Concat(Index.ToString(), "  ", Hex);
                listBox2.BeginUpdate();
                //  listBox2.Items.Insert(0, " ");
                listBox2.Items.Insert(0, str);
                listBox2.EndUpdate();
            }
        }
        #endregion

        #region 网络 network
        private void button1_Click(object sender, EventArgs e)
        {
            int port = Convert.ToUInt16(textBox2.Text);
            TCPClientWorker.OpenIP(textBox1.Text, port, Convert.ToUInt16(textBoxoem.Text));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Boolean re = false;
            setmsg();
            re = TCPClientWorker.CloseTcpip();
            showResult(re, TCPClientWorker.LastError());
        }
        #endregion

        #region 标准指令 Standard Command

        #region 系统控制 system command
        private void button40_Click(object sender, EventArgs e)
        {
            Boolean re = false;
            setmsg();
            re = TCPClientWorker.SetTime(DateTime.Now);
            showResult(re, TCPClientWorker.LastError());
        }

        private void button41_Click(object sender, EventArgs e)
        {
            Boolean re = false;
            setmsg();
            re = TCPClientWorker.Reset();
            showResult(re, TCPClientWorker.LastError());
        }
        #endregion

        #region 控制指令 Control command

        private void button2_Click(object sender, EventArgs e)
        {
            Boolean re = false;
            setmsg();
            re = TCPClientWorker.OpenDoor(0);
            showResult(re, TCPClientWorker.LastError());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Boolean re = false;
            setmsg();
            re = TCPClientWorker.CloseDoor(0);
            showResult(re, TCPClientWorker.LastError());
        }
        private void button21_Click(object sender, EventArgs e)
        {
            Boolean re = false;
            setmsg();
            re = TCPClientWorker.OpenDoor(1);
            showResult(re, TCPClientWorker.LastError());
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Boolean re = false;
            setmsg();
            re = TCPClientWorker.CloseDoor(1);
            showResult(re, TCPClientWorker.LastError());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Boolean re = false;
            setmsg();
            re = TCPClientWorker.SetAlarm(false, false);
            showResult(re, TCPClientWorker.LastError());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Boolean re = false;
            setmsg();
            re = TCPClientWorker.SetAlarm(true, false);
            showResult(re, TCPClientWorker.LastError());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Boolean re = false;
            setmsg();
            re = TCPClientWorker.SetFire(false, false);
            showResult(re, TCPClientWorker.LastError());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Boolean re = false;
            setmsg();
            re = TCPClientWorker.SetFire(true, false);
            showResult(re, TCPClientWorker.LastError());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Boolean re = false;
            setmsg();
            re = TCPClientWorker.LockDoor(1, true);
            showResult(re, TCPClientWorker.LastError());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Boolean re = false;
            setmsg();
            re = TCPClientWorker.LockDoor(1, false);
            showResult(re, TCPClientWorker.LastError());
        }
        #endregion

        #region 加卡 Add Card
        private void button36_Click(object sender, EventArgs e)
        {
            Boolean re = false;
            setmsg();

            string card = textBoxCard2.Text.Trim();
            if (string.IsNullOrEmpty(card)) card = "0";
            string cardindex = textBoxCardIndex2.Text.Trim();
            if (string.IsNullOrEmpty(cardindex)) cardindex = "0";

            UInt32 Index = Convert.ToUInt32(cardindex);
            UInt32 Card = Convert.ToUInt32(card);

            string Name = textBoxName2.Text;


            DateTime endDate = dateTimePickerEndDate2.Value;
            TimeSpan endTime = dateTimePickerEndTime2.Value.TimeOfDay;

            UInt16 lvl = 1, Tz = 0;
            foreach (Control c in groupBox4.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox box = (CheckBox)c;
                    {
                        int lv = Convert.ToUInt16(box.Text);
                        lv--;
                        if (box.Checked) Tz |= Convert.ToUInt16(lvl << lv);
                    }
                }
            }

            re = TCPClientWorker.AddCard1Door(TCPClientWorker.SystemOption, Index, Name, Card, textBoxPin2.Text, Tz, endDate.AddSeconds(endTime.TotalSeconds));
            showResult(re, TCPClientWorker.LastError());
        }

        private void button37_Click(object sender, EventArgs e)
        {
            Boolean re = false;
            setmsg();
            progressBar.Maximum = 200;
            for (UInt32 i = 0; i < 200; i++)
            {
                re = TCPClientWorker.AddCard1Door(TCPClientWorker.SystemOption, i, "A", (i + 1), "1234", 1, DateTime.Now.AddDays(1));
                ShowPress(i, 200);
                if (!re) break;
            }
            showResult(re, TCPClientWorker.LastError());
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Boolean re = false; UInt16 i;
            int Len = 1000;
            setmsg();
            progressBar.Maximum = Len;
            for (i = 0; i < Len; i++)
            {
                Thread.Sleep(1);
                re = TCPClientWorker.AddCards(TCPClientWorker.SystemOption, TCPClientWorker.CardNumInPack, i == (Len - 1), i, "A", Convert.ToUInt32(i + 1 + 2000), "1234", 1, 1, 1, 1, DateTime.Now.AddDays(1));
                ShowPress(i, Len);
                if (!re) break;
            }
            showResult(re, TCPClientWorker.LastError());
        }


        private void button38_Click(object sender, EventArgs e)
        {
            Boolean re = false;
            setmsg();
            re = TCPClientWorker.ClearAllCards();
            showResult(re, TCPClientWorker.LastError());
        }
        #endregion

        #region 参数 Parameter Command
        private void button35_Click(object sender, EventArgs e)
        {
            Boolean re = false;
            setmsg();

            UInt16 AlarmFire = Convert.ToUInt16(textBoxFireTime.Text);
            UInt16 AlarmExp = Convert.ToUInt16(textBoxCAlarmTime.Text);
            string Duresspin = textBoxDPIN.Text;

            re = TCPClientWorker.SetControl(TCPClientWorker.SystemOption, AlarmFire, AlarmExp, Duresspin.Trim(), 0);
            showResult(re, TCPClientWorker.LastError());
        }

        private void button34_Click(object sender, EventArgs e)
        {
            Boolean re = false;
            setmsg();

            UInt16 OpenTime = Convert.ToUInt16(textBoxOpenTime.Text);
            byte OutTime = Convert.ToByte(textBoxOutTime.Text);
            Boolean ToolongAlarm = checkBoxRecOutTime.Checked;
            Boolean DoublePath = true;

            Boolean ADoor = checkBoxAlarm_Door.Checked;
            Boolean ALong = checkBoxAlarm_2Loog.Checked;
            Boolean ACard = checkBoxAlarm_VCard.Checked;
            Boolean ATime = checkBoxAlarm_VTime.Checked;

            byte AlarmMask = 0;
            if (ADoor) AlarmMask |= 0x01;
            if (ALong) AlarmMask |= 0x02;
            if (ACard) AlarmMask |= 0x04;
            if (ATime) AlarmMask |= 0x08;
            UInt16 AlarmTime = Convert.ToUInt16(textBoxAlarmTime.Text);

            byte MCards = Convert.ToByte(textBoxMCards.Text);
            byte MCardsInOut = Convert.ToByte(comboBoxMCardDir.SelectedIndex);
            MCardsInOut++;

            re = TCPClientWorker.SetDoor(0, OpenTime, OutTime, DoublePath, ToolongAlarm, AlarmMask, AlarmTime, MCards, MCardsInOut);
            showResult(re, TCPClientWorker.LastError());
        }

        private void button42_Click(object sender, EventArgs e)
        {
            Boolean re = false;
            setmsg();
            re = TCPClientWorker.DelTimeZone(0);
            showResult(re, TCPClientWorker.LastError());
        }

        private void button39_Click(object sender, EventArgs e)
        {
            Boolean re = false;
            setmsg();
            Boolean w1 = checkBoxw1.Checked;
            Boolean w2 = checkBoxw2.Checked;
            Boolean w3 = checkBoxw3.Checked;
            Boolean w4 = checkBoxw4.Checked;
            Boolean w5 = checkBoxw5.Checked;
            Boolean w6 = checkBoxw6.Checked;
            Boolean w7 = checkBoxw7.Checked;
            Boolean w8 = checkBoxw8.Checked;
            Boolean APB = this.checkBoxAPB.Checked;

            byte Week = 0;
            if (w7) Week |= 0x01;
            if (w1) Week |= 0x02;
            if (w2) Week |= 0x04;
            if (w3) Week |= 0x08;
            if (w4) Week |= 0x10;
            if (w5) Week |= 0x20;
            if (w6) Week |= 0x40;
            if (w8) Week |= 0x80;

            byte side = 0;
            int intIdentify = comboBoxTZIdentify.SelectedIndex;

            switch (intIdentify)
            {
                case 0:
                    side = 0x01;
                    break;
                case 1:
                    side = 0x02;
                    break;
                case 2:
                    side = 0x03;
                    break;
                case 3:
                    side = 0x04;
                    break;
                case 4:
                    side = 0x07;
                    break;
                case 5:
                    side = 0x08;
                    break;
                case 6:
                    side = 0x09;
                    break;
                case 7:
                    side = 0x10;
                    break;
                case 8:
                    side = 0x11;
                    break;
            }

            re = TCPClientWorker.AddTimeZone(Convert.ToByte(textBoxTZDoorIndex.Text), Convert.ToByte(textBoxTZIndex.Text), dateTimePickerTZ1.Value, dateTimePickerTZ2.Value,
                    Week, APB, side, dateTimePickerTZEnd.Value, Convert.ToByte(textBoxTZGroup.Text));

            showResult(re, TCPClientWorker.LastError());
        }
        #endregion

        #endregion

        #region 拉指令 pull command

        private void button30_Click(object sender, EventArgs e)
        {
            PullTCPCmd.OpenDoor(0);
            setmsg();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PullTCPCmd.Reset();
            setmsg();
        }

        #region 参数 Parameter Command
        private void button5_Click(object sender, EventArgs e)
        {
            PullTCPCmd.SetTime(DateTime.Now);
            setmsg();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            UInt16 AlarmFire = Convert.ToUInt16(textBoxFireTime.Text);
            UInt16 AlarmExp = Convert.ToUInt16(textBoxCAlarmTime.Text);
            string Duresspin = textBoxDPIN.Text;

            PullTCPCmd.SetControl(TCPClientWorker.SystemOption, AlarmFire, AlarmExp, Duresspin.Trim(), 0);
            setmsg();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            UInt16 OpenTime = Convert.ToUInt16(textBoxOpenTime.Text);
            byte OutTime = Convert.ToByte(textBoxOutTime.Text);
            Boolean ToolongAlarm = checkBoxRecOutTime.Checked;
            Boolean DoublePath = true;

            Boolean ADoor = checkBoxAlarm_Door.Checked;
            Boolean ALong = checkBoxAlarm_2Loog.Checked;
            Boolean ACard = checkBoxAlarm_VCard.Checked;
            Boolean ATime = checkBoxAlarm_VTime.Checked;

            byte AlarmMask = 0;
            if (ADoor) AlarmMask |= 0x01;
            if (ALong) AlarmMask |= 0x02;
            if (ACard) AlarmMask |= 0x04;
            if (ATime) AlarmMask |= 0x08;
            UInt16 AlarmTime = Convert.ToUInt16(textBoxAlarmTime.Text);

            byte MCards = Convert.ToByte(textBoxMCards.Text);
            byte MCardsInOut = Convert.ToByte(comboBoxMCardDir.SelectedIndex);
            MCardsInOut++;

            PullTCPCmd.SetDoor(0, OpenTime, OutTime, DoublePath, ToolongAlarm, AlarmMask, AlarmTime, MCards, MCardsInOut);

            setmsg();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            PullTCPCmd.DelTimeZone(0);
            setmsg();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            setmsg();
            Boolean w1 = checkBoxw1.Checked;
            Boolean w2 = checkBoxw2.Checked;
            Boolean w3 = checkBoxw3.Checked;
            Boolean w4 = checkBoxw4.Checked;
            Boolean w5 = checkBoxw5.Checked;
            Boolean w6 = checkBoxw6.Checked;
            Boolean w7 = checkBoxw7.Checked;
            Boolean w8 = checkBoxw8.Checked;
            Boolean APB = this.checkBoxAPB.Checked;

            byte Week = 0;
            if (w7) Week |= 0x01;
            if (w1) Week |= 0x02;
            if (w2) Week |= 0x04;
            if (w3) Week |= 0x08;
            if (w4) Week |= 0x10;
            if (w5) Week |= 0x20;
            if (w6) Week |= 0x40;
            if (w8) Week |= 0x80;

            byte side = 0;
            int intIdentify = comboBoxTZIdentify.SelectedIndex;

            switch (intIdentify)
            {
                case 0:
                    side = 0x01;
                    break;
                case 1:
                    side = 0x02;
                    break;
                case 2:
                    side = 0x03;
                    break;
                case 3:
                    side = 0x04;
                    break;
                case 4:
                    side = 0x07;
                    break;
                case 5:
                    side = 0x08;
                    break;
                case 6:
                    side = 0x09;
                    break;
                case 7:
                    side = 0x10;
                    break;
                case 8:
                    side = 0x11;
                    break;
            }

            PullTCPCmd.AddTimeZone(Convert.ToByte(textBoxTZDoorIndex.Text), Convert.ToByte(textBoxTZIndex.Text), dateTimePickerTZ1.Value, dateTimePickerTZ2.Value,
                   Week, APB, side, dateTimePickerTZEnd.Value, Convert.ToByte(textBoxTZGroup.Text));
            setmsg();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Boolean re = false;
            byte[] data = new byte[6] { 0x31, 0x32, 0x33, 0x31, 0x32, 0x33 };
            setmsg();
            re = TCPClientWorker.SendTo485(data);
            showResult(re, TCPClientWorker.LastError());
        }
        #endregion

        #region 加卡 Add Card
        private void button16_Click(object sender, EventArgs e)
        {
            progressBar.Maximum = 200;
            for (UInt32 i = 0; i < 200; i++)
            {
                PullTCPCmd.AddCard1Door(TCPClientWorker.SystemOption, i, "A", (i + 1), "1234", 1, DateTime.Now.AddDays(1));
                ShowPress(i, 200);
            }
            setmsg();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            PullTCPCmd.ClearAllCards();
            setmsg();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string card = textBoxCard.Text.Trim();
            if (string.IsNullOrEmpty(card)) card = "0";
            string cardindex = textBoxIndex.Text.Trim();
            if (string.IsNullOrEmpty(cardindex)) cardindex = "0";

            UInt32 Index = Convert.ToUInt32(cardindex);
            UInt32 Card = Convert.ToUInt32(card);

            string Name = textBoxName1.Text;

            DateTime endDate = dateTimePickerCardEnd.Value;
            TimeSpan endTime = dateTimePickerCardEndTime.Value.TimeOfDay;

            UInt16 lvl = 1, Tz = 0;
            foreach (Control c in groupBox3.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox box = (CheckBox)c;
                    {
                        int lv = Convert.ToUInt16(box.Text);
                        lv--;
                        if (box.Checked) Tz |= Convert.ToUInt16(lvl << lv);
                    }
                }
            }

            PullTCPCmd.AddCard1Door(TCPClientWorker.SystemOption, Index, Name, Card, textBoxPin1.Text, Tz, endDate.AddSeconds(endTime.TotalSeconds));
            setmsg();
        }
        #endregion
        #endregion

        #region 显示数据 show data
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox1.Items.Count > 0)
                if (listBox1.SelectedItem != null)
                    Clipboard.SetDataObject(listBox1.SelectedItem.ToString());
        }
        private void listBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox2.Items.Count > 0)
                if (listBox2.SelectedItem != null)
                    Clipboard.SetDataObject(listBox2.SelectedItem.ToString());
        }

        private void button25_Click(object sender, EventArgs e)
        {
            this.listBox2.Items.Clear();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            ShowIndex = 0;
            LogLabel.Text = ShowIndex.ToString();
        }

        #endregion

        private void button26_Click(object sender, EventArgs e)
        {
          //  string value = textBox2.Text;
          //  TCPClientWorker.SendBuffer(value); 
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button26_Click_1(object sender, EventArgs e)
        {
            Boolean re = false;
            setmsg();              
            string cardindex = textBoxCardIndex2.Text.Trim();
            if (string.IsNullOrEmpty(cardindex)) cardindex = "0";

            UInt32 Index = Convert.ToUInt32(cardindex); 

            re = TCPClientWorker.AddCard1Door(TCPClientWorker.SystemOption, Index, "", 0, "0", 0, DateTime.Now);
           // re = TCPClientWorker.DeleteCard(TCPClientWorker.SystemOption, Index);

            showResult(re, TCPClientWorker.LastError());
        } 
    }
}
