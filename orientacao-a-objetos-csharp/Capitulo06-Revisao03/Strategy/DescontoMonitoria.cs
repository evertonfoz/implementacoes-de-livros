namespace Strategy
{
    class DescontoMonitoria : IDesconto
    {
        public double Calcular(Matricula matricula)
        {
            return matricula.ValorMensalidade * 0.08;
        }
    }
}
