using Modulo1.Dal;
using Modulo1.Modelo;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Modulo1.Pages.TiposItensCardapio
{
    public partial class TiposItensCardapioListPage : ContentPage
    {
        private TipoItemCardapioDAL dalTipoItemCardapio = TipoItemCardapioDAL.GetInstance();

        public TiposItensCardapioListPage()
        {
            InitializeComponent();
            lvTiposItensCardapio.ItemsSource = dalTipoItemCardapio.GetAll();
        }

        public async void OnAlterarClick(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var item = mi.CommandParameter as TipoItemCardapio;
            await Navigation.PushModalAsync(new TiposItensCardapioEditPage(item));
        }

        public async void OnRemoverClick(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var item = mi.CommandParameter as TipoItemCardapio;
            var opcao = await DisplayAlert("Confirmação de exclusão", 
                "Confirma excluir o item " + item.Nome.ToUpper() + "?", "Sim", "Não");
            if (opcao)
            {
                dalTipoItemCardapio.Remove(item);
            }
        }
    }
}
