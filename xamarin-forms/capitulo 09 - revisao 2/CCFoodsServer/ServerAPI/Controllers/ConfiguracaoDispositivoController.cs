using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Persistencia;

namespace ServerAPI.Controllers
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
