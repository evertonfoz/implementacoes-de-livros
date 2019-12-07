using Modulo1.Infraestructure;
using Modulo1.Modelo;
using SQLite.Net;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Modulo1.Dal
{
    public class ClienteDAL
    {
        private SQLiteConnection sqlConnection;

        public ClienteDAL()
        {
            this.sqlConnection = DependencyService.Get<IDatabaseConnection>().DbConnection();
            this.sqlConnection.CreateTable<Cliente>();
        }

        public void Add(Cliente cliente)
        {
            sqlConnection.Insert(cliente);
        }

        public void DeleteById(long id)
        {
            sqlConnection.Delete<Cliente>(id);
        }

        public void Update(Cliente cliente)
        {
            sqlConnection.Update(cliente);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return (from t in sqlConnection.Table<Cliente>() select t).OrderBy(i => i.Nome).ToList();
        }

        public Cliente GetClienteById(long id)
        {
            return sqlConnection.Table<Cliente>().FirstOrDefault(t => t.ClienteId == id);
        }
    }
}
