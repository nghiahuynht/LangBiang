
import struct
from AccessController import AcsCommon
import time
import datetime
import string

class RBaseEvent:
    def bytes2Int(self,data):
        return data[0]  + (data[1]<< 8)  + (data[2] << 16) + (data[3] << 24)

    def bytes2Time(self,data):
        return datetime.datetime(data[5]+2000, data[4],data[3],data[2], data[1], data[0])

class RTCPHeartStatus(RBaseEvent,AcsCommon.AcsCommon):
    def GetHeart(self, heartdata,OemCode):
       # print(heartdata)
        heartlist = struct.unpack_from('7sB6sBBBBBB4sBBH6sHiB', heartdata)
        heartdata=None
        self.N1 = heartlist[1]
        self.Time = heartlist[2]
        self.DoorStatus = heartlist[3]
        self.CardNumInPack = heartlist[4]
        self.DirPass = heartlist[5]
        self.SystemOption = heartlist[6]
        self.ControlType = heartlist[7]
        self.RelayOut = heartlist[8]
        self.N2 =  heartlist[9]
        self.Output = heartlist[10]
        self.Ver = heartlist[11]
        self.OEMCODE = heartlist[12]
        self.Serial = heartlist[13].decode()
        self.Input = heartlist[14]
        self.IndexCmd = heartlist[15]
        self.CmdOK = heartlist[16]
       # print(self.Serial)
        return self.__ReturnData(OemCode)

    def __init__(self):
        AcsCommon.AcsCommon.__init__(self)
        self.Heard=bytearray(7)
        self.N1 = 0x01
        self.Time = bytearray(6)
        self.DoorStatus = 0x00
        self.CardNumInPack = 0x00
        self.DirPass = 0x00
        self.SystemOption = 0x00
        self.ControlType = 0x00
        self.RelayOut = 0x00
        self.N2 = bytearray(4)
        self.Output = 0x1100
        self.Ver = 0x00
        self.OEMCODE = 0x1001
        self.Serial = ''
        self.Input  = 0x1100
        self.IndexCmd = int(0x00)
        self.CmdOK = 0x00

    def __ReturnData(self,OemCode):
        self.Head(0x56,0)
        buffer = self.head
        buffer.append(OemCode & 0xff)
        buffer.append(OemCode >> 8 & 0xff)
        buffer = self.EndBuffer(buffer)
        # print( struct.pack('B', 0x01))
        return buffer

    def GetString(self):
        str0 = "   Serial=%s"
        str = str0%(  self.Serial  )
        return str

class RTCP_CardEvent(RBaseEvent,AcsCommon.AcsCommon):
    def GetData(self, data):
        if len(data) < 21: return None
        values = struct.unpack_from('7s4s6sBBBB', data)
        data = None
        self.Card = self.bytes2Int(values[1])
        self.EventTime = self.bytes2Time(values[2])
        self.EventType = values[3] & 0x7F
        if  (values[3] & 0x80) == 0x80 :
            self.Reader = 1
        else:
            self.Reader = 0

        self.Door = values[4]
        self.HasMore = values[5]
        self.IndexEvent = values[6]
        return self.ReturnData()

    def GetString(self):
        str0 = "CardEvent: Time=%s  Card=%s  Event=%d Door=%d"
        str1 = self.EventTime.strftime("%Y-%m-%d %H:%M:%S")
        str2 = "%d"%self.Card
        str = str0%( str1,str2, self.EventType,self.Door )
        return str

    def ReturnData(self):
        self.Head(0x53,0)
        buffer = self.head
        buffer.append(self.IndexEvent)
        buffer = self.EndBuffer(buffer)
        # print( struct.pack('B', 0x01))
        return buffer

    def __init__(self):
        AcsCommon.AcsCommon.__init__(self)
        self.Heard=bytearray(7)
        self.Card =  0x12345678 #bytearray(4)  #
        self.EventTime =  datetime.date.today() # time.time() #bytearray(6)
        self.EventType = 0x00
        self.Door = 0x00
        self.HasMore = 0x00
        self.IndexEvent = 0x00
        self.Reader = 0x00
        self.String=""

