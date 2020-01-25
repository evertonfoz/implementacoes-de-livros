using System.ComponentModel.DataAnnotations.Schema;

namespace CasaDoCodigo.Models
{
    public class ServicoIDProperty
    {
        public long? ServicoID { get; set; }

        [NotMapped]
        public virtual string ValorFormatado { get { return string.Empty; } }
        [NotMapped]
        public bool NotificarListView { get; set; }
    }
}
