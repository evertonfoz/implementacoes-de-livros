namespace ChainOfResponsibilityPattern;

public class MensalidadeDependencia : MensalidadeBase
{
    protected override void AplicarRegra(Matricula matricula)
    {
        if (matricula.TemDependencia)
            matricula.RegistrarAcrescimoMensalidade(500m);
    }
}
