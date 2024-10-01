using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TcpStandard_Server.StandTcpController;
using TcpStandard_Server.StandTcpProtocol;

namespace TcpStandard_Server
{
    public partial class Form1 : Form
    {
        EventHandle eventHandle = new EventHandle();
        StandTCPControllerManager AllController;
        StandardTCPServer ServerTcp;
        // TAllTest AllTest;

        #region 初始化
        public Form1()
        {
            InitializeComponent();

            CreateAllClass();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        // 创建所有对象，启动服务器
        public void CreateAllClass()
        {
            eventHandle.OnShowAlarmEvent += EventHandle_OnShowAlarmEvent;
            eventHandle.OnShowCardEvent += EventHandle_OnShowCardEvent;
            eventHandle.OnShowHeartEvent += EventHandle_OnShowHeartEvent;
            eventHandle.OnAddLog += AddLog;
            eventHandle.OnShowPullCmd += ShowPullCmd;
            eventHandle.OnShowNetChange += ShowNetChange;
            AllController = new StandTCPControllerManager(eventHandle);

            AllController.AddControl("1E0050", "name");
            AllController.AddControl("118130", "118130");

            // 控制器web界面-网络界面上中，配置网络， 通信模式需要选择“设备作为客户端”。
            // 服务器端口 和此处的端口一致，  注意需要检查服务器电脑的防火墙，让它通过该端口。
            ServerTcp = new StandardTCPServer(AllController);
            ServerTcp.onServerStatus += OnServerStatus;
        }
        #endregion

        #region 显示
        Boolean GetSelectSerail(out string serialno)
        {
            serialno = "";
            if (0 == listView1.Items.Count) return false;

            if (listView1.SelectedItems.Count > 0)
            {
                serialno = listView1.SelectedItems[0].Text;
                return true;
            }
            else return false;
        }

        TCPController GetController()
        {
            string serial = "";
            GetSelectSerail(out serial);
            TCPController c = AllController.GetController(serial);
            if (c != null) return c;
            ShowMsg("错误", "没有选择控制器");
            return null;
        }

        void UpdateControlMsg(string serial, string status)
        {
            listView1.BeginUpdate();
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                ListViewItem item = listView1.Items[i];
                if (item.Text == serial)
                {
                    listView1.Items[i].SubItems[1].Text = status;
                }
            }
            listView1.EndUpdate();
        }

        void ShowAllController()
        {
            listView1.Items.Clear();
            listView1.BeginUpdate();
            foreach (TCPController ctrl in AllController.Controllerlist)
            {
                ListViewItem item = new ListViewItem();
                item.Text = ctrl.SerialNo;
                item.SubItems.Add(ctrl.Online.ToString());
                listView1.Items.Add(item);
            }
            listView1.EndUpdate();
        }

        void ShowNetChange(TCPController controller)
        {
            if (this.InvokeRequired)
            {
                TOnShowNetChange fc = new TOnShowNetChange(ShowNetChange);
                this.BeginInvoke(fc, new object[] { controller });
            }
            else
            {
                if (AllController.Controllerlist.Count != listView1.Items.Count)
                {
                    ShowAllController();
                }
                else
                {
                    UpdateControlMsg(controller.SerialNo, controller.Online.ToString());
                }
            }
        }

        void ShowPress(UInt32 step, int max)
        {
            progressBar.Value = Convert.ToInt32(step);
        }

        private void EventHandle_OnShowHeartEvent(RHeartStatus HeartStatus, TCPController controller)
        {
            String str = "";
            str += "时间:" + HeartStatus.Datetime.ToString() + ",  ";
            str += "序列号:" + (HeartStatus.SerialNo) + ",  ";
            // str += "输入状态:" + TAcsTool.Short2Hex(HeartStatus.Input) + ", ";
            str += "门状态:" + TAcsTool.Bytes2Hex(HeartStatus.DoorStatus) + ",\r\n";

            ShowMsg("心跳数据", str);
            AddLog("\r\n");
        }

        private void EventHandle_OnShowCardEvent(RCardEvent CardEvent, TCPController controller)
        {
            String str = "";
            str += "时间:" + CardEvent.Datetime.ToString() + ", ";
            str += "卡号:" + (CardEvent.CardNo) + ", ";
            str += "事件:" + (CardEvent.EventType.ToString()) + "\r\n";
            ShowMsg("收到刷卡记录", str);
        }

