using Capitulo06.ViewModels.Clientes;
using CasaDoCodigo.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Capitulo06.Views.Clientes
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CRUDView : ContentPage
	{
        private CRUDViewModel crudViewModel;

        public CRUDView()
        {
            InitializeComponent();
        }

        public CRUDView(Cliente cliente, string title) : this()
        {
            this.crudViewModel = new CRUDViewModel(cliente);
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