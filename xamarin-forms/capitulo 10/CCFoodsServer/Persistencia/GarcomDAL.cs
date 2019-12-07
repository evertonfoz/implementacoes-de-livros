using Modulo1.Modelo;
using System.Collections.Generic;
using System.Linq;

namespace CCFoodsServer.Persistencia
{
    public class GarcomDAL
    {
        private CCFoodsContexts contexto = new CCFoodsContexts();

        public IEnumerable<Garcom> GetAll()
        {
            return contexto.Garcons;
        }

        public void Insert(Garcom garcom)
        {
            contexto.Garcons.Add(garcom);
            contexto.SaveChanges();
        }
    }
}