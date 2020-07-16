using Microsoft.EntityFrameworkCore;
using ServerAPI.Models;

namespace ServerAPI.Persistencia
{
    public class CCFoodsContext : DbContext
    {
        public CCFoodsContext(DbContextOptions<CCFoodsContext> options) : base(options) { }

        public DbSet<Garcom> Garcons { get; set; }
        public DbSet<ConfiguracaoDispositivo> ConfiguracoesDispositivos { get; set; }
    }
}
