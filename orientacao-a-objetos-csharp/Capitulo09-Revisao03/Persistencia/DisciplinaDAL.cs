using Microsoft.EntityFrameworkCore;
using Modelo;
using System.Collections.Generic;
using System.Linq;

namespace Persistencia
{
    public class DisciplinaDAL
    {
        public IList<Disciplina> TodosAsDisciplinas()
        {
            using (var context = new EFContext())
            {
                return context.Disciplinas.Include(d => d.Curso).ToList<Disciplina>();
            }
        }

        public void Gravar(Disciplina disciplina)
        {
            using (var context = new EFContext())
            {
                if (disciplina.DisciplinaID > 0)
                    context.Entry(disciplina).State = EntityState.Modified;
                else
                    context.Disciplinas.Add(disciplina);
                context.SaveChanges();
            }
        }
        public Disciplina ObterPorId(long disciplinaID)
        {
            using (var context = new EFContext())
            {
                var disciplina = context.Disciplinas.Single(d => d.DisciplinaID == disciplinaID);
                context.Entry(disciplina).Reference(d => d.Curso).Load();
                return disciplina;
            }
        }
        public void Remover(long disciplinaID)
        {
            using (var context = new EFContext())
            {
                var disciplina = context.Disciplinas.Single(d => d.DisciplinaID == disciplinaID);
                context.Disciplinas.Remove(disciplina);
                context.SaveChanges();
            }
        }

    }
}
