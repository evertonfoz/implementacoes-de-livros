using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using OficinaModels.Atendimentos;
using OficinaModels.Cadastros;

namespace CasaDoCodigo.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename=OficinaMigrations.db");
        }
    }
}
