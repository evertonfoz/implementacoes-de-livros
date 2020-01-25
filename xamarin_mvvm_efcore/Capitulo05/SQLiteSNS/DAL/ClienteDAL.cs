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
            return await Task.FromResult(context.GetConnection().Table<Cliente>());
            //return await Task.FromResult(context.GetConnection().Query<Cliente>("select * from Cliente"));
        }
    }
}
