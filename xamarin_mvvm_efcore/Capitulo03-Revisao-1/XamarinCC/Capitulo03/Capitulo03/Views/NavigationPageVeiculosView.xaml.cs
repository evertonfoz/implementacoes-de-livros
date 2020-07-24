using Capitulo03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Capitulo03.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationPageVeiculosView : ContentPage
    {
        public Cliente Cliente { get; private set; }
        public NavigationPageVeiculosView()
        {
            InitializeComponent();
        }

        public NavigationPageVeiculosView(Cliente cliente)
        {
            InitializeComponent();
            Title = $"Veículos de {cliente.Nome}";
            listViewVeiculos.ItemsSource = cliente.Veiculos;
            this.Cliente = cliente;
        }
    }
}