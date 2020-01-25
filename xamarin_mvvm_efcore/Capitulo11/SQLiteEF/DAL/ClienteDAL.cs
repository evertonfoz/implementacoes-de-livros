using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CasaDoCodigo.DataAccess;
using CasaDoCodigo.DataAccess.Interfaces;
using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.DAL
{
    public class ClienteDAL : DALBase<Cliente>
    {
        public ClienteDAL(string dbPath) : base(dbPath)
        {
        }

        public async override Task<List<Cliente>> GetAllAsync(Expression<Func<Cliente, object>> expression = null, OrderByType orderByType = OrderByType.NaoClassificado)
        {
            expression = (expression == null) ? (c => c.Nome) : expression;
            orderByType = orderByType == OrderByType.NaoClassificado ? OrderByType.Ascendente : orderByType;
            return await base.GetAllAsync(expression, orderByType);
        }

        public async Task<IEnumerable<Atendimento>> GetAtendimentosAsync(Cliente cliente)
        {
            return await context.Atendimentos.Where(a => a.ClienteID == cliente.ClienteID).ToListAsync();
        }
    }
}
