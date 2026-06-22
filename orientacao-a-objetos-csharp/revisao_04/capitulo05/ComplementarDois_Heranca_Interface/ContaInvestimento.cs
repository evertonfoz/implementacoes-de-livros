using System;

namespace ComplementarDois_Heranca_Interface
{
    class ContaInvestimento : IConta
    {
        private readonly Conta conta;
        
        public double SaldoInvestimento { get; private set; }
        
        public double SaldoDisponivel => conta.SaldoDisponivel + SaldoInvestimento;

        public ContaInvestimento(string nome)
        {
            conta = new Conta(nome);
        }

        public void Creditar(double valor)
        {
            conta.Creditar(valor);
        }

        // Sobrecarga exigida no capítulo
        public void Creditar(double valor, bool paraInvestimento)
        {
            if (!paraInvestimento)
                conta.Creditar(valor);
            else
                SaldoInvestimento += valor;
        }

        public void Debitar(double valor)
        {
            if (SaldoDisponivel - valor < 0)
                throw new Exception($"Saldo insuficiente na conta {conta.Nome} para debitar {valor}.");

            if (SaldoInvestimento > 0)
            {
                if (SaldoInvestimento >= valor)
                {
                    SaldoInvestimento -= valor;
                }
                else
                {
                    double restante = valor - SaldoInvestimento;
                    SaldoInvestimento = 0;
                    conta.Debitar(restante);
                }
            }
            else
            {
                conta.Debitar(valor);
            }
        }
    }
}
