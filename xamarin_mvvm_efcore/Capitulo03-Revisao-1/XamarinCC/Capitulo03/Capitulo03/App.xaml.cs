using Capitulo03.Views;
using System.Drawing;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Capitulo03
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();

            //            var page = new NavigationPageClientesViews();
            //            page.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            //            MainPage = new Xamarin.Forms.NavigationPage(new NavigationPageClientesView()); ;

            var navigationPage = new Xamarin.Forms.NavigationPage(new MasterDetailPageView());
            navigationPage.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetPrefersLargeTitles(true);
            navigationPage.BarBackgroundColor = Color.Red;
            navigationPage.BarTextColor = Color.White;

            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
