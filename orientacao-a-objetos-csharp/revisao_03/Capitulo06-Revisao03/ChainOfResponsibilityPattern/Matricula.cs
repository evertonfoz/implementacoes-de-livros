namespace ChainOfResponsibilityPattern
{
    public class Matricula
    {
        public double ValorMensalidade { get; private set; } = 0;
        public bool TemRegulares { get; set; }
        public bool TemEnriquecimento { get; set; }
        public bool TemDependencia { get; set; }
        public void RegistrarAcrescimoMensalidade(double valorAcrescimo)
        {
            this.ValorMensalidade = this.ValorMensalidade + valorAcrescimo;
        }
    }
}
