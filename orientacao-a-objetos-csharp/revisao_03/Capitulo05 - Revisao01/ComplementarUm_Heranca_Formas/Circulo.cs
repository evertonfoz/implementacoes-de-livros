using System;

namespace ComplementarUm_Heranca_Formas
{
    class Circulo : Forma
    {
        public double Raio { get; set; }
        public override double Area => (Math.PI * Math.Pow(Raio, 2));
        public double Diametro => (Raio * 2);
    }
}
