using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AutomaLibrary
{
    public class CalcIngresso : Ingresso
    {
        public override TipoStato CambiaStato(TipoStato stato)
        {
            switch (stato)
            {
                case TipoStato.C:
                    break;
                case TipoStato.P1:
                    break;
                case TipoStato.R:
                    break;
                case TipoStato.D1:
                    break;
                case TipoStato.P2:
                    break;
                case TipoStato.D2:
                    stato = TipoStato.R;
                    break;
                case TipoStato.Q:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return stato;
        }
    }
}

