using System;

namespace ComplementarUm_Heranca_Formas
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = new Quadrado() { Lado = 4 };
            Console.WriteLine("O Perímetro de Q é: {0}", q.GetPerimetro());
            Console.WriteLine("A Área de Q é: {0}", q.Area);

            var t = new Triangulo() { Lado = 5, Altura = 3 };
            Console.WriteLine("O Perímetro de T é: {0}", t.GetPerimetro());
            Console.WriteLine("A Área de T é: {0}", t.Area);
        }
    }
}
