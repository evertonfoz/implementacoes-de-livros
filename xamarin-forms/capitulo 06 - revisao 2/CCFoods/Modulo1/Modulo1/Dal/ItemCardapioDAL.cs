using Modulo1.Infrastructure;
using Modulo1.Modelo;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Modulo1.Dal
{
    public class ItemCardapioDAL
    {
        private SQLiteConnection sqlConnection;

        public ItemCardapioDAL()
        {
            this.sqlConnection = DependencyService.Get<IDatabaseConnection>().DbConnection();
            this.sqlConnection.CreateTable<ItemCardapio>();
        }

        public void Add(ItemCardapio itemCardapio)
        {
            sqlConnection.Insert(itemCardapio);
        }

        public void DeleteById(long id)
        {
            sqlConnection.Delete<ItemCardapio>(id);
        }

        public IEnumerable<ItemCardapio> GetAllWithChildren()
        {
            return sqlConnection.GetAllWithChildren<ItemCardapio>().OrderBy(i => i.Nome).ToList();
        }

        public ItemCardapio GetItemById(long id)
        {
            return sqlConnection.GetAllWithChildren<ItemCardapio>().FirstOrDefault(i => i.ItemCardapioId == id);
        }

        public void Update(ItemCardapio itemCardapio)
        {
            sqlConnection.Update(itemCardapio);
        }
    }
}
