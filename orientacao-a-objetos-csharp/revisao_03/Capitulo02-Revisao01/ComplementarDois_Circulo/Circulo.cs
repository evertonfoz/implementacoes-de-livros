using System;

namespace ComplementarDois_Circulo
{
    class Circulo
    {
        private readonly double PI = 3.14;
        private const double PII = 3.14;

        public double Raio { get; set; }

        public double Area()
        {   
            return PI * Math.Pow(Raio, 2);
        }

        public double Comprimento()
        {
            return PI * Raio;
        }
    }
}
