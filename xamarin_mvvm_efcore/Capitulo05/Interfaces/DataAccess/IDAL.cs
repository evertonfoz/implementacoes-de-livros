using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaDoCodigo.DataAccess.Interfaces
{
    public interface IDAL<T>
    {
        Task<List<T>> GetAllAsync(string campoClassificacao = null);
        Task<T> UpdateAsync(T item, long? itemID);
        Task DeleteAsync(T item);
        Task<T> GetByIdAsync(long? id);
        Task<IEnumerable<T>> GetStartsWithByFieldAsync(string field, string value);
    }
}
