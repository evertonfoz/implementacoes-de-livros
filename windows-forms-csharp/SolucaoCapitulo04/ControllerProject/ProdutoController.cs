using System.Collections.Generic;
using ModelProject;
using PersistenceProject;

namespace ControllerProject
{
    public class ProdutoController
    {
        private Repository repository = new Repository();

        public Produto Insert(Produto produto)
        {
            return this.repository.InsertProduto(produto);
        }

        public void Remove(Produto produto)
        {
            this.repository.RemoveProduto(produto);
        }

        public IList<Produto> GetAll()
        {
            return this.repository.GetAllProdutos();
        }

        public Produto Update(Produto produto)
        {
            return this.repository.UpdateProduto(produto);
        }
    }
}
