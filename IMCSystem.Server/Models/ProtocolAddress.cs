using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMCSystem.Server.Models
{
    public class ProtocolAddress
    {
        public string Address { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Passwd { get; set; }
    }
}
