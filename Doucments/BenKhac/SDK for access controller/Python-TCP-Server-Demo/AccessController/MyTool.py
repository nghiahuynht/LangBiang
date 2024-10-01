def bytesToHexString(bs):
    return ''.join(['%02X ' % b for b in bs])

def bytesToString(bs):
    return bytes.decode(bs,encoding='utf8')

