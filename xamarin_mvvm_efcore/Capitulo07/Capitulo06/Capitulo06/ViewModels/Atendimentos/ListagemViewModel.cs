using Capitulo06.ExtensionMethods;
using CasaDoCodigo.DAL;
using CasaDoCodigo.DataAccess.Interfaces;
using CasaDoCodigo.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Capitulo06.ViewModels.Atendimentos
{
    public class ListagemViewModel
    {
        private IDAL<Atendimento> atendimentoDAL;
        public ObservableCollection<Atendimento> Atendimentos { get; set; }

        public ListagemViewModel()
        {
            atendimentoDAL = new AtendimentoDAL(DependencyService.Get<IDBPath>().GetDbPath());
            Atendimentos = new ObservableCollection<Atendimento>();
            RegistrarCommands();
        }

        public ICommand NovoCommand { get; set; }

        private void RegistrarCommands()
        {
            NovoCommand = new Command(() =>
            {
                MessagingCenter.Send<Atendimento>(new Atendimento(), "Mostrar");
            });
        }

        public async Task AtualizarAtendimentosAsync()
        {
            var atendimentos = await atendimentoDAL.GetAllAsync();
            Atendimentos.SincronizarColecoes(atendimentos);
        }

        private Atendimento atendimentoSelecionado;
        public Atendimento AtendimentoSelecionado
        {
            get { return atendimentoSelecionado; }
            set
            {
                if (value != null)
                {
                    atendimentoSelecionado = value;
                    MessagingCenter.Send<Atendimento>(atendimentoSelecionado, "MostrarOpcoes");
                }
            }
        }

        public async Task RegistrarEntrega(Atendimento atendimento)
        {
            atendimento.DataHoraEntrega = DateTime.Now;
            var indiceAtendimento = Atendimentos.IndexOf(await atendimentoDAL.UpdateAsync(atendimento, atendimento.AtendimentoID));
            Atendimentos.RemoveAt(indiceAtendimento);
            Atendimentos.Insert(indiceAtendimento, atendimento);
        }

        public async Task EliminarAtendimento(Atendimento atendimento)
        {
            await atendimentoDAL.DeleteAsync(atendimento);
            Atendimentos.Remove(atendimento);
        }
    }
}
