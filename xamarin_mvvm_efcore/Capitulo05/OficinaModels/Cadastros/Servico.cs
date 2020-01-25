namespace CasaDoCodigo.Models
{
    public class Servico : ServicoIDProperty
    {
        public string Nome { get; set; }
        public double Valor { get; set; }

        public override string ValorFormatado => string.Format("R$ {0:N2}", this.Valor);
    }
}
