using System;

namespace ComplementarDois_Heranca_Interface
{
    class ContaEspecial : IConta
    {
        private Conta conta;
        public double Limite { get; set; }
        public double SaldoDisponivel { get; }

        public ContaEspecial(string nome) {
            conta = new Conta(nome);
        }

        public void Debitar(double valor)
        {
            conta.Debitar(valor);
            this.saldo -= valor;
        }
    }
}
