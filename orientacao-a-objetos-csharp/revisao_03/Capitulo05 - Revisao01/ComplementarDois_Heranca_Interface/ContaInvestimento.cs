namespace ComplementarDois_Heranca_Interface
{
    class ContaInvestimento : Conta
    {
        private double saldoInvestimento;
        public double SaldoInvestimento {
            get
            {
                return saldoInvestimento;
            }
        }
        public override double SaldoDisponivel => (this.saldo + this.SaldoInvestimento);
        public ContaInvestimento(string nome) : base(nome)
        {
        }
        public void Creditar(double valor, bool paraInvestimento = false)
        {
            if (!paraInvestimento)
                base.Creditar(valor);
            else
                saldoInvestimento += valor;
        }
        public override void Debitar(double valor)
        {
            base.Debitar(valor);
            if (SaldoInvestimento > 0)
            {
                saldoInvestimento -= valor;
                if (SaldoInvestimento < 0)
                {
                    this.saldo -= (SaldoInvestimento * -1);
                    saldoInvestimento = 0;
                }
            }
            else
                this.saldo -= valor;
        }

    }
}
