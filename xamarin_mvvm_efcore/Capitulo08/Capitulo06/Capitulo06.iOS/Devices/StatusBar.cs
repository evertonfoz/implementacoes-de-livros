using Capitulo06.iOS.Devices;
using Interfaces.Devices;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(StatusBar))]
namespace Capitulo06.iOS.Devices
{
    public class StatusBar : IStatusBar
    {
        public void Exibir()
        {
            UIApplication.SharedApplication.StatusBarHidden = false;
        }

        public void Ocultar()
        {
            UIApplication.SharedApplication.StatusBarHidden = true;
        }
    }
}