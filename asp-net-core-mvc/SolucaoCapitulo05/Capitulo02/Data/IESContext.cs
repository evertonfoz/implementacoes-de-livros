using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;

namespace Capitulo02.Data
{
    public class IESContext : DbContext
    {
        public IESContext(DbContextOptions<IESContext> options) : base(options)
        {
        }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }
    }
}
