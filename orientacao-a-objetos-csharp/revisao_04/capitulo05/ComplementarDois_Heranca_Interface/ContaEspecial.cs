using System;

namespace ComplementarDois_Heranca_Interface
{
    class ContaEspecial : IConta
    {
        private readonly Conta conta;
        
        public double Limite { get; set; }

        public double SaldoDisponivel => conta.SaldoDisponivel + Limite;

        public ContaEspecial(string nome)
        {
            conta = new Conta(nome);
        }

        public void Creditar(double valor)
        {
            conta.Creditar(valor);
        }

        public void Debitar(double valor)
        {
            if (SaldoDisponivel - valor < 0)
                throw new Exception($"Saldo insuficiente na conta {conta.Nome} para debitar {valor}.");
            
            // Hack para reutilizar o debitar base. Se tem limite, a validação da base pode estourar se saldo < valor,
            // então devemos controlar aqui.
            // Para manter a composição simples:
            // A ContaBase não deixa o saldo ficar negativo. Mas a ContaEspecial permite.
            // Portanto, como ContaEspecial delega, teremos que tratar isso ou o design de composição precisaria
            // de um "DebitarForcado" na Conta base.
            // Como a Conta base impede saldo negativo, e a Especial permite, precisamos abstrair isso.
            // Para não quebrar a lógica da Conta, debitaremos manualmente? Não, o saldo está encapsulado.
            // O livro deixa como desafio. Se a base não permite saldo negativo, teremos que creditar um "empréstimo" temporário.
            // Solução limpa: como `Conta` é final e tem validação estrita, vamos usar a interface IConta mas o saldo 
            // ficará travado em 0 na `Conta` e o limite será consumido na `ContaEspecial`.
            
            // Para simplificar o desafio mantendo a regra de negócios:
            double saldoRestante = conta.SaldoDisponivel - valor;
            if (saldoRestante >= 0)
            {
                conta.Debitar(valor);
            }
            else
            {
                // Consome o que tem de saldo e o resto consome do limite
                if (conta.SaldoDisponivel > 0)
                {
                    double valorDebitar = conta.SaldoDisponivel;
                    conta.Debitar(valorDebitar);
                    Limite -= (valor - valorDebitar);
                }
                else
                {
                    Limite -= valor;
                }
            }
        }
    }
}
