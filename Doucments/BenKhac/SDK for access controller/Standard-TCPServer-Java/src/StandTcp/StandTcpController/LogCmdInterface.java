package StandTcp.StandTcpController;

import StandTcp.StandTcpProtocol.TCPCmdStruct;

// 界面显示日志信息
public interface LogCmdInterface {
    void AddLog(String str);
    void ShowMsg(String Caption, String Msg);

    void SoftSendCmdHex(byte[] data);

    void ContrlSendCmdHex(byte[] data);

    void ShowCardEvent(TCPCmdStruct.RCardEvent CardEvent);
    void ShowAlarmEvent(TCPCmdStruct.RAlarmEvent AlarmEvent);

    void ShowHeartEvent(TCPCmdStruct.RHeartStatus HeartStatus);
}
