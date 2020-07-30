using CasaDoCodigo.DAL;
using CasaDoCodigo.DataAccess;
using CasaDoCodigo.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using OficinaModels.Atendimentos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLiteEF.DAL
{
    public class AtendimentoDAL : DALBase<Atendimento>
    {
        public AtendimentoDAL(string dbPath) : base(dbPath)
        {
        }
        public async override Task<List<Atendimento>> GetAllAsync(string campoClassificacao = null, OrderByType orderByType = OrderByType.NaoClassificado)
        {
            campoClassificacao = string.IsNullOrEmpty(campoClassificacao) ? nameof(Atendimento.DataHoraChegada) : campoClassificacao;
            orderByType = orderByType == OrderByType.NaoClassificado ? OrderByType.Descendente : orderByType;

            using (var context = DatabaseContext.GetContext(dbPath))
            {
                var query = PrepareDataToGetAll(context, campoClassificacao, orderByType);
                query = query.Include(a => a.Cliente);
                return await query.ToListAsync();
            }
        }
        public override async Task<Atendimento> GetByIdAsync(long? id)
        {
            return await context.Atendimentos.Include(c => c.Cliente).SingleOrDefaultAsync(a => a.AtendimentoID == id);
        }
    }
}
