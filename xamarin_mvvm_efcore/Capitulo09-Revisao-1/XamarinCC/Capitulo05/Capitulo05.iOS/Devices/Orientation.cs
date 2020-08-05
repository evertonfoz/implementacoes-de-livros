using Capitulo05.iOS.Devices;
using CasaDoCodigo.Devices.Interfaces;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(Orientation))]
namespace Capitulo05.iOS.Devices
{
    public class Orientation : IOrientation
    {
        public void Landscape()
        {
            UIDevice.CurrentDevice.SetValueForKey(new NSNumber((int)UIInterfaceOrientation.LandscapeLeft), new NSString("orientation"));
        }

        public void Portrait()
        {
            UIDevice.CurrentDevice.SetValueForKey(new NSNumber((int)UIInterfaceOrientation.Portrait), new NSString("orientation"));
        }
    }
}