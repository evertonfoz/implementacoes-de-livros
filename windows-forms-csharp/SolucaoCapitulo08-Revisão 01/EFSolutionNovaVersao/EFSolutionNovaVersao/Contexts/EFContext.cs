using EFSolutionNovaVersao.POCO;
using Microsoft.EntityFrameworkCore;

namespace EFSolutionNovaVersao.Contexts
{
    public class EFContext : DbContext
    {
        //public EFContext(DbContextOptions optionsBuilder) : base(optionsBuilder)
        //{

        //}
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WPF_EFCore;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var pr = new Estado() { Id = 1, Nome = "Paraná", UF = "PR" };
            var ms = new Estado() { Id = 2, Nome = "Mato Grosso do Sul", UF = "MS" };

            modelBuilder.Entity<Estado>().HasData(pr);
            modelBuilder.Entity<Estado>().HasData(ms);
            modelBuilder.Entity<Estado>().HasData(new Estado() { Id = 3, Nome = "São Paulo", UF = "SP" });

            var foz = new Cidade() { Id = 1, Nome = "Foz do Iguaçu", EstadoId = 1 };
            var tresLagoas = new Cidade() { Id = 2, Nome = "Três Lagoas", EstadoId = 3 };

            modelBuilder.Entity<Cidade>().HasData(foz);
            modelBuilder.Entity<Cidade>().HasData(tresLagoas);
        }
    }
}
