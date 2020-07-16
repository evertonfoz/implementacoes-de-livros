using Modulo1.Dal;
using Modulo1.Modelo;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Modulo1.Paginas.TiposItensCardapio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TiposDeItensCardapioSearchPage : ContentPage
    {
        private TipoItemCardapioDAL dalTipoItemCardapio = new TipoItemCardapioDAL();
        private Label displayValue;
        private Label keyValue;
        private IEnumerable<TipoItemCardapio> itens;

        public TiposDeItensCardapioSearchPage(Label keyValue, Label displayValue)
        {
            InitializeComponent();
            itens = dalTipoItemCardapio.GetAll();
            this.keyValue = keyValue;
            this.displayValue = displayValue;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            lvTipos.BeginRefresh();
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                lvTipos.ItemsSource = itens;
            else
                lvTipos.ItemsSource = itens.Where(i => i.Nome.Contains(e.NewTextValue));
            lvTipos.EndRefresh();
        }

        public async void OnItemTapped(object o, ItemTappedEventArgs e)
        {
            var item = (o as ListView).SelectedItem as TipoItemCardapio;
            this.keyValue.Text = item.TipoItemCardapioId.ToString();
            this.displayValue.Text = item.Nome;
            await Navigation.PopAsync();
        }
    }
}