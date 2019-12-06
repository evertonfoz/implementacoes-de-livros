using Persistencia.DAL.Servicos;
using System.Linq;

namespace Servicos.Carrinho
{
    public class CarrinhoServico
    {
        private CarrinhoDAL carrinhoDAL = new CarrinhoDAL();

        public IQueryable ObterCarrinhosClassificadosPorDataDecrescente()
        {
            return carrinhoDAL.ObterCarrinhosClassificadosPorDataDecrescente();
        }

        public Modelo.Carrinho.Carrinho CreateCarrinho(Modelo.Carrinho.Carrinho carrinho)
        {
            return carrinhoDAL.CreateCarrinho(carrinho);
        }
    }
}
