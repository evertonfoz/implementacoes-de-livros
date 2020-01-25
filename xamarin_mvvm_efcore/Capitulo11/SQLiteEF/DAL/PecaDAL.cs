using CasaDoCodigo.DataAccess;
using CasaDoCodigo.DataAccess.Interfaces;
using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.DAL
{
    public class PecaDAL : DALBase<Peca>
    {
        public PecaDAL(string dbPath) : base(dbPath)
        {
        }

        public async Task<List<Peca>> GetAllAsync(bool apenasSincronizado = false)
        {
            using (var context = DatabaseContext.GetContext(dbPath))
            {
                if (apenasSincronizado)
                    return await context.Set<Peca>().Where(p => p.Sincronizado).ToListAsync();
            }
            return await base.GetAllAsync(p => p.Nome, OrderByType.Ascendente);
        }

        public async Task SincronizaBaseLocal(List<Peca> baseRest)
        {
            using (var context = DatabaseContext.GetContext(dbPath))
            {
                context.Pecas.RemoveRange(await GetAllAsync(true));
                await context.SaveChangesAsync();

                foreach (var p in baseRest)
                {
                    var pl = await GetByIdAsync(p.PecaID);
                    if (pl == null)
                        await context.AddAsync(p);
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
