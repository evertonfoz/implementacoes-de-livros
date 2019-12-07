using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Discente
{
    public class Academico
    {
        [DisplayName("Id")]
        public long? AcademicoID { get; set; }

        [StringLength(10, MinimumLength = 10)]
        [RegularExpression("([0-9]{10})")]
        [Required]
        [DisplayName("RA")]
        public string RegistroAcademico { get; set; }

        [Required]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
//        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime? Nascimento { get; set; }

        public string FotoMimeType { get; set; }
        public byte[] Foto { get; set; }

        [NotMapped]
        public IFormFile FormFile { get; set; }
    }
}
