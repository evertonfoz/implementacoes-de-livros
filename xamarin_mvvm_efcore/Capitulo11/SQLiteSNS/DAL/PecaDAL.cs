using CasaDoCodigo.DataAccess;
using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaDoCodigo.DAL
{
    public class PecaDAL : DALBase<Peca>
    {
        public PecaDAL(DatabaseContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Peca>> GetAllAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(context.GetConnection().Table<Peca>());
        }

        public override async Task<Peca> GetByIdAsync(Guid id)
        {
            return await Task.FromResult(context.GetConnection().Table<Peca>().Where(p => p.PecaID.Equals(id)).FirstOrDefault());
        }

        public override async Task<bool> UpdateAsync(Peca peca, Guid itemId, bool sincronizado = false)
        {
            if (itemId == Guid.Empty)
            {
                peca.PecaID = Guid.NewGuid();
                context.GetConnection().Insert(peca);
            }
            else
            {
                peca.Sincronizado = sincronizado;
                context.GetConnection().Update(peca);
            }
            return await Task.FromResult(true);
        }
    }
}
