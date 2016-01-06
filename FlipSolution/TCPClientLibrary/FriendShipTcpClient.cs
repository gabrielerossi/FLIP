using AutomaLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPClientLibrary
{
    public class FriendShipTcpClient
    {
        public void Start()
        {
            TcpClient client = new TcpClient();
            // in attesa di collegamento al server
            Console.WriteLine("Premere un tasto per connettersi");
            Console.ReadKey();
            client.Connect("127.0.0.1", 8000);
            Console.WriteLine("Connessione effettuata");
            
            NetworkStream nsRead = client.GetStream();
            NetworkStream nsWrite = client.GetStream();

            StreamReader sr = new StreamReader(nsRead);
            StreamWriter sw = new StreamWriter(nsWrite);
            sw.AutoFlush = true;

            TipoStato stato = TipoStato.C;

            while (stato != TipoStato.Q)
            {
                Console.Write("Digitare  il messaggio:  ");
                string risp = Console.ReadLine();
                risp = stato.ToString() + ' ' + risp;
                sw.WriteLine(risp);
                string[] msgRisp = sr.ReadLine().Split(' ');
                stato = (TipoStato)Enum.Parse(typeof(TipoStato), msgRisp[0], true);
                Console.WriteLine("");
                Console.WriteLine("La risposta è {0} {1}", msgRisp[0], msgRisp[1]);
                Console.WriteLine("-------------------------------");
                Console.WriteLine("");
            }

            //Task.Factory.StartNew(Comunica, client);
        }

        //public void Comunica(object param)
        //{
        //    TcpClient client = (TcpClient)param;
        //    NetworkStream nsRead = client.GetStream();
        //    NetworkStream nsWrite = client.GetStream();

        //    StreamReader sr = new StreamReader(nsRead);
        //    StreamWriter sw = new StreamWriter(nsWrite);
        //    sw.AutoFlush = true;

        //    TipoStato stato = TipoStato.C;

        //    while (stato != TipoStato.Q)
        //    {
        //        Console.Write("Digitare  il messaggio:  ");
        //        string risp = Console.ReadLine();
        //        risp = stato.ToString() + ' ' + risp;
        //        sw.WriteLine(risp);
        //        string[] msgRisp = sr.ReadLine().Split(' ');
        //        stato = (TipoStato)Enum.Parse(typeof(TipoStato), msgRisp[0], true);
        //        Console.WriteLine("");
        //        Console.WriteLine("La risposta è {0} {1}", msgRisp[0], msgRisp[1]);
        //        Console.WriteLine("-------------------------------");
        //        Console.WriteLine("");
        //    }
        //}
    }
}
