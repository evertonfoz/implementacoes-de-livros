using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Capitulo05
{
	public partial class App : Xamarin.Forms.Application
    {
		public App ()
		{
			InitializeComponent();

            var navigationPage = new Xamarin.Forms.NavigationPage(new Views.Servicos.ListagemView());
            navigationPage.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetPrefersLargeTitles(true);

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");

            MainPage = navigationPage;
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
