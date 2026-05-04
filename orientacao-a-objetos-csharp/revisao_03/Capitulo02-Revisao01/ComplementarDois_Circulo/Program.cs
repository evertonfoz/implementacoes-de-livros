using System;

namespace ComplementarDois_Circulo
{
    class Program
    {
        static void Main(string[] args)
        {
            Circulo circulo = new Circulo();
            System.Console.Write("Informe o RAIO de um círculo: ");
            circulo.Raio = Convert.ToDouble(System.Console.ReadLine());
            
            System.Console.WriteLine("===================================");
            System.Console.WriteLine("Área: " + circulo.Area());
            System.Console.WriteLine("Comprimento: " + circulo.Comprimento());

            System.Console.Write("Pressione qualquer tecla para encerrar.");
            System.Console.ReadKey();
        }
    }
}
