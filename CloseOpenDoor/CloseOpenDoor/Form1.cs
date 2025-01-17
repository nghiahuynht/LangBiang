using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TcpClass.Controller;

namespace CloseOpenDoor
{
    public partial class Form1 : Form
    {


        TTCPController TCPClientWorker;
        TTCPPullCommand PullTCPCmd;

        public Form1()
        {
            InitializeComponent();
        }

       


        private void btnConnect_Click(object sender, EventArgs e)
        {
            OpenConnectionDevice();
        }

        private void OpenConnectionDevice()
        {
            string ip = txtIPBoMach.Text;
            int port = Convert.ToUInt16(txtPort.Text);
            TCPClientWorker.OpenIP(ip, port, Convert.ToUInt16(txtORMCode.Text));
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TCPClientWorker.TCPNet.IsConnectSuccess())
                lblStatusConntion.Text = "Online";
            else lblStatusConntion.Text = "Offline";
        }

        public bool Checkvalid(string qrValue)
        {
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PullTCPCmd = new TTCPPullCommand();

            ITCPNet Net = new ClassTcpClientWorker();
            Net.OnRxTxDataEvent += OnRxTxDataHandler;
            Net.OnSocketConnected += EventSocketConnected;

            TCPClientWorker = new TTCPController(Net, PullTCPCmd);
            TCPClientWorker.OnEventHandler += EventHandler;
            TCPClientWorker.OnStatusHandler += StatusHandler;

            TCPClientWorker.OnGetPullCommandData += OnGetPullCommandData;
        }
        void EventSocketConnected(bool link)
        {
            //if (link)
            //    ShowConnectMsg("连接 link");
            //else ShowConnectMsg("断开 unlink ");

            //if (!link) ShowMsg("状态:false");
        }
        void OnRxTxDataHandler(byte[] buff, int len, bool isSend)
        {
            //if (isSend)
            //    ShowHexMsg(buff, len, " Send:");
            //else
            //    ShowHexMsg(buff, len, " Rec:");
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
             //   listBox2.BeginUpdate();
                //  listBox2.Items.Insert(0, " ");
             //   listBox2.Items.Insert(0, str);
             //   listBox2.EndUpdate();
            }
        }




        // hàm scan QR code lấy value quét
        void EventHandler(RAcsEvent Event, TTCPControllerBase Object)
        {
            string qrValue = Event.Value.ToString();
            bool validQR = CheckValidQR(qrValue);
            if (validQR == true)
            {
                //OpenConnectionDevice();
                if (TCPClientWorker.TCPNet.IsConnectSuccess())
                {
                    OpenDoor();
                }
                //CloseConnectionDevice();
            }



            //string dt = Event.Datetime.ToString();
            //switch (Event.EventType)
            //{

            //    case 11:
            //        if (Event.Value.ToString() == "44001133")
            //        {

            //            //OpenConnectionDevice();
            //            if (TCPClientWorker.TCPNet.IsConnectSuccess())
            //            {
            //                OpenDoor();
            //            }
            //            //CloseConnectionDevice();


            //        }
            //        break;

            //}
        }

        void StatusHandler(RAcsStatus Event, TTCPControllerBase Object)
        {
            //if (Event.IndexCmd == 0)
            //{
            //    TimeSpan ds = DateTime.Now - Event.Datetime;
            //    if (System.Math.Abs(ds.Seconds) >= 10) // 10 must more then the heart time;
            //    {
            //        PullTCPCmd.SetTime(DateTime.Now.AddSeconds(4)); // becase the pull commmand will be run later, so add some seconds
            //        //setmsg();
            //    }
            //}

            string dt = Event.Datetime.ToString();
            //ShowMsg("");
            //ShowMsg("DoorStatus  :" + Event.DoorStatus.ToString() + ",Version:" + Event.Version.ToString() + ",SystemOption:" + Event.SystemOption.ToString());
            //ShowMsg("SerialNo    : " + Event.SerialNo + "  Input :" + Event.Input.ToString("X2"));
            //ShowMsg("Time        : " + dt);
            //ShowMsg("");
        }

        private void btnDisConnect_Click(object sender, EventArgs e)
        {
            Boolean re = false;
            re = TCPClientWorker.CloseTcpip();

        }
        private void CloseConnectionDevice()
        {
            Boolean re = false;
            re = TCPClientWorker.CloseTcpip();
        }
        private void OpenDoor()
        {
            Boolean re = false;
            //setmsg();
            re = TCPClientWorker.OpenDoor(1);
        }
        private void btnOpenDoor_Click(object sender, EventArgs e)
        {
            string testQRvalue = "10";
            bool validQR = CheckValidQR(testQRvalue);
            if (validQR)
            {
                OpenDoor();
            }
           
        }






        private bool CheckValidQR(string qrValue)//GAMAN customize
        {
            
            try
            {
                DataTable dtresult = GetCheckValidQR(Convert.ToInt64(qrValue));
                if (dtresult.Rows.Count != 0 && dtresult.Rows[0]["ResultScan"].ToString() == "ok")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public DataTable GetCheckValidQR(long qrValue)
        {
            var param = new SqlParameter[] {
                        new SqlParameter("@QRValue", qrValue)

                    };


            SqlHelper.ValidNullValue(param);
            string query = string.Format(@"EXEC sp_CheckValidQRforScan @QRValue");
            DataTable dataResult = SqlHelper.ExecuteDataset(SqlHelper.ConnString(), CommandType.Text, query, param).Tables[0];
            return dataResult;
        }





    }
}
