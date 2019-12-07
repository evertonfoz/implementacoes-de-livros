using CCFoodsServer.Persistencia;
using Modulo1.Modelo;
using System.Collections.Generic;
using System.Web.Http;

namespace CCFoodsServer.Controllers
{
    public class GarcomController : ApiController
    {
        private GarcomDAL garcomDAL = new GarcomDAL();

        // GET: api/Garcom
        [Route("garcons/todos")]
        public IEnumerable<Garcom> Get()
        {
            return garcomDAL.GetAll();
        }

        [Route("garcom/insert")]
        public void PostInsertGarcom(Garcom garcom)
        {
            garcom.OperacaoSincronismo = Models.Enums.Modulo1.Modelo.Enums.OperacaoSincronismo.Sincronizado;
            garcomDAL.Insert(garcom);
        }
    }
}
