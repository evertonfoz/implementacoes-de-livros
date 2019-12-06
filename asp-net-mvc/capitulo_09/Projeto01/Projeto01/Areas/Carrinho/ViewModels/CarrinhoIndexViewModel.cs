using System.Linq;

namespace Projeto01.Areas.Carrinho.ViewModels
{
    public class CarrinhoIndexViewModel
    {
        public IQueryable Carrinhos { get; set; }
        public IQueryable Produtos { get; set; }
    }
}
