using System;

namespace ComplementarDois_Heranca_Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var simples = new ContaSimples("Simples");
                simples.Creditar(100);
                simples.Debitar(50);
                Console.WriteLine($"Conta Simples - Saldo: {simples.SaldoDisponivel}");
                simples.Debitar(60); 
            } 
            catch (Exception e)
            {
                Console.WriteLine($"[Erro Simples] {e.Message}");
            }

            try
            {
                var especial = new ContaEspecial("Especial") { Limite = 100 };
                especial.Creditar(100);
                especial.Debitar(150);
                Console.WriteLine($"Conta Especial - Saldo Disponível: {especial.SaldoDisponivel}");
                especial.Debitar(60);
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Erro Especial] {e.Message}");
            }

            try
            {
                var investimento = new ContaInvestimento("Investimento");
                investimento.Creditar(100, true); // Credita em investimento
                investimento.Creditar(100);       // Credita em conta
                
                investimento.Debitar(150);
                Console.WriteLine($"Conta Investimento - Saldo Disponível Global: {investimento.SaldoDisponivel}");
                Console.WriteLine($"Saldo Investimento Restante: {investimento.SaldoInvestimento}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Erro Investimento] {e.Message}");
            }
        }
    }
}
