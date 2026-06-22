namespace ChainOfResponsibilityPattern;

public interface IMensalidade
{
    void Calcular(Matricula matricula);
    void RegistrarProximo(IMensalidade proximo);
}
