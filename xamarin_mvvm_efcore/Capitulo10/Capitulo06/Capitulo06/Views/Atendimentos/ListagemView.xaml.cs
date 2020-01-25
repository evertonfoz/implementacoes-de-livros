using Capitulo06.ViewModels.Atendimentos;
using CasaDoCodigo.Models;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Capitulo06.Views.Atendimentos
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

        private async Task<bool> ExibirOpcoes(Atendimento atendimento)
        {
            viewModel.AtendimentoSelecionado = null;
            string result;
            if (atendimento.EstaFinalizado)
                result = await DisplayActionSheet("Opções para o Atendimento " + atendimento.AtendimentoID, "Cancelar", "Consultar");
            else
                result = await DisplayActionSheet("Opções para o Atendimento " + atendimento.AtendimentoID, "Cancelar", "Alterar", "Registrar Entrega", "Remover OS");
            ProcessarOpcaoRespondida(atendimento, result);
            return await Task.FromResult(true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.BeginInvokeOnMainThread(async () =>
            {
                await viewModel.AtualizarAtendimentosAsync();
            });

            if (listView.SelectedItem != null)
                listView.SelectedItem = null;

            MessagingCenter.Subscribe<Atendimento>(this, "Mostrar", async (atendimento) => { await Navigation.PushAsync(new CRUDView(atendimento, "Novo Atendimento")); });

            MessagingCenter.Subscribe<Atendimento>(this, "MostrarOpcoes", async (atendimento) => { await ExibirOpcoes(atendimento); });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Atendimento>(this, "Mostrar");
            MessagingCenter.Unsubscribe<Atendimento>(this, "MostrarOpcoes");
        }

        private async void ProcessarOpcaoRespondida(Atendimento atendimento, string result)
        {
            if (result.Equals("Consultar") || result.Equals("Alterar"))
            {
                var title = result + " Atendimento " + atendimento.AtendimentoID;
                await Navigation.PushAsync(new CRUDView(atendimento, title));
            }
            else if (result.Equals("Registrar Entrega"))
            {
                await viewModel.RegistrarEntrega(atendimento);
                //await viewModel.AtualizarAtendimentos();
                await DisplayAlert("Informação", "Entrega registrada com sucesso.", "Ok");
                listView.SelectedItem = null;
            }
            else if (result.Equals("Remover OS"))
            {
                if (await DisplayAlert("Confirmação",
                    $"Confirma remoção da OS {atendimento.AtendimentoID}?", "Yes", "No"))
                {
                    await viewModel.EliminarAtendimento(atendimento);
                    //await viewModel.AtualizarAtendimentos();
                    await DisplayAlert("Informação", "Atendimento removido com sucesso", "Ok");
                }
            }
        }
    }
}