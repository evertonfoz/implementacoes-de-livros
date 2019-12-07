using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ADO_NETProject01
{
    public class DAL_NotaEntrada {
        private SqlConnection connection = DBConnection.DB_Connection;

        private void Insert(NotaEntrada notaEntrada) {
            var command = new SqlCommand("insert into " +
                "NOTASDEENTRADA(IdFornecedor, Numero, "+
                "DataEmissao, DataEntrada) values(" +
                "@IdFornecedor, @Numero, @DataEmissao, " +
                "@DataEntrada)", connection);
            command.Parameters.AddWithValue("@IdFornecedor", 
                notaEntrada.FornecedorNota.Id);
            command.Parameters.AddWithValue("@Numero", 
                notaEntrada.Numero);
            command.Parameters.AddWithValue("@DataEmissao", 
                notaEntrada.DataEmissao);
            command.Parameters.AddWithValue("@DataEntrada", 
                notaEntrada.DataEntrada);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void Update(NotaEntrada notaEntrada)
        {
            var command = new SqlCommand("update NOTASDEENTRADA " +
                "set IdFornecedor=@IdFornecedor, Numero=@Numero, " +
                "DataEmissao=@DataEmissao, DataEntrada=" +
                "@DataEntrada where (Id=@Id)", connection);
            command.Parameters.AddWithValue("@IdFornecedor",
                notaEntrada.FornecedorNota.Id);
            command.Parameters.AddWithValue("@Numero",
                notaEntrada.Numero);
            command.Parameters.AddWithValue("@DataEmissao",
                notaEntrada.DataEmissao);
            command.Parameters.AddWithValue("@DataEntrada",
                notaEntrada.DataEntrada);
            command.Parameters.AddWithValue("@Id",
                notaEntrada.Id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            DeleteAllProdutosFromNotaEntrada(notaEntrada.Id);
            InsertProdutosNotaDeEntrada(notaEntrada.Id,
                notaEntrada.Produtos);
        }

        private void DeleteAllProdutosFromNotaEntrada(long? idNotaEntrada)
        {
            var command = new SqlCommand("delete from " +
                "NOTASDEENTRADA where (Id=@Id)", connection);
            command.Parameters.AddWithValue("@Id",
                idNotaEntrada);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void InsertProdutosNotaDeEntrada(long? idNotaEntrada,
            IList<ProdutoNotaEntrada> produtos)
        {
            var command = new SqlCommand("insert into " +
                "PRODUTOSNOTASDEENTRADA(IdNotaDeEntrada, " +
                "IdProduto, PrecoCustoCompra, QuantidadeCompra) " +
                "values(@IdNotaDeEntrada, @IdProduto, " +
                "@PrecoCustoCompra, @QuantidadeCompra",
                connection);
            connection.Open();
            foreach (var produto in produtos)
            {
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@IdNotaDeEntrada",
                    idNotaEntrada);
                command.Parameters.AddWithValue("@IdProduto",
                    produto.Id);
                command.Parameters.AddWithValue(
                    "@PrecoCustoCompra", produto.PrecoCustoCompra);
                command.Parameters.AddWithValue(
                    "@QuantidadeCompra", produto.
                    QuantidadeComprada);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public void Save(NotaEntrada notaEntrada)
        {
            if (notaEntrada.Id == null)
                this.Insert(notaEntrada);
            else
                this.Update(notaEntrada);
        }
    }
}