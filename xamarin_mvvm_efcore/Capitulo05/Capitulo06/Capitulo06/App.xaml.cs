using Capitulo06.Views;
using System;
using System.Globalization;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Capitulo06
{
    public partial class App : Xamarin.Forms.Application
    {
		public App ()
		{
			InitializeComponent();
            //var navigationPage = new Xamarin.Forms.NavigationPage(new Views.Clientes.ListagemView());
            //navigationPage.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetPrefersLargeTitles(true);
            //MainPage = navigationPage;

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");

            MainPage = new MainPageView();

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
