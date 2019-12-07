using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System;

namespace ADO_NETProject01
{
    public class DAL_Fornecedor {
        private SqlConnection connection = DBConnection.DB_Connection;

        public void RemoveById(long? id) {
            var command = new SqlCommand("delete from FORNECEDORES where id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Save(Fornecedor fornecedor)
        {
            if (fornecedor.Id != null)
                this.Update(fornecedor);
            else
                this.Insert(fornecedor);
        }

        //TODO: [Implementar]
        private void Insert(Fornecedor fornecedor)
        {
            throw new System.NotImplementedException();
        }

        private void Update(Fornecedor fornecedor)
        {
            var command = new SqlCommand("update FORNECEDORES set cnpj=@cnpj, nome=@nome where id=@id", this.connection);
            command.Parameters.AddWithValue("@cnpj", fornecedor.CNPJ);
            command.Parameters.AddWithValue("@nome", fornecedor.Nome);
            command.Parameters.AddWithValue("@id", fornecedor.Id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public IList<Fornecedor> GetAllAsIList() {
            IList<Fornecedor> fornecedores = 
            new List<Fornecedor>();

            var adapter = new SqlDataAdapter("select id, cnpj, nome from FORNECEDORES", connection);
            var builder = new SqlCommandBuilder(adapter);

            var table = new DataTable();
            adapter.Fill(table);
            connection.Close();
          
            for (int i = 0; i < table.Rows.Count; i++) {
                var row = table.Rows[i];
                fornecedores.Add(
                    new Fornecedor() {
                        Id = Convert.ToInt64(row["id"]),
                        CNPJ = (string) row["cnpj"],
                        Nome = (string) row["nome"]
                    });
            }
            return fornecedores;
        }
    }
}
