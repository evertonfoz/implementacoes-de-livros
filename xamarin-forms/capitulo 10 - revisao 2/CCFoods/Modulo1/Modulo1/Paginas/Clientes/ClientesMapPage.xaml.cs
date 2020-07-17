using System;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Modulo1.Paginas.Clientes
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
            await PutAddressInTheMap();
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