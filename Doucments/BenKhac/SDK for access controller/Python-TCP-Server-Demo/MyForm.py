import tkinter
import tkinter.dialog
import NetWork
import threading
import time
import  datetime
from twisted.internet import protocol, reactor, endpoints
import struct
from AccessController import AcsStand

class myform:
    def Opendoor(self):
        if self.AcsObj!=None:
            self.AcsObj.OpenDoor(0)

    def Closedoor(self):
        if self.AcsObj != None:
            self.AcsObj.CloseDoor(0)

    def SetFireOn(self):
        if self.AcsObj != None:
            self.AcsObj.SetFire(True)

    def SetFireOff(self):
        if self.AcsObj != None:
            self.AcsObj.SetFire(False)

    def LockOn(self):
        if self.AcsObj != None:
            self.AcsObj.SetLock(0,True)

    def LockOff(self):
        if self.AcsObj != None:
            self.AcsObj.SetLock(0,False)

    def StopReaderOn(self):
        if self.AcsObj != None:
            self.AcsObj.StopReader(0,True,False)

    def StopReaderOff(self):
        if self.AcsObj != None:
            self.AcsObj.StopReader(0,False,False)

    def ResetSystems(self):
        if self.AcsObj != None:
            self.AcsObj.ResetSystems()

    def SetTime(self):
        if self.AcsObj != None:
            self.AcsObj.SetTime()

    def ClearTimezone(self):
        if self.AcsObj != None:
            self.AcsObj.ClearTimezone(0)

    def SetTimezone(self):
        if self.AcsObj != None:
            self.AcsObj.SetTimezone(0, 0, 0, 0, 23, 58, 0x7F, 1, True, False)
            #self.AcsObj.SetTimezone(door,tzIndex,beginHour,beginMinute,endHour,endMinute,Week,Access,Holiday, passback)

    def SetDoor(self):
        if self.AcsObj != None:
            self.AcsObj.SetDoor(0, 5, 6, False, 0, 10, 0, 3)
            #self.AcsObj.SetDoor(door,openTime,closeTime,alarmToolong,AlarmType,AlarmTime,mCards,mCardsPath)

    def SetControl(self):
        if self.AcsObj != None:
            self.AcsObj.SetControl(False,100,50,"12345")
            #self.AcsObj.SetControl(Lockeach,firetime,alarmTime,Password):

    def AddCard(self):
        if self.AcsObj != None:
            t = datetime.datetime.now() + datetime.timedelta(days=100)
            self.AcsObj.AddCard1Door(0,123456,"321456",1,t,"name")

    def DeleteCard(self):
        if self.AcsObj != None:
            self.AcsObj.DeleteCard(123456)

    def DeleteEmp(self):
        if self.AcsObj != None:
            self.AcsObj.DeleteEmp(1)

    def ClearAllEmp(self):
        if self.AcsObj != None:
            self.AcsObj.ClearAllEmp()

    def AddCards(self):
        if self.AcsObj != None:
            self.AcsObj.AddCards()

    def Send485(self):
        if self.AcsObj != None:
            self.AcsObj.Send485(  bytearray("0123 abcd 这里是485输出  3210 ".encode()))

    #================================================================================
    # def RecData(self,AcsObj,data):
    #    self.AcsNet = AcsObj
        #localtime = time.strftime("%Y-%m-%d %H:%M:%S", time.localtime())
        #print('-',localtime,AcsNet.transport.client,data)

    def ShowData(self, AcsObj, etype,firstLink):
        self.AcsObj = AcsObj
        if (etype == 1) and (firstLink==True):
            self.display.insert(0.0, datetime.datetime.now().strftime("%H:%M:%S") +  ' 控制器连接' + AcsObj.HeartStatus.GetString() + '\n')
        if etype==2:
            self.display.insert(0.0, datetime.datetime.now().strftime("%H:%M:%S") + ' 刷卡记录' + AcsObj.CardEvent.GetString() + '\n')
        if etype==3:
            self.display.insert(0.0, datetime.datetime.now().strftime("%H:%M:%S") + ' 报警记录' + AcsObj.AlarmEvent.GetString() + '\n')

    def ShowCmdSend(self, cmd, msg):
        self.display.insert(0.0,datetime.datetime.now().strftime("%H:%M:%S") +   ' 发送:'+  cmd + ' : ' + msg + '\n')

    def ShowCmdResult(self,cmd, msg):
        if cmd==None:cmd=' '
        self.display.insert(0.0,datetime.datetime.now().strftime("%H:%M:%S") +   ' 接收:' +  cmd + ' : ' + msg + '\n')

    def ShowMsg(self, msg):
        self.display.insert(0.0, datetime.datetime.now().strftime("%H:%M:%S") +  msg + '\n')

    def BeginStart(self):
       print('BeginStart')

    def kill(self):
        pass
        #self.quit()

    def Start(self):
        self.window = tkinter.Tk()
        self.window.title('标准门禁控制器TCP通讯 Python Demo(控制器为客户端)')
        self.window.geometry('1060x440')

        self.display = tkinter.Text(self.window, wrap=tkinter.NONE,  heigh=18)
        self.display.pack(side=tkinter.TOP, fill = tkinter.X,expand=False  )

      #  self.display = tkinter.Text(self.window, wrap=tkinter.NONE  )
      #  self.display.place(x=5, y=5, width=650, heigh=250 )

        self.b1 = tkinter.Button(self.window, text='开门\nOpen door',   command = self.Opendoor)
        self.b2 = tkinter.Button(self.window, text='关门\nClose door',  command=self.Closedoor)
        self.b3 = tkinter.Button(self.window, text='开火警\nFire Alarm', command=self.SetFireOn)
        self.b4 = tkinter.Button(self.window, text='关火警\nClose Fire', command=self.SetFireOff)
        self.b5 = tkinter.Button(self.window, text='锁定门\nFire Alarm', command=self.LockOn)
        self.b6 = tkinter.Button(self.window, text='解锁门\nClose Fire', command=self.LockOff)

        self.b7 = tkinter.Button(self.window, text='同步时间\nSettime long',   command=self.SetTime)
        self.b8 = tkinter.Button(self.window, text='门参数\nSet door', command=self.SetDoor)
        self.b9 = tkinter.Button(self.window, text='控制器参数\nSet controller', command=self.SetControl)
        self.b10 = tkinter.Button(self.window, text='初始化\nResetsystem', command=self.ResetSystems)
        self.b11 = tkinter.Button(self.window, text='删除开放时间\nClear Timezone',  command = self.ClearTimezone)
        self.b12 = tkinter.Button(self.window, text='添加开放时间\nAdd Timezone',  command = self.SetTimezone)

        self.b13 = tkinter.Button(self.window, text='添加卡\nAdd card',   command=self.AddCard)
        self.b14 = tkinter.Button(self.window, text='删除卡号\ndelete card', command=self.DeleteCard)
        self.b15= tkinter.Button(self.window, text='删除人\nDeleteEmp', command=self.DeleteEmp)
        self.b16 = tkinter.Button(self.window, text='批量加卡\nAdd cards', command=self.AddCards)
        self.b17 = tkinter.Button(self.window, text='禁止读卡\nFire Alarm', command=self.StopReaderOn)
        self.b18 = tkinter.Button(self.window, text='解除禁止读卡\nClose Fire', command=self.StopReaderOff)

        self.b19 = tkinter.Button(self.window, text='485输出\nSend485', command=self.Send485)

        LocY=260
        Offy=60

        LocX=10
        Offx=100

        self.b1.place(x=LocX + Offx*0, y=LocY+Offy*0)
        self.b2.place(x=LocX + Offx*1, y=LocY+Offy*0)
        self.b3.place(x=LocX + Offx*2, y=LocY+Offy*0)
        self.b4.place(x=LocX + Offx*3, y=LocY+Offy*0)
        self.b5.place(x=LocX + Offx*4, y=LocY+Offy*0)
        self.b6.place(x=LocX + Offx*5, y=LocY+Offy*0)

        self.b7.place(x=LocX + Offx*0, y=LocY+Offy*1)
        self.b8.place(x=LocX + Offx*1, y=LocY+Offy*1)
        self.b9.place(x=LocX + Offx*2, y=LocY+Offy*1)
        self.b10.place(x=LocX + Offx*3, y=LocY+Offy*1)
        self.b11.place(x=LocX + Offx * 4, y=LocY + Offy * 1)
        self.b12.place(x=LocX + Offx * 5, y=LocY + Offy * 1)

        self.b13.place(x=LocX + Offx * 0, y=LocY + Offy * 2)
        self.b14.place(x=LocX + Offx * 1, y=LocY + Offy * 2)
        self.b15.place(x=LocX + Offx * 2, y=LocY + Offy * 2)
        self.b16.place(x=LocX + Offx * 3, y=LocY + Offy * 2)
        self.b17.place(x=LocX + Offx * 4, y=LocY + Offy * 2)
        self.b18.place(x=LocX + Offx * 5, y=LocY + Offy * 2)
        self.b19.place(x=LocX + Offx * 6, y=LocY + Offy * 2)

        # 进入消息循环
        self.window.mainloop()

    def __init__(self):
        self.AcsObj=None
        self.users = {}
        self.tk_thread = threading.Thread(target=self.Start)
        self.tk_thread.start()
