using CCFoodsServer.Persistencia;
using Microsoft.AspNetCore.Mvc;

namespace CCFoodsServer.Controllers
{
    [ApiController]
    public class ConfiguracaoDispositivoController : ControllerBase
    {
        private readonly CCFoodsContext _context;
        private readonly ConfiguracaoDispositivoDAL configuracaoDispositivoDAL;

        public ConfiguracaoDispositivoController(CCFoodsContext context)
        {
            _context = context;
            configuracaoDispositivoDAL = new ConfiguracaoDispositivoDAL(context);
        }

        [Route("dispositivos/configuracao/")]
        public long Get(string eMail)
        {
            return (long)configuracaoDispositivoDAL.Insert(eMail).ConfiguracaoDispositivoId;
        }
    }
}