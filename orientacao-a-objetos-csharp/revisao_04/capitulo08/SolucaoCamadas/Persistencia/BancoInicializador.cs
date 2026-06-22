using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace Persistencia
{
    public class BancoInicializador
    {
        public static string ObterStringDeConexao()
        {
            var pastaDados = Path.Combine(AppContext.BaseDirectory, "dados");
            Directory.CreateDirectory(pastaDados);

            var caminhoBanco = Path.Combine(pastaDados, "escola.db");
            return $"Data Source={caminhoBanco}";
        }

        public static void Inicializar()
        {
            using (var connection = new SqliteConnection(ObterStringDeConexao()))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Disciplinas (
                        DisciplinaId INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nome TEXT NOT NULL,
                        CargaHoraria INTEGER NOT NULL
                    );";

                command.ExecuteNonQuery();
            }
        }
    }
}
