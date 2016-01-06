using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessaggioLibrary
{
    public class MessaggioData : Messaggio
    {
        public DateTime Data { get; set; }

        public MessaggioData()
        {

        }

        public MessaggioData(TipoComando comando, DateTime data) : base(comando)
        {
            Data = data;
        }

        public new static bool TryParse(string str, out Messaggio msg)
        {
            bool creata = false;
            try
            {
                string[] parti = str.Split(' ');
                TipoComando comando = (TipoComando)Enum.Parse(typeof(TipoComando), parti[0], true);
                DateTime data = DateTime.Parse(parti[1]);
                msg = new MessaggioData(comando, data);
                creata = true;
            }
            catch (Exception)
            {
                msg = null;
            }
            return creata;
        }

        public new static Messaggio Parse(string str)
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
            MessaggioData msg = obj as MessaggioData;
            if (ReferenceEquals(msg, null))
                return false;
            return (base.Equals(msg) && this.Data == msg.Data);
        }

        public static bool operator ==(MessaggioData msg1, MessaggioData msg2)
        {
            if (object.ReferenceEquals(msg1, msg2))
                return true;

            if (((object)msg1 == null) || ((object)msg2 == null))
                return false;

            return msg1.Equals(msg2);
        }

        public static bool operator !=(MessaggioData msg1, MessaggioData msg2)
        {
            return !(msg1 == msg2);
        }

        public override int GetHashCode()
        {
            int hashcode = base.GetHashCode() ^ Data.GetHashCode();
            return hashcode;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", base.ToString(), Data.ToShortDateString());
        }
    }
}
