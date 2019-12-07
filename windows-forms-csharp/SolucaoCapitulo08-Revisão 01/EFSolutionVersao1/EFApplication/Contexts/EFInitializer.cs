using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using EFApplication.POCO;

namespace EFApplication.Contexts
{
    public class EFInitializer : DropCreateDatabaseAlways<EFContext>
    {
        protected override void Seed(EFContext context)
        {
            IList<Estado> estados = new List<Estado>();
            estados.Add(new Estado() { UF = "PR", Nome = "Paraná" });
            estados.Add(new Estado() { UF = "SC", Nome = "Santa Catarina" });
            estados.Add(new Estado() { UF = "SP", Nome = "São Paulo" });
            estados.Add(new Estado() { UF = "MS", Nome = "Mato Grosso do Sul" });
            estados.Add(new Estado() { UF = "CE", Nome = "Ceará" });

            foreach (var estado in estados)
            {
                context.Estados.Add(estado);
            }

            IList<Cidade> cidades = new List<Cidade>();
            cidades.Add(new Cidade() { Estado = estados[0], Nome = "Foz do Iguaçu" });
            cidades.Add(new Cidade() { Estado = estados[1], Nome = "Blumenau" });
            cidades.Add(new Cidade() { Estado = estados[2], Nome = "Itapetininga" });
            cidades.Add(new Cidade() { Estado = estados[3], Nome = "Três Lagoas" });
            cidades.Add(new Cidade() { Estado = estados[4], Nome = "Fortaleza" });

            foreach (var cidade in cidades)
            {
                context.Cidades.Add(cidade);
            }

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
