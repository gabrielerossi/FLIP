using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TCPClientLibrary;

namespace AppTcpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            StartClient();
            Console.ReadKey();
        }

        private static async void StartClient()
        {
            FriendShipTcpClient cli = new FriendShipTcpClient();
            await Task.Factory.StartNew(cli.Start);
        }
    }
}
