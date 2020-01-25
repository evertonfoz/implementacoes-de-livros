using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CasaDoCodigo.DataAccess;
using CasaDoCodigo.DataAccess.Interfaces;
using CasaDoCodigo.Models;

namespace CasaDoCodigo.DAL
{
    public class ClienteDAL : DALBase<Cliente>
    {
        public ClienteDAL(string dbPath) : base(dbPath)
        {
        }

        public async override Task<List<Cliente>> GetAllAsync(string campoClassificacao = null, OrderByType orderByType = OrderByType.NaoClassificado)
        {
            campoClassificacao = string.IsNullOrEmpty(campoClassificacao) ? nameof(Servico.Nome) : campoClassificacao;
            orderByType = orderByType == OrderByType.NaoClassificado ? OrderByType.Ascendente : orderByType;
            return await base.GetAllAsync(campoClassificacao, orderByType);
        }
    }
}
