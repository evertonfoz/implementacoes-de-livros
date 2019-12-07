using System.Data.Entity;
using EFApplication.POCO;

namespace EFApplication.Contexts
{
    public class EFContext : DbContext
    {
        public DbSet<Estado> Estados { get; set; }
    }
}
