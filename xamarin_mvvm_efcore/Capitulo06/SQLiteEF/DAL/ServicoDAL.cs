using CasaDoCodigo.DataAccess.Interfaces;
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

        public async override Task<List<Servico>> GetAllAsync(string campoClassificacao = null, OrderByType orderByType = OrderByType.NaoClassificado)
        {
            campoClassificacao = string.IsNullOrEmpty(campoClassificacao) ? nameof(Servico.Nome) : campoClassificacao;
            orderByType = orderByType == OrderByType.NaoClassificado ? OrderByType.Ascendente : orderByType;
            return await base.GetAllAsync(campoClassificacao, orderByType);
        }
    }
}