class RTCP_AlarmEvent(RBaseEvent,AcsCommon.AcsCommon):
    def GetData(self, data):
        if len(data)<19:return None
        values = struct.unpack_from('7s6sBBBB', data)
        data=None
        self.EventTime = self.bytes2Time(values[1])
        self.EventType = values[2]
        self.Door = values[3]
        self.HasMore = values[4]
        self.IndexEvent = values[5]
        return self.ReturnData()

    def ReturnData(self):
        self.Head(0x54,0)
        buffer = self.head
        buffer.append(self.IndexEvent)
        buffer = self.EndBuffer(buffer)
        return buffer

    def GetString(self):
        str0 = "AlarmEvent: Time=%s  Event=%d Door=%d"
        str1 = self.EventTime.strftime("%Y-%m-%d %H:%M:%S")
        str = str0 % (str1, self.EventType, self.Door)
        return str

    def __init__(self):
        AcsCommon.AcsCommon.__init__(self)
        self.Heard=bytearray(7)
        self.EventTime =  datetime.date.today() # time.time() #bytearray(6)
        self.EventType = 0x00
        self.Door = 0x00
        self.HasMore = 0x00
        self.IndexEvent = 0x00

class RTCP_StatusEvent(RBaseEvent,AcsCommon.AcsCommon):
    def GetData(self, data):
        if len(data) < 14: return None
        values = struct.unpack_from('7s2sBBB', data)
        data = None
        self.CardIndex = self.bytes2Int(values[1])
        self.CardStatus = values[2] & 0x7F
        self.IndexEvent = values[3]
        self.HasMore = values[4]

        if len(data) >= 14+9:
            values = struct.unpack_from('7s2sBBB4s5s', data)
            self.Passtime = values[6]
            self.Times = values[7]
        return self.ReturnData()

    def ReturnData(self):
        self.Head(0x52,0)
        buffer = self.head
        buffer.append(self.IndexEvent)
        buffer = self.EndBuffer(buffer)
        return buffer

    def CardStatusData(self):
        self.Head(0x66,0)
        buffer = self.head
        buffer.append(self.CardIndex & 0xff)
        buffer.append(self.CardIndex >> 8 & 0xff)
        buffer.append(self.CardStatus &0xff)
        buffer.extend(self.Passtime)
        buffer.extend(self.Times)
        buffer = self.EndBuffer(buffer)
        return buffer

    def __init__(self):
        AcsCommon.AcsCommon.__init__(self)
        self.Heard=bytearray(7)
        self.CardIndex =  0
        self.CardStatus = 0x00
        self.IndexEvent = 0x00
        self.HasMore = 0x00
        self.Passtime = bytearray(4)
        self.Times = bytearray(4)

class TCPBaseCommand(AcsCommon.AcsCommon):

    def __init__(self):
        AcsCommon.AcsCommon.__init__(self)
        self.Serial = ''
