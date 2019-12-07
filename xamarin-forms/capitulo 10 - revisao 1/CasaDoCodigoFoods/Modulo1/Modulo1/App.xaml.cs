using Modulo1.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Modulo1
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjQ1MjlAMzEzNjJlMzQyZTMwU1M4RCtvSld2b3ljbnRUZmJtTDFtL1E1MlVDL2tlMVRXU2c5RTF4V0NKcz0=");

            InitializeComponent();

            MainPage = new NavigationPage(new MenuPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
