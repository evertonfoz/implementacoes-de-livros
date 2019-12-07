using SQLite.Net.Attributes;

namespace Modulo1.Modelo
{
    public class Cliente
    {
        [PrimaryKey, AutoIncrement]
        public long? ClienteId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
