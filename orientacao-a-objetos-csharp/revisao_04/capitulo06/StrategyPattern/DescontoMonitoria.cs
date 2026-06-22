namespace StrategyPattern;

public class DescontoMonitoria : IDesconto
{
    public decimal Calcular(Matricula matricula)
    {
        return matricula.ValorMensalidade * 0.08m;
    }
}
