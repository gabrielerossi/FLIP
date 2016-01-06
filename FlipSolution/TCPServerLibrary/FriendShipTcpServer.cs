using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MessaggioLibrary;
using AutomaLibrary;

namespace TCPServerLibrary
{
    public class FriendShipTcpServer
    {
        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Any, 8000);
            Console.WriteLine("Creato il server");
            server.Start();
            Console.WriteLine("Messo in ascolto");
            while (true)
            {
                Console.WriteLine("In attesa di chiamata");
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Chiamata ricevuta");
                Task.Factory.StartNew(Comunica, client);
            }
        }
        static void Comunica(object param)
        {
            TcpClient client = (TcpClient)param;
            Console.WriteLine("Sto avviando la comunicazione");
            NetworkStream nsRead = client.GetStream();
            NetworkStream nsWrite = client.GetStream();

            StreamReader sr = new StreamReader(nsRead);
            StreamWriter sw = new StreamWriter(nsWrite);
            sw.AutoFlush = true;

            TipoStato stato = TipoStato.Nessuno;

            while (true)
            {
                // lettura richiesta dal client
                string str = sr.ReadLine();
                Console.WriteLine(str);
                // Elaborazione e invio risposta
                try
                {
                    string[] strSplit = str.Split(' ');
                    stato = (TipoStato)Enum.Parse(typeof(TipoStato), strSplit[0], true);
                    string strMsg = "";
                    if (strSplit.Length == 3)
                    {
                        strMsg = strSplit[1] + ' ' + strSplit[2];
                    }
                    else
                    {
                        strMsg = strSplit[1];
                    }
                    Messaggio msg = MessaggioFactory.Create(strMsg);
                    TipoComando ingresso = (TipoComando)Enum.Parse(typeof(TipoComando), strSplit[1], true);
                    Ingresso ing = IngressoFactory.Create(ingresso);
                    TipoStato statoSuccessivo = ing.CambiaStato(stato);
                    if (msg != null && statoSuccessivo != stato)
                    {
                        Console.WriteLine(msg.GetType().ToString());
                        sw.WriteLine("{0} +OK", statoSuccessivo.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Messaggio sconosciuto");
                        sw.WriteLine("{0} -ERR", stato.ToString());
                    }
                    if(statoSuccessivo == TipoStato.Q)
                    {
                        Console.WriteLine("Connessione chiusa");
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Messaggio sconosciuto");
                    sw.WriteLine("{0} -ERR", stato.ToString());

                }
            }
        }
    }
}
