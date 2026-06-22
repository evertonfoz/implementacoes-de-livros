using System;

namespace ComplementarUm_Heranca_Formas
{
    class Triangulo : Forma
    {
        public override double Area => (Lado * Altura) / 2;

        public double Altura { get; set; }

        public override double GetPerimetro()
        {
            return Lado * 3;
        }
    }
}
