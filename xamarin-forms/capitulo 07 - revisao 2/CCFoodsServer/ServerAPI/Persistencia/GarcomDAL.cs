using ServerAPI.Models;
using System.Collections.Generic;

namespace ServerAPI.Persistencia
{
    public class GarcomDAL
    {
        private CCFoodsContext _context;

        public GarcomDAL(CCFoodsContext context)
        {
            _context = context;
        }
        public IEnumerable<Garcom> GetAll()
        {
            return _context.Garcons;
        }

        public void Insert(Garcom garcom)
        {
            _context.Garcons.Add(garcom);
            _context.SaveChanges();
        }
    }
}
