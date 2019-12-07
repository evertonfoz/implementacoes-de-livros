using System.Collections.Generic;
using ModelProject;
using System;

namespace PersistenceProject
{
    public class Repository
    {
        private IList<Fornecedor> fornecedores = new List<Fornecedor>();
        private IList<Produto> produtos = new List<Produto>();
        private IList<NotaEntrada> notasEntrada = new List<NotaEntrada>();

        public Fornecedor InsertFornecedor( Fornecedor fornecedor)
        {
            this.fornecedores.Add(fornecedor);
            return fornecedor;
        }

        public void RemoveFornecedor(Fornecedor fornecedor)
        {
            this.fornecedores.Remove(fornecedor);
        }

        public IList<Fornecedor> GetAllFornecedores()
        {
            return this.fornecedores;
        }

        public Fornecedor UpdateFornecedor(Fornecedor fornecedor)
        {
            this.fornecedores[this.fornecedores.IndexOf(fornecedor)] = fornecedor;
            return fornecedor;
        }

        public NotaEntrada InsertNotaEntrada(NotaEntrada notaEntrada)
        {
            this.notasEntrada.Add(notaEntrada);
            return notaEntrada;
        }

        public void RemoveNotaEntrada(NotaEntrada notaEntrada)
        {
            this.notasEntrada.Remove(notaEntrada);
        }

        public IList<NotaEntrada> GetAllNotasEntrada()
        {
            return this.notasEntrada;
        }

        public NotaEntrada UpdateNotaEntrada(NotaEntrada notaEntrada)
        {
            this.notasEntrada[this.notasEntrada.IndexOf(notaEntrada)] = notaEntrada;
            return notaEntrada;
        }

        public Produto InsertProduto(Produto produto)
        {
            this.produtos.Add(produto);
            return produto;
        }

        public void RemoveProduto(Produto produto)
        {
            this.produtos.Remove(produto);
        }

        public IList<Produto> GetAllProdutos()
        {
            return this.produtos;
        }

        public Produto UpdateProduto(Produto produto)
        {
            this.produtos[this.produtos.
               IndexOf(produto)] = produto;
            return produto;
        }

        public NotaEntrada GetNotaEntradaById(Guid Id)
        {
            var notaEntrada = this.notasEntrada[
                this.notasEntrada.IndexOf(new NotaEntrada() { Id = Id })];
            return notaEntrada;
        }
    }
}
