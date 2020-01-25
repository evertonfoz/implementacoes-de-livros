using System.ComponentModel.DataAnnotations.Schema;

namespace CasaDoCodigo.Models
{
    public class AtendimentoItemIDProperty
    {
        public long? AtendimentoItemID { get; set; }
        public long? AtendimentoID { get; set; }
        public long? ServicoID { get; set; }

        [NotMapped]
        public bool NotificarListView { get; set; }
    }
}
