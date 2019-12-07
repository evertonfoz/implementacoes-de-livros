using System;

namespace ConsumoEnergiaCondominio
{
    class Leitura 
    {
        public string Casa { get; set; }
        public double Consumo { get; set; }
        public double Desconto {
            get { return Consumo * 0.20; }
        }

        public Leitura(string casa, double consumo)
        {
            this.Casa = casa;
            this.Consumo = consumo;
        }

        public override bool Equals(Object l)
        {
            Leitura leitura = l as Leitura;
            if (leitura == null)
            {
                return false;
            }

            return (Casa.Equals(leitura.Casa));
        }

        public override int GetHashCode()
        {
            return new { Casa, Consumo}.GetHashCode();
        }

    }
}
