using Modulo1.Dal;
using Modulo1.Modelo;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Modulo1.ViewModel
{
    public class ClienteViewModel : INotifyPropertyChanged
    {
        private long? _clienteId;
        private string _nome;
        private string _telefone;
        private string _endereco;
        private string _numero;
        private string _bairro;
        private string _cidade;
        private string _estado;

        public ClienteViewModel(Cliente cliente)
        {
            this._clienteId = cliente.ClienteId;
            this._telefone = cliente.Telefone;
            this._nome = cliente.Nome;
            this._endereco = cliente.Endereco;
            this._numero = cliente.Numero;
            this._bairro = cliente.Bairro;
            this._cidade = cliente.Cidade;
            this._estado = cliente.Estado;
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; OnPropertyChanged(); }
        }

        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; OnPropertyChanged(); }
        }

        public string Endereco
        {
            get { return _endereco; }
            set { _endereco = value; OnPropertyChanged(); }
        }

        public string Numero
        {
            get { return _numero; }
            set { _numero = value; OnPropertyChanged(); }
        }

        public string Bairro
        {
            get { return _bairro; }
            set { _bairro = value; OnPropertyChanged(); }
        }

        public string Cidade
        {
            get { return _cidade; }
            set { _cidade = value; OnPropertyChanged(); }
        }

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; OnPropertyChanged(); }
        }

        public ICommand Gravar
        {
            get
            {
                var clienteDAL = new ClienteDAL();
                return new Command(() =>
                {
                    clienteDAL.Add(GetObjectFromView());
                    App.Current.MainPage.DisplayAlert("Inserção Cliente", "Cliente inserido com sucesso", "OK");
                });
            }
        }

        public Cliente GetObjectFromView()
        {
            return new Cliente()
            {
                Nome = this.Nome,
                Telefone = this.Telefone,
                Endereco = this.Endereco,
                Numero = this.Numero,
                Bairro = this.Bairro,
                Cidade = this.Cidade,
                Estado = this.Estado
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
