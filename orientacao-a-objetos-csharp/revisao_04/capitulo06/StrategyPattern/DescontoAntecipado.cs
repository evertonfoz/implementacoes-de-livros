namespace StrategyPattern;

public class DescontoAntecipado : IDesconto
{
    public decimal Calcular(Matricula matricula)
    {
        // O sufixo 'm' indica que o literal numérico é do tipo decimal
        return matricula.ValorMensalidade * 0.05m; 
    }
}
