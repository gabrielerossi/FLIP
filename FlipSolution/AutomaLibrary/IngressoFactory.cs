using MessaggioLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaLibrary
{
    public class IngressoFactory
    {
        public static Ingresso Create(TipoComando ingresso)
        {
            Ingresso resp = null;
            try
            {
                switch (ingresso)
                {
                    case TipoComando.Quit:
                        resp = new QuitIngresso();
                        break;
                    case TipoComando.Peop:
                        resp = new PeopIngresso();
                        break;
                    case TipoComando.Birt:
                        resp = new BirtIngresso();
                        break;
                    case TipoComando.Calc:
                        resp = new CalcIngresso();
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
