namespace ChainOfResponsibilityPattern
{
    public class CalculadorDeMensalidade
    {
        public double Calcular(Matricula matricula)
        {
            double valorMatricula = 0;

            if (matricula.TemRegulares) valorMatricula = 1000;
            if (matricula.TemEnriquecimento) valorMatricula += 200;
            if (matricula.TemDependencia) valorMatricula += 500;

            return valorMatricula;
        }
    }
}
