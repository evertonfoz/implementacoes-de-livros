namespace ComplementarDois_Heranca_Interface
{
    interface IConta
    {
        double SaldoDisponivel { get; }
        void Creditar(double valor);
        void Debitar(double valor);
    }
}
