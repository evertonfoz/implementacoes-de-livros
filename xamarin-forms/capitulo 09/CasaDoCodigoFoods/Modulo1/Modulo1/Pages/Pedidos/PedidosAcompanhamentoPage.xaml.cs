using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Modulo1.Pages.Pedidos
{
    public partial class PedidosAcompanhamentoPage : ContentPage
    {
        private IGeolocator locator;

        public PedidosAcompanhamentoPage()
        {
            InitializeComponent();
            locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            locator.PositionChanged += OnPositionChanged;
            locator.StartListeningAsync(60000, 50);
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
        }
    }
}
