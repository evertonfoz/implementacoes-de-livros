using SQLite;
using System;
using System.IO;

namespace CasaDoCodigo.Models
{
    public class PecaIDProperty
    {
        [PrimaryKey]
        public Guid PecaID { get; set; }
    }
}
