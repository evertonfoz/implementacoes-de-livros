using CCFoodsServer.Models;
using Microsoft.EntityFrameworkCore;

namespace CCFoodsServer.Persistencia
{
    public class CCFoodsContext : DbContext
    {
        public CCFoodsContext(DbContextOptions<CCFoodsContext> options) : base(options) { }

        public DbSet<Garcom> Garcons { get; set; }
        public DbSet<ConfiguracaoDispositivo> ConfiguracoesDispositivos { get; set; }
    }
}
