using Modulo1.Dal;
using Modulo1.Modelo;
using System;
using Xamarin.Forms;

namespace Modulo1.Pages.Clientes
{
    public partial class ClientesListPage : ContentPage
    {
        private ClienteDAL clienteDAL = new ClienteDAL();

        public ClientesListPage()
        {
            InitializeComponent();
            BtnNovoItem.Clicked += BtnNovoItemClick;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvClientes.ItemsSource = clienteDAL.GetAll();
        }

        private async void BtnNovoItemClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClientesCRUDPage(new Cliente()));
        }

        public async void OnAlterarClick(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var cliente = mi.CommandParameter as Cliente;
            await Navigation.PushAsync(new ClientesCRUDPage(cliente));
        }

        public async void OnRemoverClick(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var cliente = mi.CommandParameter as Cliente;
            var opcao = await DisplayAlert("Confirmação de exclusão",
                "Confirma excluir o cliente " + cliente.Nome.ToUpper() + "?", "Sim", "Não");
            if (opcao)
            {
                clienteDAL.DeleteById((long)cliente.ClienteId);
                this.lvClientes.ItemsSource = clienteDAL.GetAll();
            }
        }
    }
}
