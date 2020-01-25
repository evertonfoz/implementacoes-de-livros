using Android.Views;
using Capitulo06.Droid.Devices;
using Interfaces.Devices;
using Plugin.CurrentActivity;

[assembly: Xamarin.Forms.Dependency(typeof(StatusBar))]
namespace Capitulo06.Droid.Devices
{
    public class StatusBar : IStatusBar
    {
        WindowManagerFlags originalFlags;

        public void Exibir()
        {
            var activity = CrossCurrentActivity.Current.Activity;
            var attrs = activity.Window.Attributes;
            attrs.Flags = originalFlags;
            activity.Window.Attributes = attrs;
        }

        public void Ocultar()
        {
            var activity = CrossCurrentActivity.Current.Activity;
            var attrs = activity.Window.Attributes;
            originalFlags = attrs.Flags;
            attrs.Flags |= Android.Views.WindowManagerFlags.Fullscreen;
            activity.Window.Attributes = attrs;
        }
    }
}