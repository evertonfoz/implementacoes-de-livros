using System.Collections.Generic;

namespace SegundoProjeto
{
    class RepositorioCurso : IRepositorio<Curso>
    {
        private IList<Curso> cursos = new List<Curso>();

        public void Adicionar(Curso curso)
        {
            cursos.Add(curso);
        }

        public void Remover(Curso curso)
        {
            cursos.Remove(curso);
        }

        public IList<Curso> RecuperarTodos()
        {
            return cursos;
        }
    }
}
