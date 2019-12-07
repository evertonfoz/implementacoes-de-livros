using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelProject
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public double PrecoDeCusto { get; set; }
        public double PrecoDeVenda { get; set; }
        public double Estoque { get; set; }
    }
}
