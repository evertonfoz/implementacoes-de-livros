using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.DataAccess
{
    public class DatabaseContext : DbContext
    {
        private readonly string DbPath;

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<AtendimentoItem> AtendimentoItens { get; set; }
        public DbSet<AtendimentoFoto> AtendimentoFotos { get; set; }

        public DatabaseContext()
        {

        }

        public DatabaseContext(string DbPath)
        {
            this.DbPath = DbPath;
            //this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename=OficinaMigrations.db");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<AtendimentoItem>()
        //        .HasOne(item => item.Atendimento)
        //        .WithMany(a => a.Servicos)
        //        .IsRequired()
        //        .OnDelete(DeleteBehavior.Cascade);
        //}
    }
}
