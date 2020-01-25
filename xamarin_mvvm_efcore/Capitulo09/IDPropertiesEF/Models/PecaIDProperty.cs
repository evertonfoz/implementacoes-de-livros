using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasaDoCodigo.Models
{
    public class PecaIDProperty
    {
        [Key]
        public Guid PecaID { get; set; }

        [NotMapped]
        public virtual string ValorFormatado { get { return string.Empty; } }
        [NotMapped]
        public byte[] ImagemEmBytes { get; set; }
        [NotMapped]
        public bool NotificarListView { get; set; }
    }
}
