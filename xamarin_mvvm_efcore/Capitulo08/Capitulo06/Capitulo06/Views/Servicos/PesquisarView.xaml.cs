using Capitulo06.ViewModels.Servicos;
using CasaDoCodigo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Capitulo06.Views.Servicos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PesquisarView : ContentPage
	{
        private PesquisarViewModel viewModel;
        public static Servico ServicoSelecionado { get; set; }

        public PesquisarView()
        {
            InitializeComponent();
            viewModel = new PesquisarViewModel();
            BindingContext = viewModel;
            ServicoSelecionado = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Servico>(this, "ServicoSelecionado",
                (servico) =>
                {
                    ServicoSelecionado = servico;
                    Navigation.PopAsync();
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Servico>(this, "ServicoSelecionado");
        }
    }
}