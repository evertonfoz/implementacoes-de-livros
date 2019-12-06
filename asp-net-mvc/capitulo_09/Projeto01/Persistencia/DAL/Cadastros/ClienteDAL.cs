using Modelo.Cadastros;
using Persistencia.Contexts;
using System.Collections;
using System.Data.Entity;
using System.Linq;

namespace Persistencia.DAL.Cadastros
{
    public class ClienteDAL
    {
        private EFContext context = new EFContext();

        public IQueryable ObterClientesClassificadosPorNome()
        {
            return context.Clientes.OrderBy(n => n.Nome);
        }

        public Cliente ObterClientePorId(long id)
        {
            return context.Clientes.Where(p => p.ClienteID == id).First();
        }

        public void GravarCliente(Cliente cliente)
        {
            if (cliente.ClienteID == null)
            {
                context.Clientes.Add(cliente);
            }
            else
            {
                context.Entry(cliente).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Cliente EliminarClientePorId(long id)
        {
            Cliente cliente = ObterClientePorId(id);
            context.Clientes.Remove(cliente);
            context.SaveChanges();
            return cliente;
        }

        public IList ObterClientesPorNome(string param)
        {
            var r = from cliente in context.Clientes
                    where cliente.Nome.ToUpper().StartsWith(param.ToUpper())
                    orderby (cliente.Nome)
                    select new
                    {
                        id = cliente.ClienteID,
                        label = cliente.Nome,
                        value = cliente.Nome
                    };
            return r.ToList();
        }
    }
}
