using Modulo1.Modelo;
using Xamarin.Forms;

namespace Modulo1.Pages.ItensCardapio
{
    public partial class ItensCardapioEditPage : ContentPage
    {
        public ItensCardapioEditPage(ItemCardapio itemCardapio)
        {
            InitializeComponent();
            gridControl.PopularControles(itemCardapio);
        }
    }
}
