using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReajusteDeFolhaDePagamento
{
    public class Funcionario
    {
        public int Codigo { get; set; }
        public double Salario { get; set; }
        public double Percentual
        {
            get
            {
                if (this.Salario < 1000) return 15;
                else if (this.Salario < 1500) return 10;
                else
                    return 5;
            }
        }
        public double NovoSalario
        {
            get
            {
                return (this.Salario * this.Percentual /
                        100) + this.Salario;
            }
        }
    }
}
