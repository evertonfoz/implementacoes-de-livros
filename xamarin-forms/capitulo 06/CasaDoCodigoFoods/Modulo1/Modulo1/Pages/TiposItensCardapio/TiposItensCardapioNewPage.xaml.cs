using Modulo1.Dal;
using Modulo1.Modelo;
using Plugin.Media;
using System;
using System.Linq;
using Xamarin.Forms;
using PCLStorage;
using System.IO;

namespace Modulo1.Pages.TiposItensCardapio
{
    public partial class TiposItensCardapioNewPage : ContentPage
    {
        private TipoItemCardapioDAL dalTiposItensCardapio = new TipoItemCardapioDAL();
        private byte[] bytesFoto;

        public TiposItensCardapioNewPage()
        {
            InitializeComponent();
            PreparaParaNovoTipoItemCardapio();
			RegistraClickBotaoCamera(idtipoitemcardapio.Text.Trim());
			RegistraClickBotaoAlbum();
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

                if (file == null)
					return;

                var stream = file.GetStream();
                var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                fototipoitemcardapio.Source = ImageSource.FromStream(() =>
                {
                    var s = file.GetStream();
                    file.Dispose();
                    return s;
                });
                bytesFoto = memoryStream.ToArray();
            };
		}

        private void RegistraClickBotaoCamera(string idparafoto)
        {
            BtnCamera.Clicked += async (sender, args) =>
            {
                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    DisplayAlert("Não existe câmera", "A câmera não está disponível.", "OK");
                    return;
                }
                var file = await CrossMedia.Current.TakePhotoAsync(
                    new Plugin.Media.Abstractions.StoreCameraMediaOptions
                    {
                        //Directory = FileSystem.Current.LocalStorage.Name,
                        Name = "tipoitem_" + idparafoto + ".jpg"
                    });

                if (file == null)
                    return;

                var stream = file.GetStream();
                var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                fototipoitemcardapio.Source = ImageSource.FromStream(() =>
                {
                    var s = file.GetStream();
                    file.Dispose();
                    return s;
                });
                bytesFoto = memoryStream.ToArray();
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
					Nome = nome.Text,
                    Foto = bytesFoto
                });
                PreparaParaNovoTipoItemCardapio();
            }
        }

        private void PreparaParaNovoTipoItemCardapio()
        {
            var novoId = dalTiposItensCardapio.GetAll().Max(x => x.TipoItemCardapioId) + 1;
            idtipoitemcardapio.Text = novoId.ToString().Trim();
            nome.Text = string.Empty;
			fototipoitemcardapio.Source = null;
        }
    }
}
