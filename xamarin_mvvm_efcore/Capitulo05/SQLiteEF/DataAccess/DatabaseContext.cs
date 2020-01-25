using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.DataAccess
{
    public class DatabaseContext : DbContext
    {
        private static string DbPath;

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servico> Servicos { get; set; }

        private DatabaseContext()
        {
            //this.Database.EnsureDeleted();
            //this.Database.EnsureCreated();
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DbPath}");
        }

        public static DatabaseContext GetContext(string dbPath)
        {
            DbPath = dbPath;
            return new DatabaseContext();
        }
    }
}
