using CasaDoCodigo.Models;
using SQLite;

namespace CasaDoCodigo.DataAccess
{
    public class DatabaseContext
    {
        private SQLiteConnection db;
        private static DatabaseContext context;

        private DatabaseContext(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Cliente>();
            db.CreateTable<Servico>();
            db.CreateTable<Atendimento>();
        }

        public static DatabaseContext GetContext(string dbPath)
        {
            if (context == null)
            {
                context = new DatabaseContext(dbPath);
            }
            return context;
        }

        public SQLiteConnection GetConnection()
        {
            return db;
        }
    }
}
