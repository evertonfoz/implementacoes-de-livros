using System;
using System.Collections.Generic;
using System.Text;

namespace WPFAppEFCore.POCO
{
    public class Cidade
    {
        public long Id { get; set; }
        public string Nome { get; set; }

        public long EstadoId { get; set; }
        public virtual Estado Estado { get; set; }
    }
}
