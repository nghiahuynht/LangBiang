using TcpStandard_Server.StandTcpController;
using TcpStandard_Server.StandTcpProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpStandard_Server
{
    public class EventHandle : EventHandleInterface
    {
        public event TOnShowCardEvent OnShowCardEvent;
        public event TOnShowAlarmEvent OnShowAlarmEvent;
        public event TOnShowHeartEvent OnShowHeartEvent;
        public event TOnAddLog OnAddLog;
        public event TOnShowNetChange OnShowNetChange;
        public event TOnShowPullCmd OnShowPullCmd;

        public void ShowPullCmd(byte[] data, int num)
        {
            if (OnShowPullCmd != null)
                OnShowPullCmd(data, num);
        }

        public void ShowNetChange(TCPController controller)
        {
            if (OnShowNetChange != null)
                OnShowNetChange(controller);
        }

        public void ShowMsg(String Caption, String Msg)
        {
            String str = TAcsTool.GetNowTime() + " " + Caption + " = " + Msg;
            //System.Console.WriteLine(str);
            AddLog(str);
        }

        public void ShowCmdHex(String Caption, byte[] data)
        {
            String str = TAcsTool.Bytes2Hex(data);
            str = TAcsTool.GetNowTime() + " " + Caption + " = " + str;
          //  System.Console.WriteLine(str);
            AddLog(str);
        }

        public void ShowHeartEvent(RHeartStatus HeartStatus, TCPController controller)
        {
            if (OnShowHeartEvent != null)
                OnShowHeartEvent(HeartStatus, controller);
        }

        public void ContrlSendCmdHex(byte[] data)
        {
            ShowCmdHex("控制器发送", data);
        }

        public void AddLog(String str)
        {
            if (OnAddLog != null)
                OnAddLog(str);
        }

        public void ShowCardEvent(RCardEvent CardEvent, TCPController controller)
        {
            if (OnShowCardEvent != null)
                OnShowCardEvent(CardEvent, controller);
        }

        public void ShowAlarmEvent(RAlarmEvent AlarmEvent, TCPController controller)
        {
            if (OnShowAlarmEvent != null)
                OnShowAlarmEvent(AlarmEvent, controller);
        }

        public void SoftSendCmdHex(byte[] data)
        {
            ShowCmdHex("软件发送", data);
            AddLog("\r\n");
        }
    }
}