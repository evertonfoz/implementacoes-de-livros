namespace ComplementarUm_Heranca_Formas
{
    abstract class Forma
    {
        public double Lado { get; set; }
        public abstract double Area { get; }
        
        public abstract double GetPerimetro();
    }
}
