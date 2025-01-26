using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpStandard_Server.GamanModel
{
    public class GamanDoorModel
    {
        public int DoorSlotNum { get; set; }
        public string IP { get; set; }
        public string Port { get; set; }
        public string Oem { get; set; }
        public string Serial { get; set; }
    }
}
