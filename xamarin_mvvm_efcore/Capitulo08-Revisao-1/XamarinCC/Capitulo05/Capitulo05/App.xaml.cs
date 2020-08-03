using Capitulo05.Views;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Capitulo05
{
    public partial class App : Xamarin.Forms.Application
    {
        public static Xamarin.Forms.NavigationPage navigationPage { get; set; }
        public App()
        {
            InitializeComponent();

            var navigationPage = new Xamarin.Forms.NavigationPage(new Views.Clientes.ListagemView());
            navigationPage.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetPrefersLargeTitles(true);
            //MainPage = navigationPage;
            MainPage = new MainPageView();
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
