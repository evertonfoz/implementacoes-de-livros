using System.Data.Entity;
using EFApplication.POCO;

namespace EFApplication.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("EF_Intro")
        {
            Database.SetInitializer(
                new EFInitializer()
            );
        }

        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
    }
}
