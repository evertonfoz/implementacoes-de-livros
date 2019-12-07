using System.Collections.Generic;

namespace Modelo.Docente
{
    public class Professor
    {
        public long? ProfessorID { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<CursoProfessor> CursosProfessores { get; set; }
    }
}
