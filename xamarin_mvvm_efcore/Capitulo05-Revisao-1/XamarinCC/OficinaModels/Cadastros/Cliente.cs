using IDPropertiesEF.Models;
using System.Collections.Generic;

namespace CasaDoCodigo.Models
{
    public class Cliente : ClienteIDProperty
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string EMail { get; set; }
        public override bool Equals(object obj)
        {
            return ClienteID.Equals((obj as Cliente).ClienteID);
        }

        public override int GetHashCode()
        {
            var hashCode = -1711974838;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ClienteID.ToString());
            return hashCode;
        }
    }
}
