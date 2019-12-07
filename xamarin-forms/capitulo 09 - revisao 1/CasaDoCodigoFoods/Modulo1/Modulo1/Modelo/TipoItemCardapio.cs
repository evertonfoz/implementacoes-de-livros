using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace Modulo1.Modelo
{
    public class TipoItemCardapio
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }
        public string Nome { get; set; }
        public byte[] Foto { get; set; }

        [OneToMany]
        public List<ItemCardapio> Itens { get; set; }

        public override bool Equals(object obj)
        {
            TipoItemCardapio tipoItemCardapio = obj as TipoItemCardapio;
            if (tipoItemCardapio == null)
            {
                return false;
            }
            return (Id.Equals(tipoItemCardapio.Id));
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
