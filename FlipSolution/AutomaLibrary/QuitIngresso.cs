﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaLibrary
{
    public class QuitIngresso : Ingresso
    {
        public override TipoStato CambiaStato(TipoStato stato)
        {
            switch (stato)
            {
                case TipoStato.C:
                    stato = TipoStato.Q;
                    break;
                case TipoStato.P1:
                    stato = TipoStato.Q;
                    break;
                case TipoStato.D1:
                    stato = TipoStato.Q;
                    break;
                case TipoStato.P2:
                    stato = TipoStato.Q;
                    break;
                case TipoStato.D2:
                    stato = TipoStato.Q;
                    break;
                case TipoStato.R:
                    stato = TipoStato.Q;
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
