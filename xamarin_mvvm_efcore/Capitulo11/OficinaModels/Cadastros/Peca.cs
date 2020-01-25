using System.Collections.Generic;

namespace CasaDoCodigo.Models
{
    public class Peca : PecaIDProperty
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public string CaminhoImagem { get; set; }
        public bool Sincronizado { get; set; }

        public override string ValorFormatado => string.Format("R$ {0:N2}", this.Valor);



        public override bool Equals(object obj)
        {
            var peca = (obj as Peca);
            return (peca.PecaID == this.PecaID);
        }

        public override int GetHashCode()
        {
            var hashCode = -1711974840;
            hashCode = hashCode * -1521134297 + EqualityComparer<string>.Default.GetHashCode(PecaID.ToString());
            return hashCode;
        }
    }
}
