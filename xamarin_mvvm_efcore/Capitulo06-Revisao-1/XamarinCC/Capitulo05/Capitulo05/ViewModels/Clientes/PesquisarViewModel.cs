using CasaDoCodigo.DAL;
using CasaDoCodigo.DataAccess;
using CasaDoCodigo.DataAccess.Interfaces;
using CasaDoCodigo.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Capitulo05.ViewModels.Clientes
{
    public class PesquisarViewModel
    {
        private IDAL<Cliente> clienteDAL;
        public ObservableCollection<Cliente> ClientesEncontrados { get; set; }
        public ICommand PesquisarCommand { get; set; }

        public PesquisarViewModel()
        {
            clienteDAL = new ClienteDAL(DependencyService.Get<IDBPath>().GetDbPath());
            ClientesEncontrados = new ObservableCollection<Cliente>();
            RegistrarCommands();
        }

        private void RegistrarCommands()
        {
            PesquisarCommand = new Command<string>(async (cliente) =>
            {
                ClientesEncontrados.Clear();
                var clientesEncontrados = await clienteDAL.GetStartsWithByFieldAsync(nameof(Cliente.Nome), cliente);
                foreach (var c in clientesEncontrados)
                {
                    ClientesEncontrados.Add(c);
                }
            });
        }

        private Cliente clienteLocalizadoSelecionado;
        public Cliente ClienteLocalizadoSelecionado
        {
            get { return clienteLocalizadoSelecionado; }
            set
            {
                if (value != null)
                {
                    clienteLocalizadoSelecionado = value;
                    MessagingCenter.Send<Cliente>(clienteLocalizadoSelecionado, "ClienteSelecionado");
                }
            }
        }
    }
}
