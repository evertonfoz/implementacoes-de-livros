using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Capitulo04
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");

            var navigationPage = new Xamarin.Forms.NavigationPage(new Views.Servicos.ListagemView());
            navigationPage.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetPrefersLargeTitles(true);

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
