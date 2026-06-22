using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Modelo;

namespace Persistencia
{
    public class EFContext : DbContext
    {
        public DbSet<Curso> Cursos { get; set; } = null!;
        public DbSet<Disciplina> Disciplinas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var pastaDados = Path.Combine(AppContext.BaseDirectory, "dados");
            Directory.CreateDirectory(pastaDados);

            var caminhoBanco = Path.Combine(pastaDados, "escola.db");

            optionsBuilder.UseSqlite($"Data Source={caminhoBanco}");
        }
    }
}
