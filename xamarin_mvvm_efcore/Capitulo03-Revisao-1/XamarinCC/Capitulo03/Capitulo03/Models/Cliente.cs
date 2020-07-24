using System.Collections.Generic;

namespace Capitulo03.Models
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public IList<Veiculo> Veiculos { get; set; }

        public Cliente()
        {
            Veiculos = new List<Veiculo>();
        }
    }
}
