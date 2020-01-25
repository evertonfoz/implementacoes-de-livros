using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CasaDoCodigo.DataAccess.Interfaces
{
    public enum OrderByType { NaoClassificado = 0, Ascendente, Descendente };

    public interface IDAL<T>
    {
        Task<List<T>> GetAllAsync(string campoClassificacao = null, OrderByType orderByType = OrderByType.NaoClassificado);
        Task<T> UpdateAsync(T item, long? itemID, params object[] associatedObjects);
        Task DeleteAsync(T item);
        Task<T> GetByIdAsync(long? id);
        T GetById(long? id, params string[] includeProperties);
        Task<IEnumerable<T>> GetStartsWithByFieldAsync(string field, string value);
    }
}
