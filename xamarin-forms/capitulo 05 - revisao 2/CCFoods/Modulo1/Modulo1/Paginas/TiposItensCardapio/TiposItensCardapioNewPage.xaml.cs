using Modulo1.Dal;
using Modulo1.Modelo;
using Plugin.Media;
using System;
using System.IO;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Modulo1.Paginas.TiposItensCardapio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TiposItensCardapioNewPage : ContentPage
    {
        private TipoItemCardapioDAL dalTiposItensCardapio = TipoItemCardapioDAL.GetInstance();
        private string caminhoArquivo;

        public TiposItensCardapioNewPage()
        {
            InitializeComponent();
            PreparaParaNovoTipoItemCardapio();
            RegistraClickBotaoCamera(idtipoitemcardapio.Text.Trim());
            RegistraClickBotaoAlbum(idtipoitemcardapio.Text.Trim());
        }

        private void PreparaParaNovoTipoItemCardapio()
        {
            var novoId = dalTiposItensCardapio.GetAll().Max(x => x.Id) + 1;
            idtipoitemcardapio.Text = novoId.ToString().Trim();
            nome.Text = string.Empty;
            fototipoitemcardapio.Source = null;
        }

        private void RegistraClickBotaoCamera(string idparafoto)
        {
            // Criação do método anônimo para captura do evento click do botão
            BtnCamera.Clicked += async (sender, args) =>
            {
                // Inicialização do plugin de interação com a câmera e álbum
                await CrossMedia.Current.Initialize();

                // Verificação de disponibilização da câmera e se é possível tirar foto
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("Não existe câmera", "A câmera não está disponível.", "OK");
                    return;
                }

                /* Método que habilita a câmera, informando a pasta onde a foto deverá
                   ser armazenada, o nome a ser dado ao arquivo e se é ou não para 
                   armazenar a foto também no álbum */
                var file = await CrossMedia.Current.TakePhotoAsync(
                    new Plugin.Media.Abstractions.StoreCameraMediaOptions
                    {
                        Directory = "Fotos",
                        Name = "tipoitem_" + idparafoto + ".jpg",
                        SaveToAlbum = true
                    });

                // Caso o usuário não tenha tirado a foto, clicando no botão cancelar 
                if (file == null)
                    return;

                // Armazena o caminho da foto para ser utilizado na gravação do item
                caminhoArquivo = file.Path;

                // Recupera a foto e a atribui para o controle visual
                fototipoitemcardapio.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            };
        }

        private void RegistraClickBotaoAlbum(string idparafoto)
        {
            BtnAlbum.Clicked += async (sender, args) =>
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Álbum não suportado", "Não existe permissão para acessar o álbum de fotos", "OK");
                    return;
                }

                // Executa a seleção de uma foto do álbum
                var file = await CrossMedia.Current.PickPhotoAsync();

                if (file == null)
                    return;

                // Nomeia o arquivo com o caminho para escrita
                string nomeArquivo = "tipoitem_" + idparafoto + ".jpg";

                caminhoArquivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Fotos");

                if (!Directory.Exists(caminhoArquivo))
                    Directory.CreateDirectory(caminhoArquivo);

                caminhoArquivo = Path.Combine(caminhoArquivo, nomeArquivo);

                // Grava o arquivo no dispositivo
                using (FileStream fileStream = new FileStream(caminhoArquivo, FileMode.Create))
                {
                    file.GetStream().CopyTo(fileStream);
                }

                fototipoitemcardapio.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            };
        }

        public void BtnGravarClick(object sender, EventArgs e)
        {
            if (nome.Text.Trim() == string.Empty)
            {
                this.DisplayAlert("Erro",
                    "Você precisa informar o nome para o novo tipo de item do cardápio.",
                    "Ok");
            }
            else
            {
                dalTiposItensCardapio.Add(new TipoItemCardapio()
                {
                    Id = Convert.ToUInt32(idtipoitemcardapio.Text),
                    Nome = nome.Text,
                    CaminhoArquivoFoto = caminhoArquivo
                });
                PreparaParaNovoTipoItemCardapio();
            }
        }
    }
}