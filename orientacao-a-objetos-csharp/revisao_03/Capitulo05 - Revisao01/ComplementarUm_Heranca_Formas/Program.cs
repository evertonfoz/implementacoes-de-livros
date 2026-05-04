using System;
using System.Collections.Generic;

namespace ComplementarUm_Heranca_Formas
{
    class Program
    {
        static void Main(string[] args)
        {
            var formas = new List<Forma>();

            formas.Add(new Retangulo()
            {
                Nome = "Retângulo",
                Altura = 2,
                Base = 3
            });

            formas.Add(new Circulo()
            {
                Nome = "Circulo",
                Raio = 4
            });

            foreach (var f in formas)
            {
                Console.WriteLine($"A figura {f.Nome} tem {f.Area} de área");
            }
        }
    }
}
