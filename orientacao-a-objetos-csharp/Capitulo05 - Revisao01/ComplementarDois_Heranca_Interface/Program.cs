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
                simples.Debitar(50);

                var especial = new ContaEspecial("Especial");
                especial.Limite = 100;
                especial.Creditar(100);
                especial.Debitar(100);
                especial.Debitar(100);

                var investimento = new ContaInvestimento("Investimento");
                investimento.SaldoInvestimento = 100;
                investimento.Creditar(100);
                investimento.Debitar(110);
                investimento.Debitar(100);
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
