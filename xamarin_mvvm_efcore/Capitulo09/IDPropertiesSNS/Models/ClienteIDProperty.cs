using SQLite;

namespace CasaDoCodigo.Models
{
    public abstract class ClienteIDProperty
    {
        [PrimaryKey, AutoIncrement]
        public long? ClienteID { get; set; }
    }
}
