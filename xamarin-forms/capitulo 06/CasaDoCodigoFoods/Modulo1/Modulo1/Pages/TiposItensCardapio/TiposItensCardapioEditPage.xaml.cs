using Modulo1.Dal;
using Modulo1.Modelo;
using PCLStorage;
using Plugin.Media;
using System;

using Xamarin.Forms;

namespace Modulo1.Pages.TiposItensCardapio
{
    public partial class TiposItensCardapioEditPage : ContentPage
    {
        private TipoItemCardapio tipoItemCardapio;
        private string caminhoArquivo;
        private TipoItemCardapioDAL dalTiposItensCardapio = new TipoItemCardapioDAL();

        public TiposItensCardapioEditPage(TipoItemCardapio tipoItemCardapio)
        {
            InitializeComponent();
            PopularFormulario(tipoItemCardapio);
            RegistraClickBotaoCamera(idtipoitemcardapio.Text.Trim());
            RegistraClickBotaoAlbum();
        }

        private void PopularFormulario(TipoItemCardapio tipoItemCardapio)
        {
            this.tipoItemCardapio = tipoItemCardapio;
            idtipoitemcardapio.Text = tipoItemCardapio.TipoItemCardapioId.ToString();
            nome.Text = tipoItemCardapio.Nome;
            //caminhoArquivo = tipoItemCardapio.CaminhoArquivoFoto;
            //fototipoitemcardapio.Source = ImageSource.FromFile(tipoItemCardapio.CaminhoArquivoFoto);
        }

        private void RegistraClickBotaoAlbum()
        {
            BtnAlbum.Clicked += async (sender, args) =>
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    DisplayAlert("Álbum não suportado", "Não existe permissão para acessar o álbum de fotos", "OK");
                    return;
                }

                var file = await CrossMedia.Current.PickPhotoAsync();
                //var getArquivoPCL = FileSystem.Current.GetFileFromPathAsync(file.Path);
                //var rootFolder = FileSystem.Current.LocalStorage;
                //var folderFoto = await rootFolder.CreateFolderAsync("Fotos", CreationCollisionOption.OpenIfExists);
                //var setArquivoPCL = folderFoto.CreateFileAsync(getArquivoPCL.Result.Name, CreationCollisionOption.ReplaceExisting);
                //var arquivoLido = getArquivoPCL.Result.ReadAllBytesAsync();
                //var arquivoEscrito = setArquivoPCL.Result.WriteAllBytesAsync(arquivoLido.Result);
                //caminhoArquivo = setArquivoPCL.Result.Path;

                if (file == null)
                    return;

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

                var file = await CrossMedia.Current.TakePhotoAsync(
                    new Plugin.Media.Abstractions.StoreCameraMediaOptions
                    {
                        //Directory = FileSystem.Current.LocalStorage.Name,
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
                this.DisplayAlert("Erro",
                    "Você precisa informar o nome para o novo tipo de item do cardápio.",
                    "Ok");
            }
            else
            {
                this.tipoItemCardapio.Nome = nome.Text;
                //this.tipoItemCardapio.CaminhoArquivoFoto = caminhoArquivo;

                dalTiposItensCardapio.Update(this.tipoItemCardapio);
                await Navigation.PopModalAsync();
            }
        }
    }
}
