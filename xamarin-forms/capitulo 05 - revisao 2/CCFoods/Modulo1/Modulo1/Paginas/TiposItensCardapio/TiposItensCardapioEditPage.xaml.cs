using Modulo1.Dal;
using Modulo1.Modelo;
using Plugin.Media;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Modulo1.Paginas.TiposItensCardapio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TiposItensCardapioEditPage : ContentPage
    {
        private TipoItemCardapio tipoItemCardapio;
        private string caminhoArquivo;
        private TipoItemCardapioDAL dalTiposItensCardapio = TipoItemCardapioDAL.GetInstance();

        public TiposItensCardapioEditPage(TipoItemCardapio tipoItemCardapio)
        {
            InitializeComponent();
            PopularFormulario(tipoItemCardapio);
            RegistraClickBotaoCamera(idtipoitemcardapio.Text.Trim());
            RegistraClickBotaoAlbum(idtipoitemcardapio.Text.Trim());
        }

        private void PopularFormulario(TipoItemCardapio tipoItemCardapio)
        {
            this.tipoItemCardapio = tipoItemCardapio;
            idtipoitemcardapio.Text = tipoItemCardapio.Id.ToString();
            nome.Text = tipoItemCardapio.Nome;
            caminhoArquivo = tipoItemCardapio.CaminhoArquivoFoto;
            fototipoitemcardapio.Source = ImageSource.FromFile(tipoItemCardapio.CaminhoArquivoFoto);
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

                var file = await CrossMedia.Current.PickPhotoAsync();

                if (file == null)
                    return;

                string nomeArquivo = "tipoitem_" + idparafoto + ".jpg";
                caminhoArquivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Fotos");

                if (!Directory.Exists(caminhoArquivo))
                    Directory.CreateDirectory(caminhoArquivo);

                caminhoArquivo = Path.Combine(caminhoArquivo, nomeArquivo);

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

        private void RegistraClickBotaoCamera(string idparafoto)
        {
            BtnCamera.Clicked += async (sender, args) =>
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("Não existe câmera", "A câmera não está disponível.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Fotos",
                    Name = "tipoitem_" + idparafoto.Trim() + ".jpg"
                });

                if (file == null)
                    return;

                fototipoitemcardapio.Source = ImageSource.FromFile(file.Path);
                caminhoArquivo = file.Path;
            };
        }

        public async void BtnGravarClick(object sender, EventArgs e)
        {
            if (nome.Text.Trim() == string.Empty)
            {
                await this.DisplayAlert("Erro", "Você precisa informar o nome para o novo tipo de item do cardápio.", "Ok");
            }
            else
            {
                this.tipoItemCardapio.Nome = nome.Text;
                this.tipoItemCardapio.CaminhoArquivoFoto = caminhoArquivo;

                dalTiposItensCardapio.Update(this.tipoItemCardapio);
                await Navigation.PopModalAsync();
            }
        }
    }
}