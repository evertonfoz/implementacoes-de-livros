using Modulo1.Infrastructure;
using Modulo1.Modelo;
using SQLite;
using System.Linq;
using Xamarin.Forms;

namespace Modulo1.Dal
{
    public class ConfiguracaoDAL
    {
        private SQLiteConnection sqlConnection;

        public ConfiguracaoDAL()
        {
            this.sqlConnection = DependencyService.Get<IDatabaseConnection>().DbConnection();
            this.sqlConnection.CreateTable<ConfiguracaoDispositivo>();
        }

        public ConfiguracaoDispositivo GetConfiguracao()
        {
            return (from t in sqlConnection.Table<ConfiguracaoDispositivo>() select t).FirstOrDefault();
        }

        public void Add(ConfiguracaoDispositivo configuracaoDispositivo)
        {
            sqlConnection.Insert(configuracaoDispositivo);
        }
    }
}
