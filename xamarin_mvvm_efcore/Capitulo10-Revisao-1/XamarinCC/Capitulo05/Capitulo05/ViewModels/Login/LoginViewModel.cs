using Capitulo05.Services;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Capitulo05.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string nome;
        private string senha;
        private bool autenticando;
        public ICommand LoginCommand { get; set; }
        public LoginViewModel()
        {
            RegistrarCommands();
        }
        private async Task<string> RealizarLoginAsync(string nome, string senha)
        {
            var json = JsonConvert.SerializeObject(new { nome = nome, senha = senha });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                using (var client = ServicesPrepare.GetHttpClient())
                {
                    HttpResponseMessage response = await client.PostAsync("autenticacao/login", content);
                    if (response.IsSuccessStatusCode)
                        return (await response.Content.ReadAsStringAsync());
                    return response.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private void RegistrarCommands()
        {
            LoginCommand = new Command(async () => {
                this.Autenticando = true;
                MessagingCenter.Send<string>(await RealizarLoginAsync(nome, senha), "Informacao");
                this.Autenticando = false;
            },
            () => { return !string.IsNullOrEmpty(this.Nome) && !string.IsNullOrEmpty(this.Senha); });
        }
        public string Nome
        {
            get { return this.nome; }
            set
            {
                this.nome = value;
                ((Command)LoginCommand).ChangeCanExecute();
                OnPropertyChanged();
            }
        }

        public string Senha
        {
            get { return this.senha; }
            set
            {
                this.senha = value;
                ((Command)LoginCommand).ChangeCanExecute();
                OnPropertyChanged();
            }
        }
        public bool Autenticando
        {
            get { return this.autenticando; }
            set
            {
                this.autenticando = value;
                OnPropertyChanged();
            }
        }
    }
}
