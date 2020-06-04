using Modelo.Discente;
using System.Linq;
using System.Threading.Tasks;

namespace Capitulo05.Data.DAL.Discente
{
    public class AcademicoDAL
    {
        private IESContext _context;

        public AcademicoDAL(IESContext context)
        {
            _context = context;
        }

        public IQueryable<Academico> ObterAcademicosClassificadosPorNome()
        {
            return _context.Academicos.OrderBy(b => b.Nome);
        }

        public async Task<Academico> ObterAcademicoPorId(long id)
        {
            return await _context.Academicos.FindAsync(id);
        }

        public async Task<Academico> GravarAcademico(Academico academico)
        {
            if (academico.AcademicoID == null)
            {
                _context.Academicos.Add(academico);
            }
            else
            {
                _context.Update(academico);
            }
            await _context.SaveChangesAsync();
            return academico;
        }

        public async Task<Academico> EliminarAcademicoPorId(long id)
        {
            Academico academico = await ObterAcademicoPorId(id);
            _context.Academicos.Remove(academico);
            await _context.SaveChangesAsync();
            return academico;
        }
    }
}