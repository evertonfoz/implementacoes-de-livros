namespace ChainOfResponsibilityPattern
{
    public class CalculadorDeMensalidade
    {
        public void Calcular(Matricula matricula)
        {
            var acrescimoRegular = new MensalidadeRegular();
            var acrescimoEnriquecimento = new MensalidadeEnriquecimento();
            var acrescimoDependencia = new MensalidadeDependencia();
            var semAcrescimo = new MensalidadeSemAcrescimo();

            acrescimoRegular.RegistrarProximo(acrescimoEnriquecimento);
            acrescimoEnriquecimento.RegistrarProximo(acrescimoDependencia);
            acrescimoDependencia.RegistrarProximo(semAcrescimo);

            acrescimoRegular.Calcular(matricula);
        }
    }
}
