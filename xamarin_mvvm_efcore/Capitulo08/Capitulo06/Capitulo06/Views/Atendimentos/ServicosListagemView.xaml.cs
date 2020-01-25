using Capitulo06.ViewModels.Atendimentos;
using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Capitulo06.Views.Atendimentos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ServicosListagemView : ContentPage
	{
        private ServicosListagemViewModel viewModel;
        private Atendimento Atendimento;

		public ServicosListagemView (Atendimento atendimento)
		{
			InitializeComponent ();
            this.Atendimento = atendimento;
            BindingContext = viewModel = new ServicosListagemViewModel(atendimento);
        }

        protected void OnBindingContextChanged(object sender, EventArgs e)
        {
            base.OnBindingContextChanged();
            if (this.Atendimento.EstaFinalizado)
            {
                ViewCell theViewCell = ((ViewCell)sender);
                theViewCell.ContextActions.Clear();
            }
        }

        private async Task RemoverItem(AtendimentoItem item)
        {
            if (await DisplayAlert("Confirmação",
                $"Confirma remoção de {item.Servico.Nome.ToUpper()}?", "Yes", "No"))
            {
                await this.viewModel.EliminarItemAtendimento(item);
                await DisplayAlert("Informação", "Serviço removido com sucesso", "Ok");
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.BeginInvokeOnMainThread(async () =>
            {
                await viewModel.AtualizarItensAtendimentoAsync();
            });

            if (listView.SelectedItem != null)
                listView.SelectedItem = null;

            MessagingCenter.Subscribe<AtendimentoItem>(this, "Confirmação", async (item) => await RemoverItem(item));
            MessagingCenter.Subscribe<AtendimentoItem>(this, "Mostrar", async (item) => { await Navigation.PushAsync(new ServicosCRUDView(item, "Serviço Atendimento")); });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<AtendimentoItem>(this, "Confirmação");
            MessagingCenter.Unsubscribe<AtendimentoItem>(this, "Mostrar");
        }
    }
}