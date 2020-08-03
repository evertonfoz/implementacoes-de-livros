using System.ComponentModel.DataAnnotations.Schema;

namespace IDPropertiesEF.Models
{
    public abstract class ClienteIDProperty
    {
        public long? ClienteID { get; set; }
        [NotMapped]
        public bool NotificarListView { get; set; }

    }
}
