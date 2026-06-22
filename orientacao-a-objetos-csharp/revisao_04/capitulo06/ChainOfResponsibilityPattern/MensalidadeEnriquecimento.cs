namespace ChainOfResponsibilityPattern;

public class MensalidadeEnriquecimento : MensalidadeBase
{
    protected override void AplicarRegra(Matricula matricula)
    {
        if (matricula.TemEnriquecimento)
            matricula.RegistrarAcrescimoMensalidade(200m);
    }
}
