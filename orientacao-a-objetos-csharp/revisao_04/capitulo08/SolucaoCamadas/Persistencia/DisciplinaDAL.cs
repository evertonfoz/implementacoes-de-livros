using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Modelo;

namespace Persistencia
{
    public class DisciplinaDAL
    {
        private string connectionString;

        public DisciplinaDAL()
        {
            this.connectionString = BancoInicializador.ObterStringDeConexao();
        }

        private void Inserir(Disciplina disciplina)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Disciplinas (Nome, CargaHoraria) VALUES (@nome, @cargaHoraria)";
                
                command.Parameters.AddWithValue("@nome", disciplina.Nome);
                command.Parameters.AddWithValue("@cargaHoraria", disciplina.CargaHoraria);
                
                command.ExecuteNonQuery();

                command.CommandText = "SELECT last_insert_rowid()";
                disciplina.DisciplinaId = (long)command.ExecuteScalar();
            }
        }

        private void Atualizar(Disciplina disciplina)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Disciplinas SET Nome=@nome, CargaHoraria=@cargaHoraria WHERE DisciplinaId=@disciplinaId";
                
                command.Parameters.AddWithValue("@nome", disciplina.Nome);
                command.Parameters.AddWithValue("@cargaHoraria", disciplina.CargaHoraria);
                command.Parameters.AddWithValue("@disciplinaId", disciplina.DisciplinaId);
                
                command.ExecuteNonQuery();
            }
        }

        public void Gravar(Disciplina disciplina)
        {
            if (disciplina.DisciplinaId == null)
            {
                Inserir(disciplina);
            }
            else
            {
                Atualizar(disciplina);
            }
        }

        public List<Disciplina> ObterTodas()
        {
            var disciplinas = new List<Disciplina>();
            
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT DisciplinaId, Nome, CargaHoraria FROM Disciplinas";
                
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var disciplina = new Disciplina();
                        disciplina.DisciplinaId = reader.GetInt64(0);
                        disciplina.Nome = reader.GetString(1);
                        disciplina.CargaHoraria = reader.GetInt32(2);
                        
                        disciplinas.Add(disciplina);
                    }
                }
            }
            
            return disciplinas;
        }

        public Disciplina? ObterPorId(long id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT DisciplinaId, Nome, CargaHoraria FROM Disciplinas WHERE DisciplinaId = @disciplinaId";
                
                command.Parameters.AddWithValue("@disciplinaId", id);
                
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var disciplina = new Disciplina();
                        disciplina.DisciplinaId = reader.GetInt64(0);
                        disciplina.Nome = reader.GetString(1);
                        disciplina.CargaHoraria = reader.GetInt32(2);
                        return disciplina;
                    }
                }
            }
            return null;
        }

        public void Remover(Disciplina disciplina)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Disciplinas WHERE DisciplinaId=@disciplinaId";
                
                command.Parameters.AddWithValue("@disciplinaId", disciplina.DisciplinaId);
                
                command.ExecuteNonQuery();
            }
        }
    }
}
