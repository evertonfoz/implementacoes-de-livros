using System.Collections.Generic;

namespace Modelo.Cadastros
{
    public class Disciplina
    {
        public long? DisciplinaID { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<CursoDisciplina> CursosDisciplinas { get; set; }
    }
}
