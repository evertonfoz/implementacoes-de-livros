using SQLite;

namespace CasaDoCodigo.Models
{
    public class AtendimentoIDProperty
    {
        [PrimaryKey, AutoIncrement]
        public long? AtendimentoID { get; set; }

        [Indexed]
        public long? ClienteID { get; set; }
    }
}
