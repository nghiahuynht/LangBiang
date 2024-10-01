#from os import getcwd
from twisted.internet import protocol, reactor, endpoints
import threading
import _thread
import time
import MyForm
from AccessController import AcsStand, AcsCommon, MyTool


class CallBackFuntionCmd():
    def __init__(self,form):
        protocol.Protocol.__init__(self)
        self.form = form
        self.cmdcall = None
        self.Cmd=''
        self.TimeOut=False
        self.CmdHasResult=False
        self.OutTime=50

    def SetCmd(self,cmd,outtime=50):
        self.OutTime=outtime
        self.Cmd = cmd
        self.TimeOut=False
        self.CmdHasResult=False
        self.thread = threading.Thread(target=self._CmdOuttime)
        self.thread.start()

    def RunCallBack(self,Rxdata):
        if not self.TimeOut:
            self.CmdHasResult=True
            resault= Rxdata[7]==0x06
            self.form.ShowCmdResult(self.Cmd, MyTool.bytesToHexString(Rxdata) + str(resault))  #
        self.Cmd=''

    def _CmdOuttime(self):
        time.sleep(self.OutTime/100)
        self.TimeOut = True
        if not self.CmdHasResult:
            self.form.ShowCmdResult(self.Cmd, "超时")

class AcsNet(protocol.Protocol):
    def dataReceived(self, data):
        if not AcsCommon.CheckTCPRecData(data):
            return
        if not self.Acs:
            self.Acs = AcsStand.ControllerFactory(data).NewController(self)

        rrdata,etype = self.Acs.GetControllerData(data)

        if etype != 0:
            self.form.ShowMsg(' 接收:' + MyTool.bytesToHexString(data))

        if rrdata!=None:
            if etype == 1 or etype == 2 or etype == 3:
                self.transport.write(bytes(rrdata))
            else:
                pass
                # 卡状态 转发给其它控制器
                #(self.Acs.StatusEvent.CardStatusData())
            if etype != 0:
                self.form.ShowMsg(' 发送:' + MyTool.bytesToHexString(rrdata))
        else:
            self.CallBack.RunCallBack(data)

        self.form.ShowData(self.Acs, etype,self.firstLink)
        self.firstLink = False
        data=None

    def SendCmd(self,cmd,data,outtime=50):
        self.CallBack.SetCmd(cmd,outtime)
        self.transport.write(bytes(data))
        self.form.ShowCmdSend(cmd, MyTool.bytesToHexString(data));

    def __init__(self,form):
        protocol.Protocol.__init__(self)
        self.firstLink = True
        self.CallBack = CallBackFuntionCmd(form)
        self.Acs=None
        self.form = form

    def connectionMade(self):
        print("connection made")

    def readConnectionLost(self):
        print("readConnectionLost")
        self.transport.loseConnection()

    def writeConnectionLost(self):
        print("writeConnectionLost")

    def connectionLost(self, reason):
       # self.form.ShowMsg(self.Acs.HeartStatus.Serial +' 断开\n');
        self.firstLink = False
        print("connectionLost", reason)
        #reactor.stop()
        self.transport.loseConnection()

class EchoFactory(protocol.Factory):
    def buildProtocol(self, addr):
        return AcsNet(self.form)

    def Stop(self):
        pass
        #reactor.stop()

    def __init__(self,form):
        protocol.Factory.__init__(self)
        self.form = form
        form.BeginStart()


class network():
    def start(self):
        self.form = MyForm.myform()
        self.EchoFactory = EchoFactory(self.form)

        endpoints.serverFromString(reactor, "tcp:8001").listen(self.EchoFactory)
        reactor.run()

    #def __init__(self):



