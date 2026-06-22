namespace StrategyPattern;

public class CalculadorDeDescontos
{
    public decimal Calcular(Matricula matricula, IDesconto desconto)
    {
        return desconto.Calcular(matricula);
    }
}
