using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDPropertiesEF.Models
{
    public class PecaIDProperty
    {
        [Key]
        public Guid PecaID { get; set; }

        [NotMapped]
        public virtual string ValorFormatado { get { return string.Empty; } }
        [NotMapped]
        public bool NotificarListView { get; set; }
        [NotMapped]
        public byte[] ImagemEmBytes { get; set; }
    }
}
