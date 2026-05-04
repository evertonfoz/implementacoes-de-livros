using System.Collections.Generic;

namespace Modelo
{
    public class Curso
    {
        public long CursoID { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public virtual List<Disciplina> Disciplinas { get; set; }
    }
}
