using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CasaDoCodigo.DataAccess;
using CasaDoCodigo.Models;

namespace CasaDoCodigo.DAL
{
    public class ClienteDAL : DALBase<Cliente>
    {
        public ClienteDAL(string dbPath) : base(dbPath)
        {
        }

        public async override Task<List<Cliente>> GetAllAsync(string campoClassificacao)
        {
            campoClassificacao = string.IsNullOrEmpty(campoClassificacao) ? nameof(Cliente.Nome) : campoClassificacao;
            return await base.GetAllAsync(campoClassificacao);
        }
    }
}
