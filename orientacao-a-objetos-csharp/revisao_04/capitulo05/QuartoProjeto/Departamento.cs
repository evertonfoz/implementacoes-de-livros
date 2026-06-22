using System.Collections.Generic;
using System.Linq;

namespace SegundoProjeto
{
    class Departamento
    {
        public string Nome { get; set; }
        public HashSet<Curso> Cursos { get; } = new HashSet<Curso>();

        public void RegistrarCurso(Curso c)
        {
            Cursos.Add(c);
        }

        public int ObterQuantidadeDeCursos()
        {
            return Cursos.Count;
        }

        public Curso ObterCursoPorNome(string nome)
        {
            return Cursos.FirstOrDefault(c => c.Nome.Equals(nome));
        }

        public override bool Equals(object obj)
        {
            if (obj is Departamento departamento)
            {
                return Nome.Equals(departamento.Nome);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 11 + (Nome == null ? 0 : Nome.GetHashCode());
        }
    }
}
