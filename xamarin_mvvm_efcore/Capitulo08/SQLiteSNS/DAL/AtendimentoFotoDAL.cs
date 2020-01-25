using CasaDoCodigo.DAL;
using CasaDoCodigo.DataAccess;
using CasaDoCodigo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaDoCodigo.DAL
{
    public class AtendimentoFotoDAL : DALBase<AtendimentoFoto>
    {
        private Atendimento Atendimento { get; set; }

        public AtendimentoFotoDAL(Atendimento atendimento, DatabaseContext context) : base(context)
        {
            this.Atendimento = atendimento;
        }

        public override async Task<IEnumerable<AtendimentoFoto>> GetAllAsync(bool forceRefresh = false)
        {
            var atendimentoFotos = await Task.FromResult(context.GetConnection().Table<AtendimentoFoto>().Where(f => f.AtendimentoID == this.Atendimento.AtendimentoID));
            return atendimentoFotos;
        }
    }
}
