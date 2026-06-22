using System;

namespace ComplementarDois_Heranca_Interface
{
    public sealed class Conta : IConta
    {
        private double saldo;
        public string Nome { get; set; }

        public double SaldoDisponivel => saldo;

        public Conta(string nome)
        {
            Nome = nome;
        }

        public void Creditar(double valor)
        {
            saldo += valor;
        }

        public void Debitar(double valor)
        {
            if (SaldoDisponivel - valor < 0)
                throw new Exception($"Saldo insuficiente na conta {Nome} para debitar {valor}.");
            saldo -= valor;
        }
    }
}
