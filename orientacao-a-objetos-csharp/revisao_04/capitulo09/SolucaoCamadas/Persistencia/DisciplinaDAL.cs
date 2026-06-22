using Microsoft.EntityFrameworkCore;
using Modelo;
using System.Collections.Generic;
using System.Linq;

namespace Persistencia
{
    public class DisciplinaDAL
    {
        public void Gravar(Disciplina disciplina)
        {
            using (var context = new EFContext())
            {
                if (disciplina.DisciplinaId == null)
                    context.Disciplinas.Add(disciplina);
                else
                    context.Disciplinas.Update(disciplina);

                context.SaveChanges();
            }
        }

        public List<Disciplina> ObterTodas()
        {
            using (var context = new EFContext())
            {
                return context.Disciplinas
                    .Include(d => d.Curso)
                    .ToList();
            }
        }

        public Disciplina? ObterPorId(long id)
        {
            using (var context = new EFContext())
            {
                return context.Disciplinas
                    .Include(d => d.Curso)
                    .FirstOrDefault(d => d.DisciplinaId == id);
            }
        }

        public void Remover(Disciplina disciplina)
        {
            using (var context = new EFContext())
            {
                context.Disciplinas.Remove(disciplina);
                context.SaveChanges();
            }
        }
    }
}
