using CasaDoCodigo.DAL;
using CasaDoCodigo.DataAccess;
using CasaDoCodigo.DataAccess.Interfaces;
using CasaDoCodigo.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace Capitulo05.ViewModels.Atendimentos
{
    public class FotosListagemViewModel
    {
        private Atendimento Atendimento { get; set; }
        private AtendimentoFoto AtendimentoFoto { get; set; }
        public ICommand NovoCommand { get; set; }
        private IDAL<AtendimentoFoto> atendimentoFotoDAL;

        public FotosListagemViewModel(Atendimento atendimento)
        {
            this.Atendimento = atendimento;
            atendimentoFotoDAL = new AtendimentoFotoDAL(atendimento, DependencyService.Get<IDBPath>().GetDbPath());
            RegistrarCommands();
        }
        private void RegistrarCommands()
        {
            NovoCommand = new Command(() =>
            {
                var atendimentoFoto = new AtendimentoFoto() { Atendimento = this.Atendimento, AtendimentoID = this.Atendimento.AtendimentoID };
                MessagingCenter.Send<AtendimentoFoto>(atendimentoFoto, "Mostrar");
            }, () =>
            {
                return !this.Atendimento.EstaFinalizado;
            });
        }
    }
}
