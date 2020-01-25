using Capitulo06.ExtensionMethods;
using CasaDoCodigo.DAL;
using CasaDoCodigo.DataAccess.Interfaces;
using CasaDoCodigo.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Capitulo06.ViewModels.Atendimentos
{
    public class ServicosListagemViewModel : BaseViewModel
    {
        private Atendimento Atendimento { get; set; }
        private AtendimentoItem AtendimentoItem { get; set; }
        private IDAL<AtendimentoItem> atendimentoItemDAL;
        
        public ObservableCollection<AtendimentoItem> ItensAtendimento { get; set; }

        public ServicosListagemViewModel(Atendimento atendimento)
        {
            this.Atendimento = atendimento;
            this.ItensAtendimento = new ObservableCollection<AtendimentoItem>();
            atendimentoItemDAL = new AtendimentoItemDAL(atendimento, DependencyService.Get<IDBPath>().GetDbPath());
            RegistrarCommands();
        }

        public async Task AtualizarItensAtendimentoAsync()
        {
            Atendimento.Servicos = await atendimentoItemDAL.GetAllAsync();
            ItensAtendimento.SincronizarColecoes(Atendimento.Servicos);
            OnPropertyChanged(nameof(SubTotalItens));
        }

        public AtendimentoItem ServicoSelecionado
        {
            get { return this.AtendimentoItem; }
            set
            {
                if (value != null)
                {
                    this.AtendimentoItem = value;
                    this.AtendimentoItem.Atendimento = this.Atendimento;
                    MessagingCenter.Send<AtendimentoItem>(ServicoSelecionado, "Mostrar");
                }
            }
        }

        public double SubTotalItens
        {
            get
            {
                return this.ItensAtendimento.Sum(st => st.SubTotal);
            }
        }

        public ICommand EliminarItemCommand { get; set; }
        public ICommand NovoCommand { get; set; }

        private void RegistrarCommands()
        {
            EliminarItemCommand = new Command<AtendimentoItem>((atendimentoItem) =>
            {
                MessagingCenter.Send<AtendimentoItem>(atendimentoItem, "Confirmação");
            });
            NovoCommand = new Command(() =>
            {
                var atendimentoItem = new AtendimentoItem() { Atendimento = this.Atendimento, AtendimentoID = this.Atendimento.AtendimentoID };
                MessagingCenter.Send<AtendimentoItem>(atendimentoItem, "Mostrar");
            }, () =>
            {
                return !this.Atendimento.EstaFinalizado;
            });
        }

        public async Task EliminarItemAtendimento(AtendimentoItem atendimentoItem)
        {
            await atendimentoItemDAL.DeleteAsync(atendimentoItem);
            this.ItensAtendimento.Remove(atendimentoItem);
            this.Atendimento.Servicos.Remove(atendimentoItem);
            OnPropertyChanged(nameof(SubTotalItens));
        }
    }
}
