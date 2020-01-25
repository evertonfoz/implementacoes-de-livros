using System.ComponentModel.DataAnnotations.Schema;

namespace CasaDoCodigo.Models
{
    public class AtendimentoIDProperty
    {
        public long? AtendimentoID { get; set; }
        public long? ClienteID { get; set; }

        [NotMapped]
        public virtual bool EstaFinalizado => false;
        [NotMapped]
        public bool NotificarListView { get; set; }
    }
}
