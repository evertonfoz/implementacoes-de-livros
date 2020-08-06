using Capitulo05.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Capitulo05.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        private LoginViewModel loginViewModel;
        public LoginView()
        {
            InitializeComponent();
            this.loginViewModel = new LoginViewModel();
            this.BindingContext = this.loginViewModel;
        }
        private async Task ValidarLoginAsync(bool validacaoLogin)
        {
            if (validacaoLogin)
                App.Current.MainPage = new Capitulo05.Views.MainPageView();
            else
                await DisplayAlert("Informação", "Usuário e/ou senha incorretos", "ok");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<string>(this, "Informacao", async (resultadoLogin) => { await ValidarLoginAsync(resultadoLogin); });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "Informacao");
        }
        private async Task ValidarLoginAsync(string validacaoLogin)
        {
            if (validacaoLogin.ToLower().Equals("true"))
                App.Current.MainPage = new Capitulo05.Views.MainPageView();
            else if (validacaoLogin.ToLower().Equals("false"))
                await DisplayAlert("Informação", "Usuário e/ou senha incorretos", "ok");
            else
                await DisplayAlert("Informação", validacaoLogin, "ok");
        }
    }
}