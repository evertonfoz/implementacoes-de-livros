using Capitulo06.ViewModels.Servicos;
using CasaDoCodigo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Capitulo06.Views.Servicos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CRUDView : ContentPage
	{
        private CRUDViewModel crudViewModel;

        public CRUDView ()
		{
			InitializeComponent ();
        }

        public CRUDView(Servico servico, string title) : this()
        {
            this.crudViewModel = new CRUDViewModel(servico);
            this.BindingContext = this.crudViewModel;
            this.Title = title;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<string>(this, "InformacaoCRUD",
                            async (msg) =>
                            {
                                await DisplayAlert("Informação", msg, "ok");
                            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "InformacaoCRUD");
        }
    }
}