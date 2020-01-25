using Capitulo06.ExtensionMethods;
using CasaDoCodigo.DAL;
using CasaDoCodigo.DataAccess.Interfaces;
using CasaDoCodigo.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Capitulo06.ViewModels.Clientes
{
    public class ListagemViewModel : BaseViewModel
    {
        private IDAL<Cliente> clientesDAL;
        public ObservableCollection<Cliente> Clientes { get; set; }
        public ICommand NovoCommand { get; set; }
        public ICommand EliminarCommand { get; set; }
        private Cliente clienteSelecionado;

        public ListagemViewModel()
        {
            Clientes = new ObservableCollection<Cliente>();
            clientesDAL = new ClienteDAL(DependencyService.Get<IDBPath>().GetDbPath());
            RegistrarCommands();
        }

        public Cliente ClienteSelecionado
        {
            get { return clienteSelecionado; }
            set
            {
                if (value != null)
                {
                    clienteSelecionado = value;
                    MessagingCenter.Send<Cliente>(clienteSelecionado, "Mostrar");
                }
            }
        }

        public async Task EliminarClienteAsync(Cliente cliente)
        {
            var atendimentos = await (clientesDAL as ClienteDAL).GetAtendimentosAsync(cliente);
            if (atendimentos.Any())
                throw new Exception("O cliente a ser removido possui atendimentos registrados em seu nome");

            await clientesDAL.DeleteAsync(cliente);
            Clientes.Remove(cliente);
        }

        private void RegistrarCommands()
        {
            NovoCommand = new Command(() =>
            {
                MessagingCenter.Send<Cliente>(new Cliente(), "Mostrar");
            });

            EliminarCommand = new Command<Cliente>((cliente) =>
            {
                MessagingCenter.Send<Cliente>(cliente, "Confirmação");
            });
        }

        public async Task AtualizarClientesAsync()
        {
            var clientes = await clientesDAL.GetAllAsync();
            Clientes.SincronizarColecoes(clientes);
        }
    }
}
