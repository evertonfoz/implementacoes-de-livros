using CCFoodsServer.Models;
using System.Linq;

namespace CCFoodsServer.Persistencia
{
    public class ConfiguracaoDispositivoDAL
    {
        private CCFoodsContext _context;

        public ConfiguracaoDispositivoDAL(CCFoodsContext context)
        {
            _context = context;
        }

        public ConfiguracaoDispositivo Insert(string eMail)
        {
            ConfiguracaoDispositivo cd = GetConfiguracaoDispositivo(eMail);
            if (cd == null)
            {
                cd = _context.ConfiguracoesDispositivos.Add(
                    new ConfiguracaoDispositivo() { EMail = eMail }
                    ).Entity;
                _context.SaveChanges();
            }
            return cd;
        }

        private ConfiguracaoDispositivo GetConfiguracaoDispositivo(string email)
        {
            return _context.ConfiguracoesDispositivos.Where(e => e.EMail == email).FirstOrDefault();
        }
    }
}