        private void EventHandle_OnShowAlarmEvent(RAlarmEvent AlarmEvent, TCPController controller)
        {
            String str = "";
            str += "时间:" + AlarmEvent.Datetime.ToString() + ",";
            str += "事件:" + (AlarmEvent.EventType.ToString()) + "\r\n";
            ShowMsg("收到报警记录", str);
        }

        private void OnServerStatus(Boolean Active, String str)
        {
            if (this.InvokeRequired)
            {
                TOnServerStatus fc = new TOnServerStatus(OnServerStatus);
                this.BeginInvoke(fc, new object[] { Active, str });
            }
            else
            {
                buttonStart.Enabled = !Active;
                buttonStop.Enabled = Active;

                listBox1.BeginUpdate();
                if (Active)
                    listBox1.Items.Insert(0, "服务器启动成功");
                else
                    listBox1.Items.Insert(0, "服务器关闭");
                listBox1.EndUpdate();
            }
        }

        private void ShowMsg(String Caption, String Msg)
        {
            String str = TAcsTool.GetNowTime() + " " + Caption + " = " + Msg;
           // System.Console.WriteLine(str);
            AddLog(str);
        }

        private void AddLog(String str)
        {
            if (this.InvokeRequired)
            {
                TOnAddLog fc = new TOnAddLog(AddLog);
                this.BeginInvoke(fc, new object[] { str });
            }
            else
            {
                listBox1.BeginUpdate();
                listBox1.Items.Insert(0, str);
                listBox1.EndUpdate();
            }
        }

        private void ShowPullCmd(byte[] data, int num)
        {
            if (this.InvokeRequired)
            {
                TOnShowPullCmd fc = new TOnShowPullCmd(ShowPullCmd);
                this.BeginInvoke(fc, new object[] { data, num });
            }
            else
            {
                string str = "";
                if (data != null)
                {
                    str = DateTime.Now.ToLongTimeString() + "  拉指令执行中： " + TAcsTool.Bytes2Hex(data);
                    listBox2.BeginUpdate();
                    listBox2.Items.Insert(0, str);
                    listBox2.EndUpdate();
                }
                PullcmdNumLabel.Text = num.ToString();
            }
        }

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

        private void button17_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }
        #endregion

        #region 服务器
        private void button1_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            Boolean isTls = checkBoxTLS.Checked;
            Boolean isMqttBin = checkBoxMqtt.Checked;
            int port = Convert.ToUInt16(textBox2.Text);
            UInt16 OemCode = Convert.ToUInt16(textBoxoem.Text);

            AllController.SetOemCode(OemCode);

