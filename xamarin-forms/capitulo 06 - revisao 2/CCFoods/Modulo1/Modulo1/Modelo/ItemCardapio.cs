using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Modulo1.Modelo
{
    public class ItemCardapio
    {
        [PrimaryKey, AutoIncrement]
        public long? ItemCardapioId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public byte[] Foto { get; set; }

        [ForeignKey(typeof(TipoItemCardapio))]
        public long? TipoItemCardapioId { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public TipoItemCardapio TipoItemCardapio { get; set; }

        public override bool Equals(object obj)
        {
            ItemCardapio itemCardapio = obj as ItemCardapio;
            if (itemCardapio == null)
            {
                return false;
            }

            return (ItemCardapioId.Equals(itemCardapio.ItemCardapioId));
        }

        public override int GetHashCode()
        {
            return ItemCardapioId.GetHashCode();
        }
    }
}
