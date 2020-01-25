using CasaDoCodigo.DataAccess;
using CasaDoCodigo.DataAcess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
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

        public virtual async Task<T> GetByIdAsync(long? id)
        {
            throw new System.NotImplementedException();
        }

        public Expression<Func<T, bool>> GetLambda(string field, string value)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "t");
            MemberExpression memberExpression = Expression.Property(parameterExpression, field);
            ConstantExpression constantExpression = Expression.Constant(value, typeof(string));
            MethodInfo methodInfo = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
            Expression call = Expression.Call(memberExpression, methodInfo, constantExpression);

            return Expression.Lambda<Func<T, bool>>(call, parameterExpression);
        }

        public virtual Task<IEnumerable<T>> GetStartsWithByFieldAsync(string field, string value)
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
