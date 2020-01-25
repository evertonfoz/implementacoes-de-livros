using SQLite;

namespace CasaDoCodigo.Models
{
    public class AtendimentoFotoIDProperty
    {
        [PrimaryKey, AutoIncrement]
        public long? AtendimentoFotoID { get; set; }

        [Indexed]
        public long? AtendimentoID { get; set; }
    }
}
