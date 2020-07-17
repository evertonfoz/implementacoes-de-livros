using SQLite;

namespace Modulo1.Modelo
{
    public class Entregador
    {
        [PrimaryKey]
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
    }
}
