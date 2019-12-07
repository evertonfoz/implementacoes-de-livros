using Modulo1.Dal;
using Modulo1.RESTServices;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Modulo1.Pages.Garcons
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GarconsPage : ContentPage
	{
        private GarcomDAL garcomDAL = new GarcomDAL();
        private GarcomREST services = new GarcomREST();

        public GarconsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvGarcons.ItemsSource = garcomDAL.GetAll();
        }

        private async void lvGarconsRefreshing(object sender, EventArgs e)
        {
            await UpdateToServer();
            await UpdateDispositivo();
            lvGarcons.ItemsSource = garcomDAL.GetAll();
            lvGarcons.IsRefreshing = false;
        }

        private async Task UpdateToServer()
        {
            await services.UpdateGarconsToServerAsync(garcomDAL.GetAllInseridoDispositivo());
        }

        private async Task UpdateDispositivo()
        {
            var garconsServer = await services.GetGarconsAsync();
            var garconsDispositivo = garcomDAL.GetAll();
            var garconsAtualizado = garconsServer.Except(garconsDispositivo);
            foreach (var garcomNovo in garconsAtualizado)
            {
                garcomDAL.Add(garcomNovo);
            }
        }

        private async void BtnNovoItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GarconsNewPage());
        }
    }
}