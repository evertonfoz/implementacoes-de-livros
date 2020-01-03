namespace ChainOfResponsibilityPattern
{
    public class MensalidadeRegular : IMensalidade
    {
        public double Calcular(Matricula matricula, double valorAnterior)
        {
            if (matricula.TemRegulares)
                return (valorAnterior + 1000);
            else
                return valorAnterior;
        }
    }
}
