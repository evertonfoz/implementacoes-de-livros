using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CasaDoCodigo.DataAccess.Interfaces
{
    public enum OrderByType { NaoClassificado = 0, Ascendente, Descendente };
    public interface IDAL<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, object>> expression = null, OrderByType orderByType = OrderByType.Ascendente);
        Task<T> UpdateAsync(T item, long? itemID, params object[] associatedObjects);
        Task DeleteAsync(T item);
        Task<T> GetByIdAsync(long? id);
        Task<IEnumerable<T>> GetStartsWithByFieldAsync(string field, string value);
        T GetById(long? id, params string[] includeProperties);
    }
}
