using System.Collections.Generic;

namespace SegundoProjeto
{
    class Aluno
    {
        public string Nome { get; set; }
        public string RA { get; set; }
        public HashSet<Curso> Cursos { get; } = new HashSet<Curso>();

        public override bool Equals(object obj)
        {
            if (obj is Aluno aluno)
            {
                return RA.Equals(aluno.RA);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 11 + (RA == null ? 0 : RA.GetHashCode());
        }
    }
}
