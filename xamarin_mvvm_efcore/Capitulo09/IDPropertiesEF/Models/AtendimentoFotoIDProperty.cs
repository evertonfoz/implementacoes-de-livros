using System.ComponentModel.DataAnnotations.Schema;

namespace CasaDoCodigo.Models
{
    public class AtendimentoFotoIDProperty
    {
        public long? AtendimentoFotoID { get; set; }
        public long? AtendimentoID { get; set; }

        [NotMapped]
        public bool JaExibidaNaListagem { get; set; }
    }
}
