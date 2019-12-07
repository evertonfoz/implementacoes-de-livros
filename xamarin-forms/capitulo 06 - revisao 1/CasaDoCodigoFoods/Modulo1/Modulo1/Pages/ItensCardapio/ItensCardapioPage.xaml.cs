using Modulo1.Dal;
using Modulo1.HelperControls;
using Modulo1.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Modulo1.Pages.ItensCardapio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItensCardapioPage : ContentPage
    {
        private TipoItemCardapioDAL dalTipoItemCardapio = new TipoItemCardapioDAL();
        private ItemCardapioDAL dalItemCardapio = new ItemCardapioDAL();

        public ItensCardapioPage()
        {
            InitializeComponent();
            BtnNovoItem.Clicked += BtnNovoItemClick;
        }

        private async void BtnNovoItemClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItensCardapioNewPage());
        }

        private Collection<ListViewGrouping<TipoItemCardapio, ItemCardapio>> GetDataByGroup()
        {
            var dadosAgrupados = new Collection<ListViewGrouping<TipoItemCardapio, ItemCardapio>>();
            var tipos = dalTipoItemCardapio.GetAllWithChildren();
            foreach (var tipo in tipos)
            {
                dadosAgrupados.Add(new ListViewGrouping<TipoItemCardapio, ItemCardapio>(tipo, tipo.Itens));
            }
            return dadosAgrupados;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvItensCardapio.ItemsSource = GetDataByGroup();
        }

        public async void OnAlterarClick(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var item = mi.CommandParameter as ItemCardapio;
            await Navigation.PushAsync(new ItensCardapioEditPage(item));
        }

        public async void OnRemoverClick(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var item = mi.CommandParameter as ItemCardapio;
            var opcao = await DisplayAlert("Confirmação de exclusão",
                "Confirma excluir o item " + item.Nome.ToUpper() + "?", "Sim", "Não");
            if (opcao)
            {
                dalItemCardapio.DeleteById((long)item.ItemCardapioId);
                this.lvItensCardapio.ItemsSource = GetDataByGroup();
            }
        }
    }
}