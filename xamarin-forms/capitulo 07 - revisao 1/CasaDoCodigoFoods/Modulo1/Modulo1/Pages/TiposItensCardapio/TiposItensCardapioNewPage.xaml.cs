using Modulo1.Dal;
using Modulo1.Modelo;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Modulo1.Pages.TiposItensCardapio
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TiposItensCardapioNewPage : ContentPage
	{
        private byte[] bytesFoto;
        private TipoItemCardapioDAL dalTiposItensCardapio = new TipoItemCardapioDAL();

        public TiposItensCardapioNewPage()
        {
            InitializeComponent();
            PreparaParaNovoTipoItemCardapio();
            RegistraClickBotaoCamera();
            RegistraClickBotaoAlbum();
        }

        private void PreparaParaNovoTipoItemCardapio()
        {
            nome.Text = string.Empty;
            fototipoitemcardapio.Source = null;
        }

        private void RegistraClickBotaoCamera()
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
                        Directory = "Fotos",
                        Name = "tipoitem.jpg",
                        SaveToAlbum = true
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

        private void RegistraClickBotaoAlbum()
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

    }
}