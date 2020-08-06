using CasaDoCodigo.DAL;
using CasaDoCodigo.DataAccess.Interfaces;
using OficinaModels.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SQLiteEF.DAL
{
    public class ServicoDAL : DALBase<Servico>
    {
        public ServicoDAL(string dbPath) : base(dbPath)
        {
        }

        public async override Task<List<Servico>> GetAllAsync(Expression<Func<Servico, object>> expression = null, OrderByType orderByType = OrderByType.NaoClassificado)
        {
            expression = (expression == null) ? (s => s.Nome) : expression;
            orderByType = orderByType == OrderByType.NaoClassificado ? OrderByType.Ascendente : orderByType;
            return await base.GetAllAsync(expression, orderByType);
        }
    }
}
