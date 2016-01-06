using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaLibrary
{
    public abstract class Ingresso
    {
        //public abstract TipoStato CambiaStato(TipoStato stato);

        public virtual TipoStato CambiaStato(TipoStato stato)
        {
            TipoStato resp = TipoStato.Nessuno;
            return resp;
        }
    }
}
