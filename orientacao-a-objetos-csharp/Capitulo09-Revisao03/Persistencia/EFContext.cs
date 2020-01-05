using Microsoft.EntityFrameworkCore;
using Modelo;

namespace Persistencia
{
    public class EFContext : DbContext
    {
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=OO_EFCoreRevisao3;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var cc = new Curso() { CursoID = 1, Nome = "Ciência da Computação", CargaHoraria = 3600 };
            var tads = new Curso() { CursoID = 2, Nome = "Tecnologia em Processamento de Dados", CargaHoraria = 2000 };

            modelBuilder.Entity<Curso>().HasData(cc);
            modelBuilder.Entity<Curso>().HasData(tads);

            var lpe = new Disciplina()
            {
                DisciplinaID = 1,
                Nome = "Linguagem de Programação Estruturada",
                CursoID = 1
            };
            var oo = new Disciplina()
            {
                DisciplinaID = 2,
                Nome = "Programação Orientada a Objetos",
                CursoID = 2
            };
            modelBuilder.Entity<Disciplina>().HasData(lpe);
            modelBuilder.Entity<Disciplina>().HasData(oo);
        }
    }
}
