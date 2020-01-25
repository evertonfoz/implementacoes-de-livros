using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Capitulo06.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPageView : ContentPage
	{
        public Models.MenuItem[] OpcoesMenu { get; set; }
        public ListView ListView { get; set; }

        public MasterPageView()
        {
            Icon = "menu.png";

            InitializeComponent();
            OpcoesMenu = new[]
            {
                    new Models.MenuItem { Id = 0, Title = "Clientes", TargetType = typeof(Clientes.ListagemView), IconSource="tab_clientes.png"},
                    new Models.MenuItem { Id = 0, Title = "Serviços", TargetType = typeof(Servicos.ListagemView), IconSource="tab_servicos.png"}
            };
            ListView = itensMenuListView;
            BindingContext = this;
        }
    }
}