using SQLite;

namespace CasaDoCodigo.Models
{
    public class ServicoIDProperty
    {
        [PrimaryKey, AutoIncrement]
        public long? ServicoID { get; set; }
    }
}
