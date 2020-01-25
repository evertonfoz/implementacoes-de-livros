using Android.App;
using Android.Content.PM;
using CasaDoCodigo.Devices.Interfaces;
using Plugin.CurrentActivity;
using System.Diagnostics;

[assembly: Xamarin.Forms.Dependency(typeof(Capitulo06.Droid.Devices.Orientation))]
namespace Capitulo06.Droid.Devices
{
    public class Orientation : IOrientation
    {
        public void Landscape()
        {
            CrossCurrentActivity.Current.Activity.RequestedOrientation = ScreenOrientation.Landscape;
        }

        public void Portrait()
        {
            Debug.WriteLine("=====>" + CrossCurrentActivity.Current.Activity.RequestedOrientation);
            Debug.WriteLine("=====>" + CrossCurrentActivity.Current.Activity.Title);
            CrossCurrentActivity.Current.Activity.RequestedOrientation = ScreenOrientation.Portrait;
        }
    }
}