# remote control command  
    def _Cmd_OpenDoor(self,door):
        self.Head(0x2c ,door + 1)
        buffer = self.head
        buffer.append(door)
        buffer = self.EndBuffer(buffer)
        return buffer

    def _Cmd_CloseDoor(self ,door):
        self.Head(0x2e ,door + 1)
        buffer = self.head
        buffer.append(door)
        buffer = self.EndBuffer(buffer)
        return buffer

    def _Cmd_OpenDoorForever(self ,door):
        self.Head(0x2d ,door + 1)
        buffer = self.head
        buffer.append(door)
        buffer = self.EndBuffer(buffer)
        return buffer

    def _Cmd_SetAlarm(self,open,longtime):
        self.Head(0x18 ,0x00)
        buffer = self.head
        buffer.append(int(open)&0xff)
        buffer.append(longtime)
        buffer = self.EndBuffer(buffer)
        return buffer

    def _Cmd_SetFire(self ,open):
        self.Head(0x19,0x00)
        buffer = self.head
        buffer.append(int(not open)&0xff)
        buffer.append(0)
        buffer = self.EndBuffer(buffer)
        return buffer

    def _Cmd_Lock(self ,door,lock):
        self.Head(0x2F ,door + 1)
        buffer = self.head
        buffer.append(int(lock)&0xff)
        buffer = self.EndBuffer(buffer)
        return buffer

    def _Cmd_StopReader(self ,reader,stop,allreader):
        self.Head(0x5A ,0)
        buffer = self.head
        buffer.append(0)
        buffer.append(reader & 0xff)
        buffer.append(0)
        buffer.append(int(stop ) & 0xff)
        buffer.append(int(allreader) & 0xff)
        buffer = self.EndBuffer(buffer)
        return buffer
# system command
    def _Cmd_ResetSystems(self):
        self.Head(0x04 ,0x00)
        buffer = self.head
        buffer = self.EndBuffer(buffer)
        return buffer

    def _Cmd_Restart(self):
        self.Head(0x05 ,0x00)
        buffer = self.head
        buffer = self.EndBuffer(buffer)
        return buffer

    def _Cmd_SetTime(self):
        self.Head(0x07 ,0x00)
        buffer = self.head
        t = datetime.datetime.now()
        buffer.append(t.second & 0xff )
        buffer.append(t.minute& 0xff)
        buffer.append(t.hour& 0xff)
        buffer.append(t.weekday().real & 0xff)
        buffer.append(t.day& 0xff)
        buffer.append(t.month& 0xff)
        buffer.append((t.year-2000) & 0xff)
        buffer = self.EndBuffer(buffer)
        return buffer

   # def CmdCallBack(self,cmd,result):


