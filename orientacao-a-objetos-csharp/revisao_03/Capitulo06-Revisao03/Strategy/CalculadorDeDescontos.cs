namespace Strategy
{
    public class CalculadorDeDescontos
    {
        public double CalcularDesconto(Matricula matricula, IDesconto desconto)
        {
            return desconto.Calcular(matricula);
        }
    }
}
