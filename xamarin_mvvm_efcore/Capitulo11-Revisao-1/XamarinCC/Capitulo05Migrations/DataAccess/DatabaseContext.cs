using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using OficinaModels.Cadastros;

namespace CasaDoCodigo.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<AtendimentoItem> AtendimentoItens { get; set; }
        public DbSet<AtendimentoFoto> AtendimentoFotos { get; set; }
        public DbSet<Peca> Pecas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename=OficinaMigrations.db");
        }
    }
}
