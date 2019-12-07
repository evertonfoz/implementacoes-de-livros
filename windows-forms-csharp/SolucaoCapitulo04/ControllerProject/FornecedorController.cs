using System.Collections.Generic;
using ModelProject;
using PersistenceProject;

namespace ControllerProject
{
    public class FornecedorController
    {
        private Repository repository = new Repository();

        public Fornecedor Insert(Fornecedor fornecedor)
        {
            return this.repository.InsertFornecedor(fornecedor);
        }

        public void Remove(Fornecedor fornecedor)
        {
            this.repository.RemoveFornecedor(fornecedor);
        }

        public IList<Fornecedor> GetAll()
        {
            return this.repository.GetAllFornecedores();
        }

        public Fornecedor Update(Fornecedor fornecedor)
        {
            return this.repository.UpdateFornecedor(fornecedor);
        }
    }
}
