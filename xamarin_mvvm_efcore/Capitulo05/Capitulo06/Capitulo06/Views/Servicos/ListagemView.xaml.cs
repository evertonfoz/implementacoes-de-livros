using Capitulo06.ViewModels.Servicos;
using CasaDoCodigo.Models;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Capitulo06.Views.Servicos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListagemView : ContentPage
	{
        private ListagemViewModel viewModel;

        public ListagemView ()
		{
			InitializeComponent ();
            viewModel = new ListagemViewModel();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.BeginInvokeOnMainThread(async () =>
            {
                await viewModel.AtualizarServicosAsync();
            });

            if (listView.SelectedItem != null)
                listView.SelectedItem = null;

            MessagingCenter.Subscribe<Servico>(this, "Mostrar",
                            async (servico) =>
                            {
                                await Navigation.PushAsync(new CRUDView(servico, servico.ServicoID == null ? "Novo Serviço" : "Alterar Serviço"));
                            });

            MessagingCenter.Subscribe<Servico>(this, "Confirmação", async (servico) => await RemoverServicoAsync(servico));
        }

        private async Task RemoverServicoAsync(Servico servico)
        {
            if (await DisplayAlert("Confirmação",
                $"Confirma remoção de {servico.Nome.ToUpper()}?", "Yes", "No"))
            {
                await this.viewModel.EliminarServicoAsync(servico);
                await DisplayAlert("Informação", "Serviço removido com sucesso", "Ok");
            }
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Servico>(this, "Mostrar");
            MessagingCenter.Unsubscribe<Servico>(this, "Confirmação");
        }
    }
}