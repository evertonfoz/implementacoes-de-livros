using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Modulo1.Pages.Clientes
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClientesMapPage : ContentPage
    {
        private string endereco;

        public ClientesMapPage(string endereco)
        {
            InitializeComponent();
            this.endereco = endereco;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await DisplayAlert("Need location", "Gunna need that location", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Location))
                        status = results[Permission.Location];
                }

                if (status == PermissionStatus.Granted)
                {
                    await PutAddressInTheMap();
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Location Denied", ex.Message, "OK");
            }

        }

        private async Task PutAddressInTheMap()
        {
            var geoCoder = new Geocoder();
            var position = await geoCoder.GetPositionsForAddressAsync(endereco);
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(position.First(), Distance.FromKilometers(0.3f)));

            var pin = new Pin()
            {
                Position = position.First(),
                Label = "Residência cliente",
                Address = endereco
            };

            MyMap.Pins.Add(pin);
        }
    }
}