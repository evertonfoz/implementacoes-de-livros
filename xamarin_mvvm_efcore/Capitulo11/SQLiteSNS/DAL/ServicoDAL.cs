using CasaDoCodigo.DataAccess;
using CasaDoCodigo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaDoCodigo.DAL
{
    public class ServicoDAL : DALBase<Servico>
    {
        public ServicoDAL(DatabaseContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Servico>> GetAllAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(context.GetConnection().Query<Servico>("select * from Servico"));
        }

        public async override Task<IEnumerable<Servico>> GetStartsWithByFieldAsync(string field, string value)
        {
            var lambda = base.GetLambda(field, value);
            return await Task.FromResult(context.GetConnection().Table<Servico>().Where(lambda));
        }

        public override async Task<Servico> GetByIdAsync(long? id)
        {
            return await Task.FromResult(context.GetConnection().Table<Servico>().Where(s => s.ServicoID.Equals(id)).FirstOrDefault());
        }
    }
}
