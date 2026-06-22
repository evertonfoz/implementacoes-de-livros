namespace ChainOfResponsibilityPattern;

public class Matricula
{
    // Propriedade com escrita restrita (private set)
    public decimal ValorMensalidade { get; private set; }
    
    public bool TemRegulares { get; set; }
    public bool TemEnriquecimento { get; set; }
    public bool TemDependencia { get; set; }

    public void RegistrarAcrescimoMensalidade(decimal valorAcrescimo)
    {
        ValorMensalidade += valorAcrescimo;
    }
}
