using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPServerLibrary;

namespace AppTcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            FriendShipTcpServer srv = new FriendShipTcpServer();
            srv.Start();
            Console.ReadKey();
        }
    }
}
