using System;
using System.Collections.Generic;

namespace SegundoProjeto
{
    class Professor
    {
        public string Nome { get; set; }
        public DateTime Contratacao { get; set; }
        public HashSet<Curso> Cursos { get; } = new HashSet<Curso>();

        public override bool Equals(object obj)
        {
            if (obj is Professor professor)
            {
                return Nome.Equals(professor.Nome);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 11 + (Nome == null ? 0 : Nome.GetHashCode());
        }
    }
}
