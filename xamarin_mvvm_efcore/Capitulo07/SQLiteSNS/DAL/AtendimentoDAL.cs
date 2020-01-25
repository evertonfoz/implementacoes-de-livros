using CasaDoCodigo.DataAccess;
using CasaDoCodigo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaDoCodigo.DAL
{
    public class AtendimentoDAL : DALBase<Atendimento>
    {
        public AtendimentoDAL(DatabaseContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Atendimento>> GetAllAsync(bool forceRefresh = false)
        {
            var clienteDAL = new ClienteDAL(context);
            var atendimentos = await Task.FromResult(context.GetConnection().Query<Atendimento>("select * from Atendimento"));
            foreach (var atendimento in atendimentos)
            {
                atendimento.Cliente = await clienteDAL.GetByIdAsync(atendimento.ClienteID);
            }
            return atendimentos;
        }
    }
}
