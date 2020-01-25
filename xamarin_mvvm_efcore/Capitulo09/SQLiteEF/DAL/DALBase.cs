using CasaDoCodigo.DataAccess;
using CasaDoCodigo.DataAccess.Interfaces;
using CasaDoCodigo.ExtensionMethods;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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

        public virtual async Task DeleteAsync(T item, object databaseContext = null)
        {
            using (var context = (databaseContext == null) ? DatabaseContext.GetContext(dbPath) : (DatabaseContext) databaseContext)
            {
                context.Entry(item).State = EntityState.Unchanged;
                context.Remove(item);
                await context.SaveChangesAsync();
            }
        }

        protected IQueryable<T> PrepareDataToGetlAll(DatabaseContext context, Expression<Func<T, object>> expression, OrderByType orderByType)
        {
            var query = context.Set<T>().AsNoTracking();
            if (expression != null)
            {
                if (orderByType == OrderByType.Descendente)
                    query = query.OrderByDescending(expression);
                else
                    query = query.OrderBy(expression);
            }

            return query;
        }

        public async virtual Task<List<T>> GetAllAsync(Expression<Func<T, object>> expression = null, OrderByType orderByType = OrderByType.NaoClassificado)
        {
            using (var context = DatabaseContext.GetContext(this.dbPath))
            {
                var query = PrepareDataToGetlAll(context, expression, orderByType);
                return await query.ToListAsync();
            }
        }

        public virtual T GetById(long? id, params string[] includeProperties)
        {
            using (var context = DatabaseContext.GetContext(dbPath)) {
                var result = context.Set<T>().Find(id);
                for (int i = 0; i < includeProperties.Count(); i++)
                {
                    context.Entry(result).Reference(includeProperties[i]).Load();
                }
                return result;
            }
        }

        public virtual Task<T> GetByIdAsync(long? id)
        {
            throw new NotImplementedException();
        }

        public async virtual Task<IEnumerable<T>> GetStartsWithByFieldAsync(string field, string value)
        {
            using (var context = DatabaseContext.GetContext(dbPath))
            {
                ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "t");
                MemberExpression memberExpression = Expression.Property(parameterExpression, field);
                ConstantExpression constantExpression = Expression.Constant(value, typeof(string));
                MethodInfo methodInfo = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
                Expression call = Expression.Call(memberExpression, methodInfo, constantExpression);

                Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(call, parameterExpression);
                return await context.Set<T>().Where(lambda).ToArrayAsync();
            }
        }

        public async virtual Task<T> UpdateAsync(T item, long? itemID, params object[] associatedObjects)
        {
            using (var context = DatabaseContext.GetContext(dbPath))
            {
                foreach (var associated in associatedObjects)
                {
                    context.Entry(associated).State = EntityState.Unchanged;
                }

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
