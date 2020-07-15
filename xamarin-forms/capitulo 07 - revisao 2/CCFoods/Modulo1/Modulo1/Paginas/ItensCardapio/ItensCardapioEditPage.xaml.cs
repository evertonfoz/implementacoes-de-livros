using Modulo1.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Modulo1.Paginas.ItensCardapio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItensCardapioEditPage : ContentPage
    {
        public ItensCardapioEditPage(ItemCardapio itemCardapio)
        {
            InitializeComponent();
            gridControl.PopularControles(itemCardapio);
        }
    }
}