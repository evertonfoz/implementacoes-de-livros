using System;

namespace ComplementarDois_Heranca_Interface
{
    public sealed class Conta : IConta
    {
        private double saldo;
        public string Nome { get; set; }

        public double SaldoDisponivel
        {
            get { return saldo; }
        }

        public Conta(string nome)
        {
            this.Nome = nome;
        }

        public void Creditar(double valor)
        {
            this.saldo += valor;
        }

        public void Debitar(double valor)
        {
            if ((SaldoDisponivel - valor) < 0)
                throw new Exception($"Saldo insuficiente na conta {this.Nome} para debitar {valor}");
            this.saldo -= valor;
        }
    }
}
