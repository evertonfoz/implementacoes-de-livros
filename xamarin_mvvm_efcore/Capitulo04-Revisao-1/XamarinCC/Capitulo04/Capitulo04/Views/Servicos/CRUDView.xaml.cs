using Capitulo04.Models;
using Capitulo04.ViewModels.Servicos;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Capitulo04.Views.Servicos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CRUDView : ContentPage
    {
        private CRUDViewModel crudViewModel;
        public CRUDView()
        {
            InitializeComponent();
        }

        public CRUDView(Servico servico, ObservableCollection<Servico> servicos) : this()
        {
            this.crudViewModel = new CRUDViewModel(servico, servicos);
            this.BindingContext = this.crudViewModel;
            this.Title = "Consulta Serviço";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<string>(this, "InformacaoCRUD", async (msg) => { await DisplayAlert("Informação", msg, "ok"); });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "InformacaoCRUD");
        }
    }
}