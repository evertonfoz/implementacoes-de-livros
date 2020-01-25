using System.Collections.Generic;
using System.Threading.Tasks;
using CasaDoCodigo.DataAccess;
using CasaDoCodigo.Models;

namespace CasaDoCodigo.DAL
{
    public class ClienteDAL : DALBase<Cliente>
    {
        public ClienteDAL(DatabaseContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Cliente>> GetAllAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(context.GetConnection().Query<Cliente>("select * from Cliente"));
        }

        public override async Task<Cliente> GetByIdAsync(long? id)
        {
            return await Task.FromResult(context.GetConnection().Table<Cliente>().Where(c => c.ClienteID.Equals(id)).FirstOrDefault());
        }

        public async override Task<IEnumerable<Cliente>> GetStartsWithByFieldAsync(string field, string value)
        {
            var lambda = base.GetLambda(field, value);
            return await Task.FromResult(context.GetConnection().Table<Cliente>().Where(lambda));
        }
    }
}
