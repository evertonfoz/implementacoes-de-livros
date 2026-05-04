namespace ComplementarUm_Heranca_Formas
{
    class Retangulo : Forma
    {
        public double Base { get; set; }
        public double Altura { get; set; }
        public override double Area => (Base * Altura);
        public bool EhUmQuadrado => Base == Altura;
    }
}
