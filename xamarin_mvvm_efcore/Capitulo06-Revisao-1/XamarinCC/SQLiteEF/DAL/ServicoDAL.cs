using CasaDoCodigo.DAL;
using CasaDoCodigo.DataAccess.Interfaces;
using OficinaModels.Cadastros;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLiteEF.DAL
{
    public class ServicoDAL : DALBase<Servico>
    {
        public ServicoDAL(string dbPath) : base(dbPath)
        {
        }

        public async override Task<List<Servico>> GetAllAsync(string campoClassificacao = null, OrderByType orderByType = OrderByType.NaoClassificado)
        {
            campoClassificacao = string.IsNullOrEmpty(campoClassificacao) ? nameof(Servico.Nome) : campoClassificacao;
            orderByType = orderByType == OrderByType.NaoClassificado ? OrderByType.Descendente : orderByType;
            return await base.GetAllAsync(campoClassificacao, orderByType);
        }
    }
}
