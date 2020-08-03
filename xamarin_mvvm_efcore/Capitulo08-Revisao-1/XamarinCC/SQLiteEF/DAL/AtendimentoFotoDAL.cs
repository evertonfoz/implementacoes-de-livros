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
    public class AtendimentoFotoDAL : DALBase<AtendimentoFoto>
    {
        private Atendimento Atendimento { get; set; }

        public AtendimentoFotoDAL(Atendimento atendimento, string dbPath) : base(dbPath)
        {
            this.Atendimento = atendimento;
        }

        public async override Task<List<AtendimentoFoto>> GetAllAsync(Expression<Func<AtendimentoFoto, object>> expression = null, OrderByType orderByType = OrderByType.NaoClassificado)
        {
            using (var context = DatabaseContext.GetContext(dbPath))
            {
                var query = PrepareDataToGetlAll(context, expression, orderByType);
                query = query.Where(i => i.AtendimentoID == Atendimento.AtendimentoID);
                return await query.ToListAsync();
            }
        }
        public async override Task<AtendimentoFoto> UpdateAsync(AtendimentoFoto foto, long? itemID, params object[] associatedObjects)
        {
            return await base.UpdateAsync(foto, itemID, foto.Atendimento);
        }

    }
}
