using Modulo1.Pages.Entregadores;
using Modulo1.Pages.Garcons;
using Modulo1.Pages.TiposItensCardapio;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Modulo1.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private async void GarconsOnClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new GarconsPage());
        }

        private async void EntregadoresOnClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new EntregadoresPage());
        }

        private async void TiposItensCardapioOnClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new TiposItensCardapioPage());
        }
    }
}