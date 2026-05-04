namespace Strategy
{
    class DescontoAntecipado : IDesconto
    {
        public double Calcular(Matricula matricula)
        {
            return matricula.ValorMensalidade * 0.05;
        }
    }
}
