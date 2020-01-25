using CasaDoCodigo.Models;
using SQLite;

namespace CasaDoCodigo.DataAccess
{
    public class DatabaseContext
    {
        private SQLiteConnection db;
        private static DatabaseContext context;
        private static string DbPath;

        private DatabaseContext(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Cliente>();
            db.CreateTable<Servico>();
            db.CreateTable<Atendimento>();
            db.CreateTable<AtendimentoItem>();
            db.CreateTable<AtendimentoFoto>();
        }

        public static DatabaseContext GetContext(string dbPath)
        {
            if (context == null || DbPath != dbPath)
            {
                DbPath = dbPath;
                context = new DatabaseContext(DbPath);
            }
            return context;
        }

        public SQLiteConnection GetConnection()
        {
            return db;
        }
    }
}
