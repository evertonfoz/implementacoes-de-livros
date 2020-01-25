using Capitulo05.Models;
using Capitulo05.ViewModels.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace Capitulo05.Views.Servicos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListagemView : ContentPage { 
	
        private ListagemViewModel viewModel;

        public ListagemView ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new ListagemViewModel();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetLargeTitleDisplay(LargeTitleDisplayMode.Never);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.AtualizarServicos();

            if (listView.SelectedItem != null)
                listView.SelectedItem = null;

            MessagingCenter.Subscribe<Servico>(this, "Mostrar", async (servicoSelecionado) => {
                await Navigation.PushAsync(new CRUDView(servicoSelecionado, viewModel.Servicos));
            });

            MessagingCenter.Subscribe<Servico>(this, "Confirmação", async (servico) => await RemoverServico(servico));
        }

        private async Task RemoverServico(Servico servico)
        {
            if (await DisplayAlert("Confirmação",
                $"Confirma remoção de {servico.Nome.ToUpper()}?", "Yes", "No"))
            {
                this.viewModel.EliminarServico(servico);
                //await this.viewModel.AtualizarServicos();
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