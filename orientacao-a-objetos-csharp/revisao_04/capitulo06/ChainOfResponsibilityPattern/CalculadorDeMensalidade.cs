namespace ChainOfResponsibilityPattern;

public class CalculadorDeMensalidade
{
    public void Calcular(Matricula matricula)
    {
        var regular = new MensalidadeRegular();
        var enriquecimento = new MensalidadeEnriquecimento();
        var dependencia = new MensalidadeDependencia();

        // Conectando os elos da cadeia
        regular.RegistrarProximo(enriquecimento);
        enriquecimento.RegistrarProximo(dependencia);

        // Disparando o fluxo pelo primeiro elo
        regular.Calcular(matricula);
    }
}
