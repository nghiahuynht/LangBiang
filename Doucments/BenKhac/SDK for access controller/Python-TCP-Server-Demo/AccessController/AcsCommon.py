

def CheckTCPRecData(data):
    if len(data)<9:
        return False
    if data[0] != 0x02:return False
    cs = 0
    for v in data:
        cs = cs ^ v
    if cs != 0x03:return False
    return True

class AcsCommon:
    def Head(self ,cmd ,door):
        self.head = bytearray(7)
        self.head[0] = 0x02
        self.head[1] = 0x00
        self.head[2] = cmd
        self.head[3] = 0x00
        self.head[self.Loc_DoorAddr] = door
        self.head[5] = 0x00
        self.head[6] = 0x00

    def _SetLength(self ,len):
        self.head[5] = len
        self.head[6] = len>>8

    def AddData(self):
        return self.head

    def GetCSByte(self ,array):
        cs = 0
        for v in array:
            cs = cs ^ v
        return cs

    def EndBuffer(self ,buffer):
        ln = len(buffer)-7
        buffer[self.Loc_Len]=ln
        buffer[self.Loc_Len+1] = ln>>8
        cs = self.GetCSByte(buffer)
        buffer.append(cs)
        buffer.append(0x03)
        return buffer

    def GetPassword(self,str,Maxlen=8):
        if len(str)>Maxlen:return bytearray(4)
        str = str.ljust(Maxlen, 'F')
        psd = bytes(str , encoding="utf8")
        psw = bytearray( 0xff&int(Maxlen/2))
        i=0
        for chr in psd:
            if chr == 70:
                chr = 0x0F
            else:
                chr = 0x0f&int(chr)

            j=int(i/2)&0xff
            if((i&0x01) >0):
                psw[j] = (psw[j]<<4)&0xf0
            psw[j] |= chr
            i=i+1
        return  psw


    def GetString(self,str,Maxlen):
        if len(str)>Maxlen:return bytearray(Maxlen)
        lst = bytearray(Maxlen-len(str))
        bstr = bytearray(str.encode())
        bstr.extend(lst)
        return  bstr

    def __init__(self):
        self.Loc_Begin = 0;
        self.Loc_Temp = 1;
        self.Loc_Command = 2;
        self.Loc_Address = 3;
        self.Loc_DoorAddr = 4;
        self.Loc_Len = 5;
        self.Loc_Data = 7;

