
using Capitulo04.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Capitulo04.Views.ContentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NavigationPageVeiculosView : ContentPage
	{
        public Cliente Cliente { get; private set; }

        public NavigationPageVeiculosView ()
		{
			InitializeComponent ();
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