using Modelo.Cadastros;

namespace Modelo.Carrinho
{
    public class ItemCarrinho
    {
        public long? ItemCarrinhoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public double ValorUnitario { get; set; }
    }
}
