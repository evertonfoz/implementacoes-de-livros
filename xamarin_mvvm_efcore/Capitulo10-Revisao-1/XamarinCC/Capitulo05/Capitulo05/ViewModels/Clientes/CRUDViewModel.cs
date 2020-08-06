using CasaDoCodigo.DAL;
using CasaDoCodigo.DataAccess;
using CasaDoCodigo.DataAccess.Interfaces;
using CasaDoCodigo.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Capitulo05.ViewModels.Clientes
{
    public class CRUDViewModel : BaseViewModel
    {
        private IDAL<Cliente> clientesDAL;
        private Cliente Cliente { get; set; }
        public ICommand GravarCommand { get; set; }

        public CRUDViewModel(Cliente cliente)
        {
            clientesDAL = new ClienteDAL(DependencyService.Get<IDBPath>().GetDbPath());
            this.Cliente = cliente;
            RegistrarCommands();
        }
        public string Nome
        {
            get { return this.Cliente.Nome; }
            set
            {
                this.Cliente.Nome = value;
                ((Command)GravarCommand).ChangeCanExecute();
                OnPropertyChanged();
            }
        }

        public string Telefone
        {
            get { return this.Cliente.Telefone; }
            set
            {
                this.Cliente.Telefone = value;
                ((Command)GravarCommand).ChangeCanExecute();
                OnPropertyChanged();
            }
        }

        public string EMail
        {
            get { return this.Cliente.EMail; }
            set
            {
                this.Cliente.EMail = value;
                ((Command)GravarCommand).ChangeCanExecute();
                OnPropertyChanged();
            }
        }
        private async Task GravarAsync()
        {
            var ehNovoCliente = (Cliente.ClienteID == null ? true : false);
            await clientesDAL.UpdateAsync(Cliente, Cliente.ClienteID);
            AtualizarPropriedadesParaVisao(ehNovoCliente);
        }

        private void AtualizarPropriedadesParaVisao(bool ehNovoObjeto)
        {
            if (ehNovoObjeto)
            {
                this.Nome = string.Empty;
                this.EMail = string.Empty;
                this.Telefone = string.Empty;
                this.Cliente = new Cliente();
            }
            else
            {
                this.Cliente.NotificarListView = true;
            }

        }
        private void RegistrarCommands()
        {
            GravarCommand = new Command(async () =>
            {
                await GravarAsync();
                MessagingCenter.Send<string>("Atualização realizada com sucesso.", "InformacaoCRUD");
            }, () =>
            {
                return !string.IsNullOrEmpty(this.Cliente.Nome) && !string.IsNullOrEmpty(this.Cliente.Telefone) && !string.IsNullOrEmpty(this.Cliente.EMail);
            });
        }
    }
}
