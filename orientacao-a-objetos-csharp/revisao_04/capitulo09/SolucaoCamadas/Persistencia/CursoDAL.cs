using System.Collections.Generic;
using System.Linq;
using Modelo;

namespace Persistencia
{
    public class CursoDAL
    {
        public void Gravar(Curso curso)
        {
            using (var context = new EFContext())
            {
                if (curso.CursoId == 0)
                    context.Cursos.Add(curso);
                else
                    context.Cursos.Update(curso);

                context.SaveChanges();
            }
        }

        public List<Curso> ObterTodos()
        {
            using (var context = new EFContext())
            {
                return context.Cursos.ToList();
            }
        }

        public Curso? ObterPorId(long id)
        {
            using (var context = new EFContext())
            {
                return context.Cursos.Find(id);
            }
        }

        public void Remover(Curso curso)
        {
            using (var context = new EFContext())
            {
                context.Cursos.Remove(curso);
                context.SaveChanges();
            }
        }
    }
}
