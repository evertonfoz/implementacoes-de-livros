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
                        Name = "tipoitem_" + idparafoto + ".jpg",
                        SaveToAlbum = true
                    });

                if (file == null)
                    return;

                caminhoArquivo = file.Path;

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
                    await DisplayAlert("Álbum não suportado", 
                        "Não existe permissão para acessar o álbum de fotos", 
                        "OK");
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