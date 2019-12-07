namespace ComplementarDois_Heranca_Interface
{
    class ContaSimples : IConta
    {
        private Conta conta;
        public double SaldoDisponivel {
            get { return conta.SaldoDisponivel; }
        }
        public ContaSimples(string nome){
            conta = new Conta(nome);
        }
        public void Creditar(double valor)
        {
            conta.Creditar(valor);
        }
        public void Debitar(double valor)
        {
            conta.Debitar(valor);
        }
    }
}
