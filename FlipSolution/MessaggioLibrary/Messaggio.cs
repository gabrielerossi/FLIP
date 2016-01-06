using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessaggioLibrary
{
    public class Messaggio
    {
        public TipoComando Comando { get; set; }

        public Messaggio()
        {

        }

        public Messaggio(TipoComando comando)
        {
            Comando = comando;
        }

        public static bool TryParse(string str, out Messaggio msg)
        {
            bool creata = false;
            try
            {
                string[] parti = str.Split(' ');
                TipoComando comando = (TipoComando)Enum.Parse(typeof(TipoComando), parti[0], true);
                msg = new Messaggio(comando);
                creata = true;
            }
            catch (Exception)
            {
                msg = null;
            }
            return creata;
        }

        public static Messaggio Parse(string str)
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
            Messaggio msg = obj as Messaggio;
            if (ReferenceEquals(msg, null))
                return false;
            return (this.Comando == msg.Comando);
        }

        public static bool operator ==(Messaggio msg1, Messaggio msg2)
        {
            if (object.ReferenceEquals(msg1, msg2))
                return true;

            if (((object)msg1 == null) || ((object)msg2 == null))
                return false;

            return msg1.Equals(msg2);
        }

        public static bool operator !=(Messaggio msg1, Messaggio msg2)
        {
            return !(msg1 == msg2);
        }

        public override int GetHashCode()
        {
            int hashcode = Comando.GetHashCode();
            return hashcode;
        }

        public override string ToString()
        {
            return string.Format("{0}", Comando.ToString().ToUpper());
        }
    }
}
