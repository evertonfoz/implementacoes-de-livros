using CasaDoCodigo.DataAccess;
using CasaDoCodigo.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CasaDoCodigo.DAL
{
    public abstract class DALBase<T> : IDAL<T> where T : class
    {
        protected DatabaseContext context;
        protected string dbPath;

        public DALBase(string dbPath)
        {
            this.dbPath = dbPath;
        }

        public virtual async Task DeleteAsync(T item)
        {
            using (var context = DatabaseContext.GetContext(dbPath))
            {
                context.Remove(item);
                await context.SaveChangesAsync();
            }
        }

        public async virtual Task<List<T>> GetAllAsync(string campoClassificacao = null)
        {
            using (var context = DatabaseContext.GetContext(this.dbPath))
            {
                var query = context.Set<T>().AsNoTracking();

                if (!string.IsNullOrEmpty(campoClassificacao))
                {
                    var parameter = Expression.Parameter(typeof(T));
                    var sortExpression = Expression.Lambda<Func<T, object>>(Expression.Property(parameter, campoClassificacao), parameter);
                    query = query.OrderBy(sortExpression);
                }

                return await query.ToListAsync();
            }
        }

        public Task<T> GetByIdAsync(long? id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T>> GetStartsWithByFieldAsync(string field, string value)
        {
            throw new System.NotImplementedException();
        }

        public virtual async Task<T> UpdateAsync(T item, long? itemID)
        {
            using (var context = DatabaseContext.GetContext(dbPath))
            {
                if (itemID != null)
                {
                    context.Update(item);
                }
                else
                {
                    await context.AddAsync(item);
                }
                await context.SaveChangesAsync();
            }
            return item;
        }
    }
}
