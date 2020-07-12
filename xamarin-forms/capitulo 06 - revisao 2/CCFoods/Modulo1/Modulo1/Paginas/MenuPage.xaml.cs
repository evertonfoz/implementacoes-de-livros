using Modulo1.Paginas.Entregadores;
using Modulo1.Paginas.Garcons;
using Modulo1.Paginas.ItensCardapio;
using Modulo1.Paginas.TiposItensCardapio;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Modulo1.Paginas
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

        private async void ItensCardapioOnClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ItensCardapioPage());
        }

    }
}