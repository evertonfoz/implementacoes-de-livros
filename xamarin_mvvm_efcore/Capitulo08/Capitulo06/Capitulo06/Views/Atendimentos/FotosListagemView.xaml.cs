using Capitulo06.ViewModels.Atendimentos;
using CasaDoCodigo.Models;
using Interfaces.Fotos;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace Capitulo06.Views.Atendimentos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FotosListagemView : ContentPage
	{
        private FotosListagemViewModel viewModel;

        public FotosListagemView (Atendimento atendimento)
		{
			InitializeComponent ();
            BindingContext = viewModel = new FotosListagemViewModel(atendimento);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<AtendimentoFoto>(this, "Mostrar", async (foto) => { await Navigation.PushAsync(new FotosCRUDView(foto, "Foto Atendimento")); });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<AtendimentoFoto>(this, "Mostrar");
        }
    }
}