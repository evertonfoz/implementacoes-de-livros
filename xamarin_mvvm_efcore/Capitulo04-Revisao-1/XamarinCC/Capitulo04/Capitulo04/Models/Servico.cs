namespace Capitulo04.Models
{
    public class Servico
    {
        public long? ServicoID { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }

        public string ValorFormatado { get { return string.Format("R$ {0:N2}", this.Valor); } }
    }
}