# base data
    def _Cmd_ClearTimezone(self ,door):
        self.Head(0x0F,door + 1)
        buffer = self.head
        buffer.append(door)
        buffer = self.EndBuffer(buffer)
        return buffer

    def _Cmd_SetTimezone(self ,door,tzIndex,beginHour,beginMinute,endHour,endMinute,Week,Access,Holiday, passback):
        self.Head(0x0D ,door + 1)
        buffer = self.head

        buffer.append(tzIndex & 0xff)
        buffer.append(beginHour & 0xff)
        buffer.append(beginMinute & 0xff)
        buffer.append(endHour & 0xff)
        buffer.append(endMinute & 0xff)
        if Holiday:Week |= 0x80
        buffer.append(Week & 0xff)
        if passback:Access |=0x80
        buffer.append(Access & 0xff)

        t = datetime.datetime.now()

        buffer.append((t.year - 2000+10) & 0xff)
        buffer.append(t.month & 0xff)
        buffer.append(t.day & 0xff)

        buffer.append(0)
        buffer.append(0)

        buffer = self.EndBuffer(buffer)
        return buffer

    def _Cmd_SetDoor(self ,door,openTime,closeTime,alarmToolong,AlarmType,AlarmTime,mCards,mCardsPath):
        self.Head(0x61 ,door + 1)
        buffer = self.head
        buffer.append(openTime & 0xff)
        buffer.append(closeTime & 0xff)
        buffer.append(1)
        buffer.append(int(alarmToolong) & 0xff)
        buffer.append(openTime>>8 & 0xff)

        buffer.append(AlarmType & 0xff)

        buffer.append(AlarmTime & 0xff)
        buffer.append(AlarmTime >> 8 & 0xff)

        buffer.append(mCards & 0xff)
        buffer.append(mCardsPath & 0xff)

        buffer = self.EndBuffer(buffer)
        return buffer

    def _Cmd_SetControl(self,Lockeach,firetime,alarmTime,Password):
        self.Head(0x63 ,0x00)
        buffer = self.head

        buffer.append(int(Lockeach) & 0xff)

        buffer.append(firetime & 0xff)
        buffer.append(firetime >> 8 & 0xff)

        buffer.append(alarmTime & 0xff)
        buffer.append(alarmTime >> 8 & 0xff)

        psd = self.GetPassword(Password)
        buffer.extend(psd)

        buffer = self.EndBuffer(buffer)
        return buffer

    def _Cmd_AddHoliday(self,index,frmDate,toDate):
        self.Head(0x09 ,0x00)
        buffer = self.head

        buffer.append(index & 0xff)
        buffer.append((frmDate.year - 2000) & 0xff)
        buffer.append(frmDate.month & 0xff)
        buffer.append(frmDate.day & 0xff)

        buffer.append((toDate.year - 2000 ) & 0xff)
        buffer.append(toDate.month & 0xff)
        buffer.append(toDate.day & 0xff)

        buffer = self.EndBuffer(buffer)
        return buffer

    def _Cmd_ClearAllHoliday(self):
        self.Head(0x0c,0x00)
        buffer = self.head
        buffer = self.EndBuffer(buffer)
        return buffer

    # card data command
    # 人员编号         2
    # 卡号             4
    # 密码             2 / 4
    # 门权限           2
    # 有效期           5 / 4
    # 状态             0 / 1
    # 姓名             0 / 8

    def _Cmd_AddCard(self,SystemOption,CardIndex,card,password,tz1,tz2,tz3,tz4,enddate,name):
        self.Head( 0x62,0x00)
        buffer = self.head

        buffer.append(CardIndex & 0xff)
        buffer.append(CardIndex >> 8 & 0xff)

        buffer.append(card & 0xff)
        buffer.append(card >> 8 & 0xff)
        buffer.append(card >> 16 & 0xff)
        buffer.append(card >> 24 & 0xff)

        if (SystemOption & 0x20 == 0x20) or (SystemOption & 0x10 == 0x10):
            psd = self.GetPassword(password)
            buffer.extend(psd)
        else:
            psd = self.GetPassword(password,4)
            buffer.extend(psd)

        buffer.append(tz1 & 0xff)
        buffer.append(tz2 & 0xff)
        buffer.append(tz3 & 0xff)
        buffer.append(tz4 & 0xff)

        if SystemOption&0x01 == 0x01:
            buffer.append(enddate.minute & 0xff)
            buffer.append(enddate.hour & 0xff)
            buffer.append(enddate.day & 0xff)
            buffer.append(enddate.month & 0xff)
            buffer.append((enddate.year - 2000) & 0xff)
        else:
            buffer.append(0)
            buffer.append(0)
            buffer.append(0)
            buffer.append(0)

        if SystemOption & 0x08 == 0x08:
            buffer.extend(self.GetString(name,8))

        buffer = self.EndBuffer(buffer)
        return buffer

    def _Cmd_DeleteCard(self,card):
        self.Head(0x15 ,0x00)
        buffer = self.head
        buffer.append(card & 0xff)
        buffer.append(card >> 8 & 0xff)
        buffer.append(card >> 16 & 0xff)
        buffer.append(card >> 24 & 0xff)
        buffer = self.EndBuffer(buffer)
        return buffer

    def _Cmd_DeleteEmp(self,index):
        self.Head(0x16 ,0x00)
        buffer = self.head
        buffer.append(index & 0xff)
        buffer.append(index >> 8 & 0xff)
        buffer = self.EndBuffer(buffer)
        return buffer

    def _Cmd_ClearAllEmp(self):
        self.Head( 0x17,0x00)
        buffer = self.head
        buffer = self.EndBuffer(buffer)
        return buffer

    def _Cmd_AddCards(self,SystemOption,CardIndex,card,password,tz1,tz2,tz3,tz4,enddate,name):
        self.Head(0x88 ,0x00)
        buffer = self.head
        #未完成
        buffer = self.EndBuffer(buffer)
        return buffer

    def _Cmd_UpdateCardStatus(self,CardIndex,cardStatus,Passtime,Times):
        self.Head(0x66 ,0x00)
        buffer = self.head
        buffer.append(CardIndex & 0xff)
        buffer.append(CardIndex >> 8 & 0xff)
        buffer.append(cardStatus &0xff)
        buffer.extend(Passtime)
        buffer.extend(Times)
        buffer = self.EndBuffer(buffer)
        return buffer

