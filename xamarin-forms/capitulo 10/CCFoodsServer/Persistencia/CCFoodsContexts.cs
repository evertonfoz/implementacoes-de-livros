using CCFoodsServer.Models;
using Modulo1.Modelo;
using System.Data.Entity;

namespace CCFoodsServer.Persistencia
{
    public class CCFoodsContexts : DbContext
    {
        public CCFoodsContexts() : base("CCFoods_CS")
        {
        }

        public DbSet<Garcom> Garcons { get; set; }
        public DbSet<ConfiguracaoDispositivo> ConfiguracoesDispositivos { get; set; }
    }
}
