namespace ChainOfResponsibilityPattern;

public abstract class MensalidadeBase : IMensalidade
{
    private IMensalidade? _proximo;

    public void RegistrarProximo(IMensalidade proximo)
    {
        _proximo = proximo;
    }

    public void Calcular(Matricula matricula)
    {
        // 1. Aplica a regra desta etapa da cadeia
        AplicarRegra(matricula);
        
        // 2. Repassa a responsabilidade para o próximo elo, se ele existir
        _proximo?.Calcular(matricula);
    }

    // Método que as classes filhas deverão implementar
    protected abstract void AplicarRegra(Matricula matricula);
}
