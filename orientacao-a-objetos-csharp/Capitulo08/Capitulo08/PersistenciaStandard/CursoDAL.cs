using Modelo;
using System.Collections.Generic;
using System.Linq;

namespace Persistencia
{
    public class CursoDAL
    {
        private EFContext context;
        public IList<Curso> TodosOsCursos()
        {
            using (var context = new EFContext())
            {
                return context.Cursos.ToList<Curso>();
            }
        }

        public void Gravar(Curso curso)
        {
            using (var context = new EFContext())
            {
                context.Cursos.Add(curso);
                context.SaveChanges();
            }
        }
    }
}
