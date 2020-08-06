using IDPropertiesEF.Models;

namespace CasaDoCodigo.Models
{
    public class Peca : PecaIDProperty
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public string CaminhoImagem { get; set; }
        public bool Sincronizado { get; set; }

        public override string ValorFormatado => string.Format("R$ {0:N2}", this.Valor);
    }
}
