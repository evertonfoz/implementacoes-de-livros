using System.Collections.Generic;

namespace CasaDoCodigo.Models
{
    public class Servico : ServicoIDProperty
    {
        public string Nome { get; set; }
        public double Valor { get; set; }

        public override string ValorFormatado => string.Format("R$ {0:N2}", this.Valor);

        public override bool Equals(object obj)
        {
            return ServicoID.Equals((obj as Servico).ServicoID);
        }

        public override int GetHashCode()
        {
            var hashCode = -1711974839;
            hashCode = hashCode * -1521134296 + EqualityComparer<string>.Default.GetHashCode(ServicoID.ToString());
            return hashCode;
        }
    }
}
