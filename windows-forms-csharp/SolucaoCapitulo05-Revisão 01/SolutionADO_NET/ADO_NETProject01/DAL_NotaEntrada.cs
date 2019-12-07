using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ADO_NETProject01
{
    public class DAL_NotaEntrada
    {
        private SqlConnection connection = DBConnection.DB_Connection;

        private void Insert(NotaEntrada notaEntrada)
        {
            var command = new SqlCommand("insert into " +
                "NOTASDEENTRADA(IdFornecedor, Numero, DataEmissao, DataEntrada) " +
                "values(@IdFornecedor, @Numero, @DataEmissao, @DataEntrada)", this.connection);
            command.Parameters.AddWithValue("@IdFornecedor", notaEntrada.FornecedorNota.Id);
            command.Parameters.AddWithValue("@Numero", notaEntrada.Numero);
            command.Parameters.AddWithValue("@DataEmissao", notaEntrada.DataEmissao);
            command.Parameters.AddWithValue("@DataEntrada", notaEntrada.DataEntrada);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void Update(NotaEntrada notaEntrada)
        {
            var command = new SqlCommand("update NOTASDEENTRADA set IdFornecedor=@IdFornecedor, " +
                "Numero=@Numero, DataEmissao=@DataEmissao, DataEntrada=@DataEntrada where (Id=@Id)", connection);
            command.Parameters.AddWithValue("@IdFornecedor", notaEntrada.FornecedorNota.Id);
            command.Parameters.AddWithValue("@Numero", notaEntrada.Numero);
            command.Parameters.AddWithValue("@DataEmissao", notaEntrada.DataEmissao);
            command.Parameters.AddWithValue("@DataEntrada", notaEntrada.DataEntrada);
            command.Parameters.AddWithValue("@Id", notaEntrada.Id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            DeleteAllProdutosFromNotaEntrada(notaEntrada.Id);
            InsertProdutosNotaDeEntrada(notaEntrada.Id, notaEntrada.Produtos);
        }

        private void InsertProdutosNotaDeEntrada(long? idNotaEntrada, IList<ProdutoNotaEntrada> produtos)
        {
            var command = new SqlCommand("insert into " +
                "PRODUTOSNOTASDEENTRADA(IdNotaDeEntrada, IdProduto, PrecoCustoCompra, QuantidadeCompra) " +
                "values(@IdNotaDeEntrada, @IdProduto, @PrecoCustoCompra, @QuantidadeCompra", connection);
            connection.Open();
            foreach (var produto in produtos)
            {
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@IdNotaDeEntrada", idNotaEntrada);
                command.Parameters.AddWithValue("@IdProduto", produto.Id);
                command.Parameters.AddWithValue("@PrecoCustoCompra", produto.PrecoCustoCompra);
                command.Parameters.AddWithValue("@QuantidadeCompra", produto.QuantidadeComprada);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        private void DeleteAllProdutosFromNotaEntrada(long? idNotaEntrada)
        {
            var command = new SqlCommand("delete from NOTASDEENTRADA where (Id=@Id)", connection);
            command.Parameters.AddWithValue("@Id", idNotaEntrada);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Save(NotaEntrada notaEntrada)
        {
            if (notaEntrada.Id == null)
                this.Insert(notaEntrada);
            else
                this.Update(notaEntrada);
        }

        public DataTable GetAllAsDataTable()
        {
            var adapter = new SqlDataAdapter("select notasdeentrada.id, idfornecedor, fornecedores.nome as fornecedor, numero, dataemissao, dataentrada from NOTASDEENTRADA, FORNECEDORES where NOTASDEENTRADA.IDFORNECEDOR = FORNECEDORES.ID", connection);
            var builder = new SqlCommandBuilder(adapter);

            var table = new DataTable();
            adapter.Fill(table);

            connection.Close();
            return table;
        }

        public NotaEntrada GetById(long id)
        {
            NotaEntrada notaEntrada = new NotaEntrada();
            DAL_Fornecedor dalFornecedor = new DAL_Fornecedor();
            long idFornecedorNota=-1;
            var command = new SqlCommand("select id, idfornecedor, numero, dataemissao, dataentrada from NOTASDEENTRADA where id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var teste = reader[1];
                    notaEntrada.Id = reader.GetInt64(0);
                    idFornecedorNota = reader.GetInt64(1);
                    notaEntrada.Numero = reader.GetString(2);
                    notaEntrada.DataEmissao = reader.GetDateTime(3);
                    notaEntrada.DataEntrada = reader.GetDateTime(4);
                } 
            }
            connection.Close();
            if (idFornecedorNota > 0)
               notaEntrada.FornecedorNota = dalFornecedor.GetById(idFornecedorNota);
            return notaEntrada;
        }

        private void InsertProduto(NotaEntrada notaEntrada, ProdutoNotaEntrada produto)
        {
            notaEntrada.Produtos.Add(produto);
            var command = new SqlCommand("insert into " +
                "PRODUTOSNOTASDEENTRADA(idnotadeentrada, idproduto, precocustocompra, quantidadecompra) " +
                "values(@idnotadeentrada, @idproduto, @precocustocompra, @quantidadecompra)", this.connection);
            command.Parameters.AddWithValue("@idnotadeentrada", notaEntrada.Id);
            command.Parameters.AddWithValue("@idproduto", produto.ProdutoNota.Id);
            command.Parameters.AddWithValue("@precocustocompra", produto.PrecoCustoCompra);
            command.Parameters.AddWithValue("@quantidadecompra", produto.QuantidadeComprada);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void UpdateProduto(ProdutoNotaEntrada produto)
        {
            var command = new SqlCommand("update PRODUTOSNOTASDEENTRADA set idproduto=@idproduto, " +
                "precocustocompra=@precocustocompra, quantidadecompra=@quantidadecompra where (id=@id)", this.connection);
            command.Parameters.AddWithValue("@idproduto", produto.ProdutoNota.Id);
            command.Parameters.AddWithValue("@precocustocompra", produto.PrecoCustoCompra);
            command.Parameters.AddWithValue("@quantidadecompra", produto.QuantidadeComprada);
            command.Parameters.AddWithValue("@id", produto.Id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void SaveProduto(NotaEntrada notaEntrada, ProdutoNotaEntrada produto
            )
        {
            if (produto.Id == null)
                this.InsertProduto(notaEntrada, produto);
            else
                this.UpdateProduto(produto);
        }
    }
}
