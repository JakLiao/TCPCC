using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;

namespace ClientTCP
{
    class Users
    {
        public string userName { get; set; }
        public int port { get; set; }

        public Users(string userName, int port)
        {
            this.userName = userName;
            this.port = port;
        }
    }
}
