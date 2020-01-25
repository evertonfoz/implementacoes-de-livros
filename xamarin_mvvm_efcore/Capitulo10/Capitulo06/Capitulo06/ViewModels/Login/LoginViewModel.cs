using Capitulo06.Services;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Capitulo06.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string nome;
        private string senha;

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

        //private async Task<Boolean> RealizarLogin(string nome, string senha)
        //{
        //    var json = JsonConvert.SerializeObject(new { nome = nome, senha = senha });
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");

        //    using (var client = ServicesPrepare.GetHttpClient())
        //    {
        //        try
        //        {
        //            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
        //                throw new Exception("Sem acesso à internet");

        //            HttpResponseMessage response = await client.PostAsync("autenticacao/login", content);
        //            if (response.IsSuccessStatusCode)
        //                return JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
        //            throw new Exception(response.StatusCode.ToString());
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //    }
        //}

        private bool autenticando;

        public bool Autenticando
        {
            get { return this.autenticando; }
            set
            {
                this.autenticando = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; set; }

        private void RegistrarCommands()
        {
            LoginCommand = new Command(async () => {
                this.Autenticando = true;
                MessagingCenter.Send<string>(await RealizarLoginAsync(nome, senha), "Informacao");
                this.Autenticando = false;
            },
            () => { return !string.IsNullOrEmpty(this.Nome) && !string.IsNullOrEmpty(this.Senha); });
            //LoginCommand = new Command(async () =>
            //{
            //    this.Autenticando = true;
            //    string resultadoLogin = "False";
            //    try
            //    {
            //        if (await RealizarLogin(nome, senha))
            //            resultadoLogin = "True";
            //    }
            //    catch (Exception ex)
            //    {
            //        resultadoLogin = ex.Message;
            //    }
            //    finally
            //    {
            //        autenticando = false;
            //    }
            //    this.Autenticando = false;
            //    MessagingCenter.Send<string>(resultadoLogin, "Informacao");
            //}, () =>
            //{
            //    return !string.IsNullOrEmpty(this.Nome) && !string.IsNullOrEmpty(this.Senha);
            //});
        }

        public LoginViewModel()
        {
            RegistrarCommands();
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
    }
}
