using System.Collections.Generic;

namespace SegundoProjeto
{
    interface IRepositorio<T>
    {
        void Adicionar(T item);
        void Remover(T item);
        IList<T> RecuperarTodos();
    }
}
