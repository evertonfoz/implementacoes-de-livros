using System.Collections.Generic;

namespace Capitulo05.Services
{
    public interface IDataStore<T>
    {
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        T GetById(long? id);
        IEnumerable<T> GetAll();
    }
}
