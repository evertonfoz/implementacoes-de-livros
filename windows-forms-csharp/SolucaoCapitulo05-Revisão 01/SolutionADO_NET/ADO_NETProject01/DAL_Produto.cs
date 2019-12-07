using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ADO_NETProject01
{
    public class DAL_Produto
    {
        private SqlConnection connection = DBConnection.DB_Connection;

        public void RemoveById(long? id)
        {
            var command = new SqlCommand("delete from PRODUTOS where id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void Update(Produto produto)
        {
            //var command = new SqlCommand("update FORNECEDORES set cnpj=@cnpj, nome=@nome where id=@id", connection);
            //command.Parameters.AddWithValue("@cnpj", fornecedor.CNPJ);
            //command.Parameters.AddWithValue("@nome", fornecedor.Nome);
            //command.Parameters.AddWithValue("@id", fornecedor.Id);
            //connection.Open();
            //command.ExecuteNonQuery();
            //connection.Close();
        }

        public void Save(Produto produto)
        {
            if (produto.Id != null)
                this.Update(produto);
            else
            {
                this.Insert(produto);
            }
        }

        private void Insert(Produto produto)
        {
            var command = new SqlCommand("insert into PRODUTOS(descricao, precodecusto, precodevenda, estoque) VALUES(@descricao, @precodecusto, @precodevenda, @estoque)", connection);
            command.Parameters.AddWithValue("@descricao", produto.Descricao);
            command.Parameters.AddWithValue("@precodecusto", produto.PrecoDeCusto);
            command.Parameters.AddWithValue("@precodevenda", produto.PrecoDeVenda);
            command.Parameters.AddWithValue("@estoque", produto.Estoque);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable GetAllAsDataTable()
        {
            var adapter = new SqlDataAdapter("select id, descricao, precodecusto, precodevenda, estoque from PRODUTOS", connection);
            var builder = new SqlCommandBuilder(adapter);

            var table = new DataTable();
            adapter.Fill(table);

            connection.Close();
            return table;
        }

        public IList<Produto> GetAllAsIList()
        {
            IList<Produto> produtos = new List<Produto>();

            var adapter = new SqlDataAdapter("select id, descricao, precodecusto, precodevenda, estoque from PRODUTOS", connection);
            var builder = new SqlCommandBuilder(adapter);

            var table = new DataTable();
            adapter.Fill(table);
            connection.Close();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i];
                produtos.Add(
                    new Produto()
                    {
                        Id = Convert.ToInt64(row["id"]),
                        Descricao = (string)row["descricao"],
                        PrecoDeCusto = Convert.ToDouble(row["precodecusto"]),
                        PrecoDeVenda = Convert.ToDouble(row["precodevenda"])
                    }
                );
            }
            return produtos;
        }
    }
}