            ServerTcp.Start(port,  isTls,   isMqttBin);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            buttonStop.Enabled = false;
            ServerTcp.Stop();
        }
        #endregion

        #region 控制指令
        private void button2_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            controller.OpenDoor(false, 0);

            ShowMsg("OpenDoor", controller.CmdResult());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            controller.CloseDoor(false, 0);

            ShowMsg("CloseDoor", controller.CmdResult());
        }

        private void button21_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            controller.OpenDoor(false, 1);
            ShowMsg("OpenDoor", controller.CmdResult());
        }

        private void button20_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            controller.CloseDoor(false, 1);
            ShowMsg("CloseDoor", controller.CmdResult());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            controller.SetAlarm(false, true);
            ShowMsg("SetAlarm", controller.CmdResult());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            controller.SetAlarm(false, false);
            ShowMsg("SetAlarm", controller.CmdResult());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            controller.SetFire(false, true);
            ShowMsg("SetFire", controller.CmdResult());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            controller.SetFire(false, false);
            ShowMsg("SetFire", controller.CmdResult());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            controller.LockDoor(false, 0, true);
            ShowMsg("LockDoor", controller.CmdResult());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            controller.LockDoor(false, 0, false);
            ShowMsg("LockDoor", controller.CmdResult());
        }

        private void button30_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            controller.OpenDoor(true, 0);
            ShowMsg("OpenDoor", controller.CmdResult());
        }
        #endregion

        #region 系统指令
        private void button40_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            controller.SetSystemTime(false, DateTime.Now);
            ShowMsg("SetSystemTime", controller.CmdResult());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            controller.SetSystemTime(true, DateTime.Now);
            ShowMsg("SetSystemTime", controller.CmdResult());
        }

        private void button41_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            controller.Reset(false);
            ShowMsg("Reset", controller.CmdResult());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            controller.Restart(false);
            ShowMsg("Restart", controller.CmdResult());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            controller.Reset(true);
            ShowMsg("Reset", controller.CmdResult());
        }
        #endregion

        #region 参数
        private void button35_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            UInt16 FireTime = Convert.ToUInt16(textBoxFireTime.Text);
            UInt16 AlarmTime = Convert.ToUInt16(textBoxCAlarmTime.Text);
            string DuressPIN = textBoxDPIN.Text;
            byte LockEach = 0;
            controller.SetControl(false, FireTime, AlarmTime, DuressPIN, LockEach);
            ShowMsg("SetControl", controller.CmdResult());
        }

        private DoorPara GetDoorData()
        {
            DoorPara data = new DoorPara();

            data.OpenTime = Convert.ToUInt16(textBoxOpenTime.Text);
            data.OutTime = Convert.ToByte(textBoxOutTime.Text);
            data.ToolongAlarm = checkBoxRecOutTime.Checked;
            data.DoublePath = true;

            Boolean ADoor = checkBoxAlarm_Door.Checked;
            Boolean ALong = checkBoxAlarm_2Loog.Checked;
            Boolean ACard = checkBoxAlarm_VCard.Checked;
            Boolean ATime = checkBoxAlarm_VTime.Checked;

            byte AlarmMask = 0;
            if (ADoor) AlarmMask |= 0x01;
            if (ALong) AlarmMask |= 0x02;
            if (ACard) AlarmMask |= 0x04;
            if (ATime) AlarmMask |= 0x08;
            data.AlarmMask = AlarmMask;
            data.AlarmTime = Convert.ToUInt16(textBoxAlarmTime.Text);

            data.MCards = Convert.ToByte(textBoxMCards.Text);
            data.MCardsInOut = Convert.ToByte(comboBoxMCardDir.SelectedIndex &0xFF );
            data.MCardsInOut++;
            return data;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            byte door = Convert.ToByte(textBoxDoorIndex.Text);
            DoorPara data = GetDoorData();
            controller.SetDoor(false, door, data);
            ShowMsg("SetDoor", controller.CmdResult());
        }

        private void button28_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            UInt16 FireTime = Convert.ToUInt16(textBoxFireTime.Text);
            UInt16 AlarmTime = Convert.ToUInt16(textBoxCAlarmTime.Text);
            string DuressPIN = textBoxDPIN.Text;
            byte LockEach = 0;
            controller.SetControl(true, FireTime, AlarmTime, DuressPIN, LockEach);
            ShowMsg("SetControl", controller.CmdResult());
        }

        private void button27_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            byte door = Convert.ToByte(textBoxDoorIndex.Text);
            DoorPara data = GetDoorData();
            controller.SetDoor(true, door, data);
            ShowMsg("SetDoor", controller.CmdResult());
        }

        #region 开放时间
        private void button42_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            controller.DelTimeZone(false, 0);
            ShowMsg("DelTimeZone", controller.CmdResult());
        }

        private void button23_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            controller.DelTimeZone(true, 0);
            ShowMsg("DelTimeZone", controller.CmdResult());
        }

        private RTimeZone GetTZ()
        {
            RTimeZone data = new RTimeZone();

            data.Index = Convert.ToByte(textBoxTZDoorIndex.Text);
            data.FrmTime = dateTimePickerTZ1.Value;
            data.ToTime = dateTimePickerTZ2.Value;

            data.EndDate = dateTimePickerTZEnd.Value;
            data.Group = Convert.ToByte(textBoxTZGroup.Text);

            Boolean w1 = checkBoxw1.Checked;
            Boolean w2 = checkBoxw2.Checked;
            Boolean w3 = checkBoxw3.Checked;
            Boolean w4 = checkBoxw4.Checked;
            Boolean w5 = checkBoxw5.Checked;
            Boolean w6 = checkBoxw6.Checked;
            Boolean w7 = checkBoxw7.Checked;

            byte Week = 0;
            if (w7) Week |= 0x01;
            if (w1) Week |= 0x02;
            if (w2) Week |= 0x04;
            if (w3) Week |= 0x08;
            if (w4) Week |= 0x10;
            if (w5) Week |= 0x20;
            if (w6) Week |= 0x40;

            data.Week = Week;
            data.Holiday = checkBoxw8.Checked;
            data.APB = this.checkBoxAPB.Checked;

            byte side = 0;
            int intIdentify = comboBoxTZIdentify.SelectedIndex;
            switch (intIdentify)
            {
                case 0:
                    side = 0x01; break;
                case 1:
                    side = 0x02; break;
                case 2:
                    side = 0x03; break;
                case 3:
                    side = 0x04; break;
                case 4:
                    side = 0x07; break;
                case 5:
                    side = 0x08; break;
                case 6:
                    side = 0x09; break;
                case 7:
                    side = 0x10; break;
                case 8:
                    side = 0x11; break;
            }
            data.Indetify = side;

            return data;
        }

        private void button39_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            RTimeZone data = GetTZ();
            byte door = Convert.ToByte(textBoxTZDoorIndex.Text);
            controller.AddTimezone(false, door, data);
            ShowMsg("AddTimezone", controller.CmdResult());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            RTimeZone data = GetTZ();
            byte door = Convert.ToByte(textBoxTZDoorIndex.Text);
            controller.AddTimezone(true, door, data);
            ShowMsg("AddTimezone", controller.CmdResult());
        }
        #endregion
        #endregion

        #region 卡片管理
        private void button37_Click(object sender, EventArgs e)
        {
            Boolean re = false;
            progressBar.Maximum = 200;
            TCPController controller = GetController();
            if (null == controller) return;
            CardData1Door data = GetCardData();

            for (UInt32 i = 0; i < 200; i++)
            {
                data.Index = (UInt16)i;
                data.CardNo += i;
                data.Pin += i;

                re = controller.AddCard1Door(false, data);
                ShowMsg("AddCard1Door", controller.CmdResult());
                if (!re) break;
            }
            ShowMsg("AddCard1Door", "结束");
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Boolean re = false; UInt16 i;
            int Len = 20000;
              UInt16 DataLen=0;
            progressBar.Maximum = Len;
            TCPController controller = GetController();
            if (null == controller) return;
            CardData data = new CardData();

            for (i = 0; i < Len; i++)
            {
                data.Index = i;
                data.CardNo = (UInt32)(i + 1 + 2000);
                data.Pin = (i + 5000).ToString();
                data.Name = "姓名" + (i + 1).ToString();
                data.TZ1 = 1;
                data.TZ2 = 1;
                data.TZ3 = 1;
                data.TZ4 = 1;
                data.EndTime = DateTime.Now;

                Thread.Sleep(1);
                re = controller.AddCards(i >= (Len - 1), ref   DataLen, i, data);

                ShowPress(i, Len);
                if (!re) break;
            }

            if (!re)
            {
                AddLog("批量加卡失败 " + (i));
            }
            else AddLog("批量加卡 ");
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            string cardindex = textBoxCardIndex2.Text.Trim();
            if (string.IsNullOrEmpty(cardindex)) cardindex = "0";

            UInt16 Index = Convert.ToUInt16(cardindex);
            controller.DelCard(false, Index);
            ShowMsg("DelCard", controller.CmdResult());
        }

        private CardData1Door GetCardData()
        {
            CardData1Door data = new CardData1Door();

            string card = textBoxCard2.Text.Trim();
            if (string.IsNullOrEmpty(card)) card = "0";

            string cardindex = textBoxCardIndex2.Text.Trim();
            if (string.IsNullOrEmpty(cardindex)) cardindex = "0";

            DateTime endDate = dateTimePickerEndDate2.Value;
            TimeSpan endTime = dateTimePickerEndTime2.Value.TimeOfDay;

            data.Index = Convert.ToUInt16(cardindex);
            data.EndTime = endDate.AddSeconds(endTime.TotalSeconds);
            data.Name = textBoxName2.Text;
            data.CardNo = Convert.ToUInt32(card);
            data.Pin = textBoxPin2.Text.Trim();

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
            data.TZ = Tz;
            return data;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            CardData1Door data = GetCardData();

            string cardindex = textBoxCardIndex2.Text.Trim();
            if (string.IsNullOrEmpty(cardindex)) cardindex = "0";

            data.Index = Convert.ToUInt16(cardindex);

            controller.AddCard1Door(false, data);
            ShowMsg("AddCard1Door", controller.CmdResult());
        }

        private void button38_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            controller.ClearCards(false);
            ShowMsg("ClearCards", controller.CmdResult());
        }
        #endregion

        #region 拉指令- 卡片管理
        private void button16_Click(object sender, EventArgs e)
        {
            Boolean re = false;
            progressBar.Maximum = 200;

            TCPController controller = GetController();
            if (null == controller) return;

            CardData1Door data = GetPullCardData();

            for (UInt32 i = 0; i < 200; i++)
            {
                data.Index = (UInt16)i;
                data.CardNo += i;
                data.Pin += i;
                data.Name = "Pull" + i.ToString();

                re = controller.AddCard1Door(true, data);
                if (!re) break;
            }
            ShowMsg("AddCard1Door", "");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;
            controller.ClearCards(true);
            ShowMsg("ClearCards", controller.CmdResult());
        }

        private void button26_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;

            string cardindex = textBoxIndex.Text.Trim();
            if (string.IsNullOrEmpty(cardindex)) cardindex = "0";

            UInt16 Index = Convert.ToUInt16(cardindex);
            controller.DelCard(true, Index);
            ShowMsg("DelCard", controller.CmdResult());
        }

        private CardData1Door GetPullCardData()
        {
            CardData1Door data = new CardData1Door();

            string card = textBoxCard.Text.Trim();
            if (string.IsNullOrEmpty(card)) card = "0";

            string cardindex = textBoxIndex.Text.Trim();
            if (string.IsNullOrEmpty(cardindex)) cardindex = "0";

            DateTime endDate = dateTimePickerCardEnd.Value;
            TimeSpan endTime = dateTimePickerCardEndTime.Value.TimeOfDay;

            data.Index = Convert.ToUInt16(cardindex);
            data.EndTime = endDate.AddSeconds(endTime.TotalSeconds);
            data.Name = textBoxName1.Text;
            data.CardNo = Convert.ToUInt32(card);
            data.Pin = textBoxPin1.Text.Trim();
            data.Status = 1;

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
            data.TZ = Tz;
            return data;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;

            CardData1Door data = GetPullCardData();

            string cardindex = textBoxCardIndex2.Text.Trim();
            if (string.IsNullOrEmpty(cardindex)) cardindex = "0";

            data.Index = Convert.ToUInt16(cardindex);

            controller.AddCard1Door(true, data);
            ShowMsg("AddCard1Door", controller.CmdResult());
        }
        #endregion

        private void button22_Click(object sender, EventArgs e)
        {
            TCPController controller = GetController();
            if (null == controller) return;

            string str = textBox485data.Text; // "123456ABC";
            byte[] data = UTF8Encoding.Default.GetBytes(str);

            controller.SendTo485(false, data);
            ShowMsg("SendTo485", controller.CmdResult());
        }

        private void buttonAddcardsPull_Click(object sender, EventArgs e)
        {
            Boolean re = false; UInt16 i;
            int Len = 1000;
            UInt16 DataLen = 0;
            progressBar.Maximum = Len;
            TCPController controller = GetController();
            if (null == controller) return;
            CardData data = new CardData();

            for (i = 0; i < Len; i++)
            {
                data.Index = i;
                data.CardNo = (UInt32)(i + 1 + 2000);
                data.Pin = (i + 5000).ToString();
                data.Name = "p姓名" + (i + 1);
                data.TZ1 = 1;
                data.TZ2 = 1;
                data.TZ3 = 1;
                data.TZ4 = 1;

                Thread.Sleep(1);
                re = controller.AddCardsBytes(i >= (Len - 1), ref DataLen, i, data);
                ShowPress(i, Len);
                if (!re) break;
            }

            if (!re)
            {
                AddLog("批量加卡失败 " + (i));
            }
            else AddLog("批量加卡 ");
        }
    }
}
