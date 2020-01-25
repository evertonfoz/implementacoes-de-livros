using CasaDoCodigo.DAL;
using CasaDoCodigo.DataAccess;
using CasaDoCodigo.DataAccess.Interfaces;
using CasaDoCodigo.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Capitulo06.ViewModels.Servicos
{
    public class PesquisarViewModel
    {
        private IDAL<Servico> servicoDAL;
        public ObservableCollection<Servico> ServicosEncontrados { get; set; }
        public ICommand PesquisarCommand { get; set; }

        public PesquisarViewModel()
        {
            servicoDAL = new ServicoDAL(DependencyService.Get<IDBPath>().GetDbPath());
            ServicosEncontrados = new ObservableCollection<Servico>();
            RegistrarCommands();
        }

        private void RegistrarCommands()
        {
            PesquisarCommand = new Command<string>((servico) =>
            {
                ServicosEncontrados.Clear();
                var servicosEncontrados = servicoDAL.GetStartsWithByFieldAsync("Nome", servico).Result;
                foreach (var c in servicosEncontrados)
                {
                    ServicosEncontrados.Add(c);
                }
            });
        }

        private Servico servicoLocalizadoSelecionado;
        public Servico ServicoLocalizadoSelecionado
        {
            get { return servicoLocalizadoSelecionado; }
            set
            {
                if (value != null)
                {
                    servicoLocalizadoSelecionado = value;
                    MessagingCenter.Send<Servico>(servicoLocalizadoSelecionado, "ServicoSelecionado");
                }
            }
        }
    }
}
