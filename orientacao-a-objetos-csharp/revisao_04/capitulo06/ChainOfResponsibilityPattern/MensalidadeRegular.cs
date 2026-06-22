namespace ChainOfResponsibilityPattern;

public class MensalidadeRegular : MensalidadeBase
{
    protected override void AplicarRegra(Matricula matricula)
    {
        if (matricula.TemRegulares)
            matricula.RegistrarAcrescimoMensalidade(1000m);
    }
}
