using Capitulo05.ViewModels.Atendimentos;
using CasaDoCodigo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Capitulo05.Views.Atendimentos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FotosListagemView : ContentPage
    {
        private FotosListagemViewModel viewModel;
        public FotosListagemView(Atendimento atendimento)
        {
            InitializeComponent();
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