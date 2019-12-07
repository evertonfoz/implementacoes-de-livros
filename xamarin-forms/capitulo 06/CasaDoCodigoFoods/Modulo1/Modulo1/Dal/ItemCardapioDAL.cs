using Modulo1.Infraestructure;
using Modulo1.Modelo;
using SQLite;
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

        public void Update(ItemCardapio itemCardapio)
        {
            sqlConnection.Update(itemCardapio);
        }
    }
}
