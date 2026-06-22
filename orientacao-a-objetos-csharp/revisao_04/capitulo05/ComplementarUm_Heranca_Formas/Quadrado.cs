namespace ComplementarUm_Heranca_Formas
{
    class Quadrado : Forma
    {
        public override double Area => Lado * Lado;

        public override double GetPerimetro()
        {
            return Lado * 4;
        }
    }
}
