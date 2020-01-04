namespace ChainOfResponsibilityPattern
{
    public interface IMensalidade
    {
        public void Calcular(Matricula matricula);
        public void RegistrarProximo(IMensalidade proximo);
    }
}
