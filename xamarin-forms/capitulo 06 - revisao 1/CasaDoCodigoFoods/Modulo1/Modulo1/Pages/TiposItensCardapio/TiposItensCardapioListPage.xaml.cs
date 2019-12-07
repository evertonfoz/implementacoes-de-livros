using Modulo1.Dal;
using System;
using Modulo1.Modelo;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Modulo1.Pages.TiposItensCardapio
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TiposItensCardapioListPage : ContentPage
	{
        private TipoItemCardapioDAL dalTipoItemCardapio = new TipoItemCardapioDAL();

        public TiposItensCardapioListPage()
        {
            InitializeComponent();
//            lvTiposItensCardapio.ItemsSource = dalTipoItemCardapio.GetAll();
        }

        public async void OnRemoverClick(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var item = mi.CommandParameter as TipoItemCardapio;
            var opcao = await DisplayAlert("Confirmação de exclusão", "Confirma excluir o item " + item.Nome.ToUpper() + "?", "Sim", "Não");
            if (opcao)
            {
                dalTipoItemCardapio.DeleteById((long)item.Id);
                lvTiposItensCardapio.ItemsSource = dalTipoItemCardapio.GetAll();
            }
        }

        public async void OnAlterarClick(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var item = mi.CommandParameter as TipoItemCardapio;
            await Navigation.PushModalAsync(new TiposItensCardapioEditPage(item));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvTiposItensCardapio.ItemsSource = dalTipoItemCardapio.GetAll();
        }
    }
}