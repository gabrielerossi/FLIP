using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessaggioLibrary
{
    public class MessaggioFactory
    {
        public static Messaggio Create(string str)
        {
            Messaggio resp = null;
            try
            {
                string cmd = str.Substring(0, 4);
                TipoComando cmdEnum = (TipoComando)Enum.Parse(typeof(TipoComando), cmd, true);
                switch (cmdEnum)
                {
                    case TipoComando.Quit:
                        resp = Messaggio.Parse(str);
                        break;
                    case TipoComando.Peop:
                        resp = MessaggioStringa.Parse(str);
                        break;
                    case TipoComando.Birt:
                        resp = MessaggioData.Parse(str);
                        break;
                    case TipoComando.Calc:
                        resp = Messaggio.Parse(str);
                        break;
                    case TipoComando.Nessuno:
                        resp = null;
                        break;
                    default:
                        resp = null;
                        break;
                        //throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception)
            {
                
            }
            return resp;
        }
    }
}
