using CasaDoCodigo.DataAccess;
using CasaDoCodigo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaDoCodigo.DAL
{
    public class AtendimentoItemDAL : DALBase<AtendimentoItem>
    {
        private Atendimento Atendimento { get; set; }

        public AtendimentoItemDAL(Atendimento atendimento, DatabaseContext context) : base(context)
        {
            this.Atendimento = atendimento;
        }

        public override async Task<IEnumerable<AtendimentoItem>> GetAllAsync(bool forceRefresh = false)
        {
            var servicoDAL = new ServicoDAL(context);
            var atendimentoItens = await Task.FromResult(context.GetConnection().Query<AtendimentoItem>("select * from AtendimentoItem where AtendimentoID = ?", this.Atendimento.AtendimentoID));
            foreach (var item in atendimentoItens)
            {
                item.Servico = servicoDAL.GetByIdAsync(item.ServicoID).Result;
                item.Atendimento = this.Atendimento;
            }
            return atendimentoItens;
        }
    }
}
