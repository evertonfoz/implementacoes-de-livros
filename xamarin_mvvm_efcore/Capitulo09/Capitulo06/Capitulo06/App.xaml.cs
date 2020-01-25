using Capitulo06.Views;
using Capitulo06.Views.Atendimentos;
using CasaDoCodigo.Devices.Interfaces;
using System;
using System.Globalization;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Capitulo06
{
    public partial class App : Xamarin.Forms.Application
    {
        public static Xamarin.Forms.NavigationPage navigationPage { get; set; }

        public App ()
		{
			InitializeComponent();

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
            int? countStackPages = navigationPage?.Navigation.NavigationStack.Count;
            if (countStackPages  != null && countStackPages > 0 && navigationPage.Navigation.NavigationStack[(int) countStackPages - 1].GetType() == typeof(FotosListagemView))
                DependencyService.Get<IOrientation>().Landscape();
        }
    }
}
