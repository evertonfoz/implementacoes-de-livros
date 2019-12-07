using Modulo1.Dal;
using Modulo1.Modelo;
using Modulo1.RESTServices;
using System;
using Xamarin.Forms;

namespace Modulo1.Pages.Configuracoes
{
    public partial class ConfiguracoesPage : ContentPage
    {
        private ConfiguracaoDAL configuracaoDAL = new ConfiguracaoDAL();

        public ConfiguracoesPage()
        {
            InitializeComponent();
            VerificarIdDispositivo();
        }

        private void VerificarIdDispositivo()
        {
            var cd = configuracaoDAL.GetConfiguracao();
            if (cd != null)
            {
                AtualizarControles(cd);
            }
            else
            {
                DisplayAlert("Erro", "ID não pôde ser recuperado ou não foi ainda criado", "OK");
            }
        }

        private void AtualizarControles(ConfiguracaoDispositivo cd)
        {
            dispositivoId.Text = "ID do dispositivo: " + cd.ConfiguracaoDispositivoId.ToString();
            eMail.Text = cd.EMail;
            BtnObterId.IsVisible = false;
            eMail.IsEnabled = false;
        }

        public async void OnClickedObter(object sender, EventArgs args)
        {
            await DisplayAlert("Aviso", "Este processo depende de sua conexão com a internet. Ele pode ser lento, ou até falhar", "Ok");
            var services = new ConfiguracaoDispositivoREST();
            IsBusy = true;
            try
            {
                var id = await services.GetDispositivoIdAsync(eMail.Text);
                var cd = new ConfiguracaoDispositivo()
                {
                    EMail = eMail.Text,
                    ConfiguracaoDispositivoId = id
                };
                configuracaoDAL.Add(cd);
                AtualizarControles(cd);
                await DisplayAlert("Configuração de Id", "ID para o dispositivo criado/recuperado com sucesso", "Ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
            IsBusy = false;
        }
    }
}
