using Modulo1.Modelo;
using Modulo1.ViewModel;
using System;
using Xamarin.Forms;

namespace Modulo1.Pages.Clientes
{
    public partial class ClientesCRUDPage : ContentPage { 
        private ClienteViewModel clienteViewModel;

        public ClientesCRUDPage(Cliente cliente)
        {
            InitializeComponent();
            if (cliente.ClienteId == null)
            {
                Title = "Inserção de um novo cliente";
            } else
            {
                Title = "Alteração dos dados do cliente";
            }
            clienteViewModel = new ClienteViewModel(cliente);
            BindingContext = clienteViewModel;
            BtnVisualizarMapa.Clicked += BtnVisualizarMapaClicked;
        }

        private async void BtnVisualizarMapaClicked(object sender, EventArgs e)
        {
            var cliente = clienteViewModel.GetObjectFromView();
            var endereco = cliente.Numero + " " + cliente.Endereco + ", " + cliente.Bairro + ", " + cliente.Cidade + ", " + cliente.Estado;
            await Navigation.PushAsync(new ClientesMapPage(endereco));
        }
    }
}
