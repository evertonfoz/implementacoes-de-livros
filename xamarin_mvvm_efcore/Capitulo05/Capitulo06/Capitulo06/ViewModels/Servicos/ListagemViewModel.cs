using Capitulo06.ExtensionMethods;
using CasaDoCodigo.DAL;
using CasaDoCodigo.DataAccess.Interfaces;
using CasaDoCodigo.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Capitulo06.ViewModels.Servicos
{
    public class ListagemViewModel
    {
        private IDAL<Servico> servicosDAL;
        public ObservableCollection<Servico> Servicos { get; set; }
        public ICommand NovoCommand { get; set; }
        public ICommand EliminarCommand { get; set; }

        public ListagemViewModel()
        {
            servicosDAL = new ServicoDAL(DependencyService.Get<IDBPath>().GetDbPath());
            Servicos = new ObservableCollection<Servico>();
            RegistrarCommands();
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

        public async Task AtualizarServicosAsync()
        {
            var servicos = await servicosDAL.GetAllAsync();
            Servicos.SincronizarColecoes(servicos);
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

        public async Task EliminarServicoAsync(Servico servico)
        {
            await servicosDAL.DeleteAsync(servico);
            Servicos.Remove(servico);
        }
    }
}
