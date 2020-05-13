using Capitulo03.Models;
using System.Linq;

namespace Capitulo03.Data
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

            var instituicoes = new Instituicao[]
            {
                new Instituicao { Nome="UTFPR", Endereco= "Medianeira"},
                new Instituicao { Nome="UFSC", Endereco = "Florianópolis"}
            };

            foreach (Instituicao i in instituicoes)
            {
                context.Instituicoes.Add(i);
            }
            context.SaveChanges();
        }
    }
}
