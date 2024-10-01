using TcpStandard_Server.StandTcpProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpStandard_Server.StandTcpController
{
    public delegate void TOnServerStatus(Boolean Active, String str);
    public delegate void TOnShowNetChange(TCPController controller);
    public delegate void TOnShowCardEvent(RCardEvent CardEvent, TCPController controller);
    public delegate void TOnShowAlarmEvent(RAlarmEvent AlarmEvent, TCPController controller);
    public delegate void TOnShowHeartEvent(RHeartStatus HeartStatus, TCPController controller);

    public delegate void TOnAddLog(String str);
    public delegate void TOnShowPullCmd(byte[] data, int num);


    public interface EventHandleInterface
    {
        void ShowCardEvent(RCardEvent CardEvent, TCPController controller);
        void ShowAlarmEvent(RAlarmEvent AlarmEvent, TCPController controller);
        void ShowHeartEvent(RHeartStatus HeartStatus, TCPController controller);

        void ShowNetChange(TCPController controller);

        void AddLog(String str);
        void ShowMsg(String Caption, String Msg);
        void SoftSendCmdHex(byte[] data);
        void ContrlSendCmdHex(byte[] data);
        void ShowPullCmd(byte[] data, int num);
    }
}
