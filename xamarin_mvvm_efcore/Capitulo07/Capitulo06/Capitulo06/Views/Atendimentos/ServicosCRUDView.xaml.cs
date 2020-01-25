using Capitulo06.ViewModels.Atendimentos;
using Capitulo06.Views.Servicos;
using CasaDoCodigo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Capitulo06.Views.Atendimentos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ServicosCRUDView : ContentPage
	{
        private ServicosCRUDViewModel crudViewModel;

        public ServicosCRUDView ()
		{
			InitializeComponent ();
		}


        public ServicosCRUDView(AtendimentoItem item, string title) : this()
        {
            this.Title = title;
            this.crudViewModel = new ServicosCRUDViewModel(item);
            this.BindingContext = this.crudViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (PesquisarView.ServicoSelecionado != null)
                crudViewModel.Servico = PesquisarView.ServicoSelecionado;

            MessagingCenter.Subscribe<AtendimentoItem>(this, "MostrarPesquisarServico",
                async (item) =>
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
            PesquisarView.ServicoSelecionado = null;
            MessagingCenter.Unsubscribe<AtendimentoItem>(this, "MostrarPesquisarServico");
            MessagingCenter.Unsubscribe<string>(this, "InformacaoCRUD");
        }
    }
}