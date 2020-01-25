using Capitulo05.Models;
using Capitulo05.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Capitulo05.ViewModels.Servicos
{
    public class ListagemViewModel : BaseViewModel
    {
        public IDataStore<Servico> DataStore = new ServicoDataStore();
        public ObservableCollection<Servico> Servicos { get; set; }
        public ICommand NovoCommand { get; set; }
        public ICommand EliminarCommand { get; set; }

        public ListagemViewModel()
        {
            RegistrarCommands();
        }

        private void RegistrarCommands()
        {
            NovoCommand = new Command(() =>
            {
                MessagingCenter.Send<Servico>(new Servico(), "Mostrar");
            });

            EliminarCommand = new Command<Servico>((servico) =>
            {
                MessagingCenter.Send<Servico>(servico, "Confirmação");
            });
        }

        public void EliminarServico(Servico servico)
        {
            DataStore.Delete(servico);
            this.Servicos.Remove(servico);
        }

        public void AtualizarServicos()
        {
            if (Servicos == null)
                Servicos = new ObservableCollection<Servico>(DataStore.GetAll().OrderBy(s => s.Nome));
            else
                Servicos = new ObservableCollection<Servico>(Servicos.OrderBy(s => s.Nome));
            OnPropertyChanged(nameof(Servicos));
        }

        private Servico servicoSelecionado;
        public Servico ServicoSelecionado
        {
            get { return servicoSelecionado; }
            set
            {
                if (value != null)
                {
                    servicoSelecionado = value;
                    MessagingCenter.Send<Servico>(servicoSelecionado, "Mostrar");
                }
            }
        }
    }
}
