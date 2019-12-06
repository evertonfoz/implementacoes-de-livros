using System.Linq;
using Persistencia.Contexts;

namespace Persistencia.DAL.Servicos
{
    public class CarrinhoDAL
    {
        private EFContext context = new EFContext();

        public IQueryable ObterCarrinhosClassificadosPorDataDecrescente()
        {
            var teste = context.Carrinhos.OrderByDescending(d => d.Data);
            return context.Carrinhos.OrderByDescending(d => d.Data);
        }

        public Modelo.Carrinho.Carrinho CreateCarrinho(Modelo.Carrinho.Carrinho carrinho)
        {
            context.Carrinhos.Add(carrinho);
            context.SaveChanges();
            return carrinho;
        }
    }
}
