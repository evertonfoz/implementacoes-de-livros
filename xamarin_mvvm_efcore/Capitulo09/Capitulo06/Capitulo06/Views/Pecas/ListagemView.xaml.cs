using Capitulo06.ViewModels.Pecas;
using CasaDoCodigo.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Capitulo06.Views.Pecas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListagemView : ContentPage
	{
        private ListagemViewModel viewModel = new ListagemViewModel();

        public ListagemView ()
		{
			InitializeComponent ();
            viewModel.Sincronizando = true;
            BindingContext = viewModel;
        }

        private async Task RemoverPeca(Peca peca)
        {
            if (await DisplayAlert("Confirmação",
                $"Confirma remoção de {peca.Nome.ToUpper()}?", "Yes", "No"))
            {
                try
                {
                    await this.viewModel.EliminarPeca(peca);
                    await DisplayAlert("Informação", "Peça removida com sucesso", "Ok");

                }
                catch (Exception e)
                {
                    await DisplayAlert("Erro", e.Message, "Ok");
                }
            }
            return;
        }

        protected void OnBindingContextChanged(object sender, EventArgs e)
        {
            base.OnBindingContextChanged();
            ViewCell theViewCell = ((ViewCell)sender);
            var peca = (Peca)theViewCell.BindingContext;
            if (peca != null && peca.Sincronizado)
            {
                var itemSincronizar = theViewCell.ContextActions.Where(i => i.Text.Equals("Sincronizar")).First();
                theViewCell.ContextActions.Remove(itemSincronizar);
            }
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.BeginInvokeOnMainThread(async () =>
            {
                await viewModel.AtualizarPecasAsync();
                if (!viewModel.AtualizandoImagens)
                    viewModel.AtualizarImagens();
            });

            viewModel.Sincronizando = false;

            if (listView.SelectedItem != null)
                listView.SelectedItem = null;

            MessagingCenter.Subscribe<Peca>(this, "Mostrar", async (peca) => { await Navigation.PushAsync(new CRUDView(peca, (peca.PecaID == Guid.Empty) ? "Nova Peça" : "Alterar Peça")); });
            MessagingCenter.Subscribe<Peca>(this, "Confirmação", async (peca) => await RemoverPeca(peca));
            MessagingCenter.Subscribe<string>(this, "Informação", async (msg) => { await DisplayAlert("Informação", msg, "ok"); });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Peca>(this, "Mostrar");
            MessagingCenter.Unsubscribe<Peca>(this, "Confirmação");
            MessagingCenter.Unsubscribe<string>(this, "Informação");
        }
    }
}