# RS485 command
    def _Cmd_Send485(self,ArrayData):
        self.Head( 0xB1,0x00)
        buffer = self.head
        buffer.extend(ArrayData)
        buffer = self.EndBuffer(buffer)
        return buffer

    def _Cmd_Set485Serial(self,index,Rd485serial):
        self.Head(0xB2 ,0x00)
        buffer = self.head
        buffer.append(index & 0xff)
        buffer.extend(bytearray(Rd485serial.encode()))
        buffer = self.EndBuffer(buffer)
        return buffer

class AcsStandController(TCPBaseCommand):
    def OpenDoor(self, door):
        data = self._Cmd_OpenDoor(door)
        self.AcsNet.SendCmd('OpenDoor',data)

    def CloseDoor(self, door):
        data = self._Cmd_CloseDoor(door)
        self.AcsNet.SendCmd('CloseDoor', data)

    def OpenDoorForever(self, door):
        data = self._Cmd_OpenDoorForever(door)
        self.AcsNet.SendCmd('OpenDoorForever', data)

    def SetAlarm(self, open, longtime):
        data = self._Cmd_SetAlarm(open,longtime)
        self.AcsNet.SendCmd('SetAlarm', data)

    def SetFire(self, open):
        data = self._Cmd_SetFire(open)
        self.AcsNet.SendCmd('SetFire', data)

    def SetLock(self, door, lock):
        data = self._Cmd_Lock(door,lock)
        self.AcsNet.SendCmd('Lock', data )

    def StopReader(self, reader, stop,allreader):
        data = self._Cmd_StopReader(reader ,stop,allreader )
        self.AcsNet.SendCmd('Lock', data)

# system command

    def ResetSystems(self):
        data = self._Cmd_ResetSystems()
        self.AcsNet.SendCmd('ResetSystems', data,600)

    def Restart(self):
        data = self._Cmd_Restart()
        self.AcsNet.SendCmd('Restart', data)

    def SetTime(self):
        data = self._Cmd_SetTime()
        self.AcsNet.SendCmd('SetTime', data)

# base data

    def ClearTimezone(self, door):
        data = self._Cmd_ClearTimezone(door)
        self.AcsNet.SendCmd('ClearTimezone', data,200)

    def SetTimezone(self, door,tzIndex,beginHour,beginMinute,endHour,endMinute,Week,Access,Holiday, passback):
        data = self._Cmd_SetTimezone(door,tzIndex,beginHour,beginMinute,endHour,endMinute,Week,Access,Holiday, passback)
        self.AcsNet.SendCmd('SetTimezone', data,200)

    def SetDoor(self, door,openTime,closeTime,alarmToolong,AlarmType,AlarmTime,mCards,mCardsPath):
        data = self._Cmd_SetDoor(door,openTime,closeTime,alarmToolong,AlarmType,AlarmTime,mCards,mCardsPath)
        self.AcsNet.SendCmd('SetDoor', data,200)

    def SetControl(self,Lockeach,firetime,alarmTime,Password):
        data = self._Cmd_SetControl(Lockeach,firetime,alarmTime,Password)
        self.AcsNet.SendCmd('SetControl', data,200)

    def AddHoliday(self,index,frmDate,toDate):
        data = self._Cmd_AddHoliday(index,frmDate,toDate)
        self.AcsNet.SendCmd('AddHoliday', data,200)

    def ClearAllHoliday(self):
        data = self._Cmd_ClearAllHoliday()
        self.AcsNet.SendCmd('ClearAllHoliday', data,200)

