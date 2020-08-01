using OficinaModels.Cadastros;
using System.Collections.Generic;

namespace CasaDoCodigo.Models
{
    public class AtendimentoItem : AtendimentoItemIDProperty
    {
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        public double SubTotal { get { return Quantidade * Valor; } }

        public Atendimento Atendimento { get; set; }

        //public long? ServicoID { get; set; }
        public Servico Servico { get; set; }

        public override bool Equals(object obj)
        {
            var item = (obj as AtendimentoItem);
            return (item.AtendimentoID == this.AtendimentoID && item.ServicoID == this.ServicoID);
        }

        public override int GetHashCode()
        {
            var hashCode = -1711974841;
            hashCode = hashCode * -1521134298 + EqualityComparer<string>.Default.GetHashCode((AtendimentoID + ServicoID).ToString());
            return hashCode;
        }
    }
}
