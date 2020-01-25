using Capitulo06.ViewModels.Atendimentos;
using Capitulo06.Views.Clientes;
using CasaDoCodigo.Models;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Capitulo06.Views.Atendimentos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CRUDView : ContentPage
	{
        private CRUDViewModel crudViewModel;

        public CRUDView ()
		{
			InitializeComponent ();
		}

        public CRUDView(Atendimento atendimento, string title) : this()
        {
            this.Title = title;
            this.crudViewModel = new CRUDViewModel(atendimento);
            this.BindingContext = this.crudViewModel;
        }

        protected override void OnAppearing()
        {
            if (PesquisarView.ClienteSelecionado != null)
                crudViewModel.Cliente = PesquisarView.ClienteSelecionado;

            MessagingCenter.Subscribe<Atendimento>(this, "MostrarPesquisarCliente",
                async (atendimento) =>
                {
                    await Navigation.PushAsync(new PesquisarView());
                });

            MessagingCenter.Subscribe<string>(this, "InformacaoCRUD",
                async (msg) =>
                {
                    await DisplayAlert("Informação", msg, "ok");
                });

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            PesquisarView.ClienteSelecionado = null;
            MessagingCenter.Unsubscribe<Atendimento>(this, "MostrarPesquisarCliente");
            MessagingCenter.Unsubscribe<string>(this, "InformacaoCRUD");
        }
    }
}