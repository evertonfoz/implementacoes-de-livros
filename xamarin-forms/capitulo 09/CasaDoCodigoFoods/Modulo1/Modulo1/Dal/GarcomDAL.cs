using Modulo1.Infraestructure;
using Modulo1.Modelo;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Modulo1.Dal
{
    public class GarcomDAL
    {
        private SQLiteConnection sqlConnection;
        private ConfiguracaoDAL configuracaoDAL = new ConfiguracaoDAL();

        public GarcomDAL()
        {
            this.sqlConnection = DependencyService.Get<IDatabaseConnection>().DbConnection();
            this.sqlConnection.CreateTable<Garcom>();
        }

        public void Update(Garcom garcom)
        {
            this.sqlConnection.Update(garcom);
        }

        public IEnumerable<Garcom> GetAll()
        {
            return (from t in sqlConnection.Table<Garcom>() select t).OrderBy(i => i.Nome).ToList();
        }

        public IEnumerable<Garcom> GetAllInseridoDispositivo()
        {
            var configuracaoId = configuracaoDAL.GetConfiguracao().ConfiguracaoDispositivoId;
            return (from t in sqlConnection.Table<Garcom>() where t.OperacaoSincronismo == Modelo.Enums.OperacaoSincronismo.InseridoDispositivo && t.DispositivoId == configuracaoId select t).OrderBy(i => i.Nome).ToList(); 
        }

        public void Add(Garcom garcom)
        {
            garcom.DispositivoId = configuracaoDAL.GetConfiguracao().ConfiguracaoDispositivoId;
            garcom.EntityId = GetMaxId();
            garcom.GarcomId = garcom.DispositivoId.ToString().Trim() + "/" + garcom.EntityId.ToString().Trim();
            garcom.OperacaoSincronismo = Modelo.Enums.OperacaoSincronismo.InseridoDispositivo;
            sqlConnection.Insert(garcom);
        }

        private long GetMaxId()
        {
            var id = sqlConnection.Table<Garcom>().Max(g => g.EntityId);
            return Convert.ToInt32(id) + 1;
        }
    }
}
