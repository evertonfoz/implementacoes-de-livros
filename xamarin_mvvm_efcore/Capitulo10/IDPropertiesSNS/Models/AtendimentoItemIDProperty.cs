using SQLite;

namespace CasaDoCodigo.Models
{
    public class AtendimentoItemIDProperty
    {
        [PrimaryKey, AutoIncrement]
        public long? AtendimentoItemID { get; set; }

        [Indexed]
        public long? AtendimentoID { get; set; }
    }
}
