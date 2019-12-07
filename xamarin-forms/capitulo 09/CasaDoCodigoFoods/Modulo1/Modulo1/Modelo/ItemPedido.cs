using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Modulo1.Modelo
{
    public class ItemPedido
    {
        [PrimaryKey, AutoIncrement]
        public long? ItemPedidoId { get; set; }
        public double Quantidade { get; set; }
        public double ValorUnitario { get; set; }

        [ForeignKey(typeof(Pedido))]
        public long? PedidoId { get; set; }

        [ForeignKey(typeof(ItemCardapio))]
        public long? ItemCardapioId { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public Pedido Pedido { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public ItemCardapio ItemCardapio { get; set; }

        public override bool Equals(object obj)
        {
            ItemPedido itemPedido = obj as ItemPedido;
            if (itemPedido == null)
            {
                return false;
            }

            return (ItemPedidoId.Equals(itemPedido.ItemPedidoId));
        }

        public override int GetHashCode()
        {
            return ItemPedidoId.GetHashCode();
        }
    }
}