# card data command

    def AddCard1Door(self,index,card,password,tz,enddate,name):
        data = self._Cmd_AddCard(self.HeartStatus.SystemOption,index,card,password,tz,tz>>8,0,0,enddate,name)
        self.AcsNet.SendCmd('AddCard1Door', data,500)

    def AddCard2Door(self,index,card,password,tz1,tz2,enddate,name):
        data = self._Cmd_AddCard(self.HeartStatus.SystemOption,index,card,password,tz1,tz1>>8,tz2,tz2>>8,enddate,name)
        self.AcsNet.SendCmd('AddCard2Door', data,500)

    def AddCard4Door(self,index,card,password,tz1,tz2,tz3,tz4,enddate,name):
        data = self._Cmd_AddCard(self.HeartStatus.SystemOption,index,card,password,tz1,tz2,tz3,tz4,enddate,name)
        self.AcsNet.SendCmd('AddCard4Door', data,500)

    def DeleteCard(self,card):
        data = self._Cmd_DeleteCard(card)
        self.AcsNet.SendCmd('DeleteCard', data,500)

    def DeleteEmp(self,index):
        data = self._Cmd_DeleteEmp(index)
        self.AcsNet.SendCmd('DeleteEmp', data,500)

    def ClearAllEmp(self):
        data = self._Cmd_ClearAllEmp()
        self.AcsNet.SendCmd('ClearAllEmp', data,800)

    def AddCards(self,SystemOption,CardIndex,card,password,tz1,tz2,tz3,tz4,enddate,name):
        data = self._Cmd_AddCards(SystemOption,CardIndex,card,password,tz1,tz2,tz3,tz4,enddate,name)
        self.AcsNet.SendCmd('AddCards', data,500)

    def UpdateCardStatus(self,CardIndex,cardStatus,Passtime,Times):
        data = self._Cmd_UpdateCardStatus(CardIndex,cardStatus,Passtime,Times)
        self.AcsNet.SendCmd('UpdateCardStatus', data,200)

# RS485 command
    def Send485(self,ArrayData):
        data = self._Cmd_Send485(ArrayData)
        self.AcsNet.SendCmd('Send485', data,500)

    def Set485Serial(self,index,Rd485serial):
        data = self._Cmd_Set485Serial(index,Rd485serial)
        self.AcsNet.SendCmd('Set485Serial', data,200)

#=============================================================================
    def GetControllerData(self,data):
        if(data[self.Loc_Command] == 0x56):
            buffer = self.HeartStatus.GetHeart(data,self.OemCode)
            self.Serial = self.HeartStatus.Serial
            return buffer,1
        elif(data[self.Loc_Command] == 0x53):   # 刷卡
            return self.CardEvent.GetData(data),2
        elif (data[self.Loc_Command] == 0x54):  # 报警
            return self.AlarmEvent.GetData(data),3
        elif (data[self.Loc_Command] == 0x52):  # 防潜返
            return self.StatusEvent.GetData(data), 4
        else:
            pass
            #print('not heart')
        return None,0

    def __init__(self,AcsNet):
        self.AcsNet = AcsNet
        TCPBaseCommand.__init__(self)
        self.HeartStatus = RTCPHeartStatus()
        self.CardEvent = RTCP_CardEvent()
        self.AlarmEvent = RTCP_AlarmEvent()
        self.StatusEvent = RTCP_StatusEvent()
        self.Serial = ''
        self.OemCode = 23456


class ControllerFactory:
    def NewController(self,AcsNet):
        return AcsStandController(AcsNet)

    def __init__(self,Heartdata):
        pass
        #self.HeartData = Heartdata
        #self.HeartStatus = RTCPHeartStatus()
        #self.Serial = ''
        #self.GetHeart(Heartdata)

