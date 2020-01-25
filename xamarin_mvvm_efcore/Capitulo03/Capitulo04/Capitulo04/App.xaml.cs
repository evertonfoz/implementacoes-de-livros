using Capitulo04.Views;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Capitulo04
{
	public partial class App : Xamarin.Forms.Application
    {
		public App ()
		{
			InitializeComponent();
            //var page = new ContentPageView();
            //page.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            //page.BackgroundColor = Color.Red;
            //MainPage = page;
            //var navigationPage = new Xamarin.Forms.NavigationPage(new NavigationPageClientesView());
            //navigationPage.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetPrefersLargeTitles(true);
            //navigationPage.BarBackgroundColor = Color.Red;
            //navigationPage.BarTextColor = Color.White;
            //MainPage = navigationPage;
            MainPage = new TabbedPageView();
            //MainPage = new MasterDetailPageView();
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
