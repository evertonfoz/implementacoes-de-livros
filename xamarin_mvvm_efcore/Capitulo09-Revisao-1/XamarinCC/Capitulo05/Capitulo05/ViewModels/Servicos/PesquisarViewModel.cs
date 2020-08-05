using CasaDoCodigo.DataAccess;
using CasaDoCodigo.DataAccess.Interfaces;
using OficinaModels.Cadastros;
using SQLiteEF.DAL;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Capitulo05.ViewModels.Servicos
{
    public class PesquisarViewModel
    {
        private IDAL<Servico> servicoDAL;
        public ObservableCollection<Servico> ServicosEncontrados { get; set; }
        public ICommand PesquisarCommand { get; set; }
        private Servico servicoLocalizadoSelecionado;
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
