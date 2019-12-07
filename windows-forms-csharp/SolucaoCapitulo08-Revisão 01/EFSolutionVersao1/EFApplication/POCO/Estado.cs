using System.Collections.Generic;
using System.Windows.Documents;

namespace EFApplication.POCO
{
    public class Estado
    {
        public long Id { get; set; }
        public string UF { get; set; }
        public string Nome { get; set; }

        public virtual List<Cidade> Cidades { get; set; }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
