using CasaDoCodigo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaDoCodigo.DAL
{
    public class ServicoDAL : DALBase<Servico>
    {
        public ServicoDAL(string dbPath) : base(dbPath)
        {
        }

        public async override Task<List<Servico>> GetAllAsync(string campoClassificacao)
        {
            campoClassificacao = string.IsNullOrEmpty(campoClassificacao) ? nameof(Servico.Nome) : campoClassificacao;
            return await base.GetAllAsync(campoClassificacao);
        }
    }
}
