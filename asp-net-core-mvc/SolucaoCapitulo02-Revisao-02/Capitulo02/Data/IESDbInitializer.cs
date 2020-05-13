using Capitulo02.Models;
using System.Linq;

namespace Capitulo02.Data
{
    public class IESDbInitializer
    {
        public static void Initialize(IESContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.Departamentos.Any())
            {
                return;
            }

            var departamentos = new Departamento[]
            {
                new Departamento { Nome="Ciência da Computação"},
                new Departamento { Nome="Ciência de Alimentos"}
            };

            foreach (Departamento d in departamentos)
            {
                context.Departamentos.Add(d);
            }
            context.SaveChanges();
        }
    }
}
