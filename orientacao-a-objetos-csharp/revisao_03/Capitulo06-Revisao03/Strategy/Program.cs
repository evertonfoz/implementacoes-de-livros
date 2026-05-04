using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculadorDeDescontos = new CalculadorDeDescontos();
            var matricula = new Matricula() { ValorMensalidade = 1000 };
            var descontoAntecipado = calculadorDeDescontos.
                CalcularDesconto(matricula, new DescontoAntecipado());
            var descontoMonitoria = calculadorDeDescontos.
                CalcularDesconto(matricula, new DescontoMonitoria());

            Console.Write("Valor mensalidade........:");
            Console.WriteLine("{0, 15}", string.Format("{0:C2}", 
                matricula.ValorMensalidade));

            Console.Write("Desconto pgto. Antecipado:");
            Console.WriteLine("{0, 15}", string.Format("{0:C2}", 
                descontoAntecipado));

            Console.Write("Desconto por Monitoria...:");
            Console.WriteLine("{0, 15}", string.Format("{0:C2}", 
                descontoMonitoria));

            Console.Write("Valor a pagar............:");
            Console.WriteLine("{0, 15}", string.Format("{0:C2}", 
                matricula.ValorMensalidade - (descontoAntecipado + descontoMonitoria)));

            Console.ReadKey();
        }
    }
}
