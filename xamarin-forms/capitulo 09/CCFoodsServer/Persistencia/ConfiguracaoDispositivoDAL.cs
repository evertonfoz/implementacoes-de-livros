using CCFoodsServer.Models;
using System.Linq;

namespace CCFoodsServer.Persistencia
{
    public class ConfiguracaoDispositivoDAL
    {
        private CCFoodsContexts contexto = new CCFoodsContexts();

        public ConfiguracaoDispositivo Insert(string eMail)
        {
            ConfiguracaoDispositivo cd = GetConfiguracaoDispositivo(eMail);
            if (cd == null)
            {
                cd = contexto.ConfiguracoesDispositivos.Add(
                    new ConfiguracaoDispositivo() { EMail = eMail }
                    );
                contexto.SaveChanges();
            }
            return cd;
        }

        private ConfiguracaoDispositivo GetConfiguracaoDispositivo(string email)
        {
            return contexto.ConfiguracoesDispositivos.Where(e => e.EMail == email).FirstOrDefault();
        }
    }
}