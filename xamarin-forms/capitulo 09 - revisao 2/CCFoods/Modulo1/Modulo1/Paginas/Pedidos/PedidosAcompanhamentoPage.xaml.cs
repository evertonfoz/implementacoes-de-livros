using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Modulo1.Paginas.Pedidos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PedidosAcompanhamentoPage : ContentPage
    {
        private IGeolocator locator;

        public PedidosAcompanhamentoPage()
        {
            InitializeComponent();
            locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            locator.PositionChanged += OnPositionChanged;
        }

        private void OnPositionChanged(object obj, PositionEventArgs e)
        {
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Xamarin.Forms.Maps.Position(e.Position.Latitude, e.Position.Longitude),
                Distance.FromKilometers(0.3f)));

            var localPin = new Pin()
            {
                Position = new Xamarin.Forms.Maps.Position(
                    e.Position.Latitude, e.Position.Longitude),
                Label = "Entregador/" + e.Position.Timestamp.ToLocalTime().TimeOfDay
            };

            MyMap.Pins.Add(localPin);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            locator.StartListeningAsync(TimeSpan.FromMilliseconds(60000), 50);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            locator.StopListeningAsync();
        }
    }
}