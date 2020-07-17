using Modulo1.Dal;
using Modulo1.Modelo;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Modulo1.Paginas.ItensCardapio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItensCardapioSearchPage : ContentPage
    {
        private ItemCardapioDAL dalItensCardapio = new ItemCardapioDAL();
        private Label displayValue;
        private Label keyValue;
        private IEnumerable<ItemCardapio> itens;

        public ItensCardapioSearchPage(Label keyValue, Label displayValue)
        {
            InitializeComponent();
            itens = dalItensCardapio.GetAllWithChildren();
            this.keyValue = keyValue;
            this.displayValue = displayValue;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            lvItens.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                lvItens.ItemsSource = itens;
            else
                lvItens.ItemsSource = itens.Where(i => i.Nome.Contains(e.NewTextValue));

            lvItens.EndRefresh();
        }

        public async void OnItemTapped(object o, ItemTappedEventArgs e)
        {
            var item = (o as ListView).SelectedItem as ItemCardapio;
            this.keyValue.Text = item.ItemCardapioId.ToString();
            this.displayValue.Text = item.Nome.Trim() + " / " + item.TipoItemCardapio.Nome;
            await Navigation.PopAsync();
        }
    }
}