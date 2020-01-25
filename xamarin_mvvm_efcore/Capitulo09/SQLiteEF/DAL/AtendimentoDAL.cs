using CasaDoCodigo.DataAccess;
using CasaDoCodigo.DataAccess.Interfaces;
using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CasaDoCodigo.DAL
{
    public class AtendimentoDAL : DALBase<Atendimento>
    {
        public AtendimentoDAL(string dbPath) : base(dbPath)
        {
        }

        public async override Task<List<Atendimento>> GetAllAsync(Expression<Func<Atendimento, object>> expression = null, OrderByType orderByType = OrderByType.NaoClassificado)
        {
            expression = (expression == null) ? (a => a.DataHoraChegada) : expression;
            orderByType = orderByType == OrderByType.NaoClassificado ? OrderByType.Descendente : orderByType;

            using (var context = DatabaseContext.GetContext(dbPath))
            {
                var query = PrepareDataToGetlAll(context, expression, orderByType);
                query = query.Include(nameof(Atendimento.Cliente));
                return await query.ToListAsync();
            }
        }

        public async override Task DeleteAsync(Atendimento atendimento, object databaseContext = null)
        {
            using (var context = DatabaseContext.GetContext(dbPath))
            {
                var servicosDAL = new AtendimentoItemDAL(atendimento, dbPath);
                var fotosDAL = new AtendimentoFotoDAL(atendimento, dbPath);

                context.AtendimentoItens.RemoveRange(await servicosDAL.GetAllAsync());
                context.AtendimentoFotos.RemoveRange(await fotosDAL.GetAllAsync());
                await base.DeleteAsync(atendimento, context);
            }
        }

        public override async Task<Atendimento> GetByIdAsync(long? id)
        {
            return await context.Atendimentos.Include(c => c.Cliente).SingleOrDefaultAsync(a => a.AtendimentoID == id);
        }
    }
}
