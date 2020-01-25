using CasaDoCodigo.DataAccess;
using CasaDoCodigo.DataAcess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaDoCodigo.DAL
{
    public abstract class DALBase<T> : IDAL<T> where T : class
    {
        protected DatabaseContext context;

        public DALBase(DatabaseContext context)
        {
            this.context = context;
        }

        public virtual async Task<bool> DeleteAsync(T item)
        {
            context.GetConnection().Delete(item);
            return await Task.FromResult(true);
        }


        public virtual Task<IEnumerable<T>> GetAllAsync(bool forceRefresh = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> GetByIdAsync(long? id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T>> GetStartsWithByFieldAsync(string field, string value)
        {
            throw new System.NotImplementedException();
        }

        public virtual async Task<bool> UpdateAsync(T item, long? itemId)
        {
            if (itemId == null)
            {
                context.GetConnection().Insert(item);
            }
            else
            {
                context.GetConnection().Update(item);
            }
            return await Task.FromResult(true);
        }
    }
}
