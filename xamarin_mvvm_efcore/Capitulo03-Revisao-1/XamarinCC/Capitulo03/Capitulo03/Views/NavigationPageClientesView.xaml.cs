using Capitulo03.Models;
using Capitulo03.Servicos;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Capitulo03.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationPageClientesView : ContentPage
    {
        public NavigationPageClientesView()
        {
            InitializeComponent();
            listViewClientes.ItemsSource = new DadosParaTeste().Clientes;
        }
        private async void listViewClientes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var cliente = e.SelectedItem as Cliente;
            await Navigation.PushAsync(new NavigationPageVeiculosView(cliente));
            ((ListView)sender).SelectedItem = null;
        }
    }
}