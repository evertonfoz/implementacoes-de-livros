using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using Modelo.Docente;
using System.Linq;

namespace Capitulo05.Data.DAL.Cadastros
{
    public class CursoDAL
    {
        private IESContext _context;

        public CursoDAL(IESContext context)
        {
            _context = context;
        }

        public void RegistrarProfessor(long cursoID, long professorID)
        {
            var curso = _context.Cursos.Where(c => c.CursoID == cursoID).Include(cp => cp.CursosProfessores).First();
            var professor = _context.Professores.Find(professorID);
            curso.CursosProfessores.Add(new CursoProfessor() { Curso = curso, Professor = professor });
            _context.SaveChanges();
        }

        public IQueryable<Curso> ObterCursosPorDepartamento(long departamentoID)
        {
            var cursos = _context.Cursos.Where(c => c.DepartamentoID == departamentoID).OrderBy(d => d.Nome);
            return cursos;
        }

        public IQueryable<Professor> ObterProfessoresForaDoCurso(long cursoID)
        {
            var curso = _context.Cursos.Where(c => c.CursoID == cursoID).Include(cp => cp.CursosProfessores).First();
            var professoresDoCurso = curso.CursosProfessores.Select(cp => cp.ProfessorID).ToArray();
            var professoresForaDoCurso = _context.Professores.Where(p => !professoresDoCurso.Contains(p.ProfessorID));
            return professoresForaDoCurso;
        }
    }
}
