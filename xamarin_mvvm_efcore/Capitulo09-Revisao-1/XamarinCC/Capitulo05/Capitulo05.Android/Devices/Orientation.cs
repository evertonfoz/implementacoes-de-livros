using Android.Content.PM;
using CasaDoCodigo.Devices.Interfaces;
using Plugin.CurrentActivity;

[assembly: Xamarin.Forms.Dependency(typeof(Capitulo05.Droid.Devices.Orientation))]
namespace Capitulo05.Droid.Devices
{
    public class Orientation : IOrientation
    {
        public void Landscape()
        {
            CrossCurrentActivity.Current.Activity.RequestedOrientation = ScreenOrientation.Landscape;
        }

        public void Portrait()
        {
            CrossCurrentActivity.Current.Activity.RequestedOrientation = ScreenOrientation.Portrait;
        }
    }
}