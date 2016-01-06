using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessaggioLibrary
{
    public class MessaggioStringa : Messaggio
    {
        public string Stringa { get; set; }

        public MessaggioStringa()
        {

        }

        public MessaggioStringa(TipoComando comando, string stringa) : base(comando)
        {
            Stringa = stringa;
        }

        public static new bool TryParse(string str, out Messaggio msg)
        {
            bool creata = false;
            try
            {
                string[] parti = str.Split(' ');
                TipoComando comando = (TipoComando)Enum.Parse(typeof(TipoComando), parti[0], true);
                string stringa = parti[1];
                msg = new MessaggioStringa(comando, stringa);
                creata = true;
            }
            catch (Exception)
            {
                msg = null;
            }
            return creata;
        }

        public static new Messaggio Parse(string str)
        {
            Messaggio newMsg = null;
            bool creata = TryParse(str, out newMsg);
            if (!creata)
                throw new FormatException("Formato Messaggio non corretto");
            return newMsg;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            MessaggioStringa msg = obj as MessaggioStringa;
            if (ReferenceEquals(msg, null))
                return false;
            return (base.Equals(msg) && this.Stringa == msg.Stringa);
        }

        public static bool operator ==(MessaggioStringa msg1, MessaggioStringa msg2)
        {
            if (object.ReferenceEquals(msg1, msg2))
                return true;

            if (((object)msg1 == null) || ((object)msg2 == null))
                return false;

            return msg1.Equals(msg2);
        }

        public static bool operator !=(MessaggioStringa msg1, MessaggioStringa msg2)
        {
            return !(msg1 == msg2);
        }

        public override int GetHashCode()
        {
            int hashcode = base.GetHashCode() ^ Stringa.GetHashCode();
            return hashcode;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", base.ToString(), Stringa);
        }
    }
}
