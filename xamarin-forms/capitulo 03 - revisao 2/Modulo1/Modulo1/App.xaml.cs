using System;
using Modulo1.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Modulo1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MenuPage());
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
