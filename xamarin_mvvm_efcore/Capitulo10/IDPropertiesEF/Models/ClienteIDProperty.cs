using System.ComponentModel.DataAnnotations.Schema;

namespace CasaDoCodigo.Models
{
    public abstract class ClienteIDProperty
    {
        public long? ClienteID { get; set; }

        [NotMapped]
        public bool NotificarListView { get; set; }
    }
}
