using Capitulo06.ViewModels.Atendimentos;
using CasaDoCodigo.Models;
using Interfaces.Fotos;
using Plugin.Media;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace Capitulo06.Views.Atendimentos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FotosCRUDView : ContentPage
	{
        private Color previousBarBackgroundColor;
        private Color previousBarTextColor;
        private FotosCRUDViewModel viewModel;

        public FotosCRUDView ()
		{
			InitializeComponent ();
            this.previousBarBackgroundColor = App.navigationPage.BarBackgroundColor;
            this.previousBarTextColor = App.navigationPage.BarTextColor;
            App.navigationPage.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetPrefersLargeTitles(false);
            App.navigationPage.Popped += OnPoppedCRUDFoto;
        }

        public FotosCRUDView(AtendimentoFoto foto, string title) : this()
        {
            this.Title = title;
            BindingContext = viewModel = new FotosCRUDViewModel(foto);
        }

        public void OnPoppedCRUDFoto(object sender, NavigationEventArgs e)
        {
            if (e.Page.GetType() == typeof(FotosCRUDView))
            {
                if (viewModel.AtendimentoFoto.CaminhoFoto != null && viewModel.AtendimentoFoto.AtendimentoFotoID == null)
                    File.Delete(DependencyService.Get<IFotoLoadMediaPlugin>().GetPathToPhoto(viewModel.AtendimentoFoto.CaminhoFoto));

            }
            App.navigationPage.Popped -= OnPoppedCRUDFoto;
        }

        private async Task<bool> TirarFotoAsync(AtendimentoFoto foto)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Sem Câmera", "A câmera não está disponível.", "OK");
                await Task.FromResult(false);
            }

            string fileName;
            if (foto.CaminhoFoto == null)
            {
                fileName = String.Format("{0:ddMMyyy_HHmm}", DateTime.Now) + ".jpg";
            }
            else
            {
                File.Delete(DependencyService.Get<IFotoLoadMediaPlugin>().GetPathToPhoto(foto.CaminhoFoto));
                fileName = (foto.CaminhoFoto.LastIndexOf("/") > 0) ? foto.CaminhoFoto.Substring(foto.CaminhoFoto.LastIndexOf("/") + 1) : String.Format("{0:ddMMyyy_HHmm}", DateTime.Now) + ".jpg";
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Fotos",
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Full,
                Name = fileName
            });

            if (file == null)
                return await Task.FromResult(false); ;

            fotoCarro.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });

            viewModel.CaminhoFoto = DependencyService.Get<IFotoLoadMediaPlugin>().SetPathToPhoto(file.Path);
            return await Task.FromResult(true);
        }

        private async Task SelecionarFotoDoAlbumAsync(AtendimentoFoto foto)
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

            var imagePath = SaveFotoFromAlbum(foto.CaminhoFoto, file);

            fotoCarro.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });

            viewModel.CaminhoFoto = imagePath;
            return;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.navigationPage.BarBackgroundColor = Color.Gray;
            App.navigationPage.BarTextColor = Color.Black;
            App.navigationPage.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetPrefersLargeTitles(false);

            MessagingCenter.Subscribe<AtendimentoFoto>(this, "Camera", async (foto) => { await TirarFotoAsync(foto); });
            MessagingCenter.Subscribe<AtendimentoFoto>(this, "Album", async (foto) => { await SelecionarFotoDoAlbumAsync(foto); });
            MessagingCenter.Subscribe<string>(this, "InformacaoCRUD", async (msg) => { await DisplayAlert("Informação", msg, "ok"); });
            MessagingCenter.Subscribe<string>(this, "AtualizarFoto", (caminho) => { fotoCarro.Source = caminho; });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            App.navigationPage.BarBackgroundColor = this.previousBarBackgroundColor;
            App.navigationPage.BarTextColor = this.previousBarTextColor;
            App.navigationPage.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetPrefersLargeTitles(true);
            MessagingCenter.Unsubscribe<AtendimentoFoto>(this, "Camera");
            MessagingCenter.Unsubscribe<AtendimentoFoto>(this, "Album");
            MessagingCenter.Unsubscribe<string>(this, "InformacaoCRUD");
            MessagingCenter.Unsubscribe<string>(this, "AtualizarFoto");
        }

        private double width;
        private double height;

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width != this.width || height != this.height)
            {
                this.width = width;
                this.height = height;
                fotoCarro.WidthRequest = width;
                fotoCarro.HeightRequest = (width < height) ? height / 2 : height / 4;
            }
        }

        public string SaveFotoFromAlbum(string caminhoFoto, Plugin.Media.Abstractions.MediaFile file)
        {
            string nomeArquivo;
            if (string.IsNullOrEmpty(caminhoFoto))
            {
                nomeArquivo = String.Format("{0:ddMMyyy_HHmm}", DateTime.Now) + ".jpg";
            }
            else
            {
                File.Delete(DependencyService.Get<IFotoLoadMediaPlugin>().GetPathToPhoto(caminhoFoto));
                nomeArquivo = (caminhoFoto.LastIndexOf("/") > 0) ? caminhoFoto.Substring(caminhoFoto.LastIndexOf("/") + 1) : caminhoFoto;
            }

            var caminhoFotos = DependencyService.Get<IFotoLoadMediaPlugin>().GetDevicePathToPhoto();
            if (!Directory.Exists(caminhoFotos))
                Directory.CreateDirectory(caminhoFotos);

            string caminhoCompleto = Path.Combine(caminhoFotos, nomeArquivo);

            using (FileStream fileStream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                file.GetStream().CopyTo(fileStream);
            }
            return DependencyService.Get<IFotoLoadMediaPlugin>().SetPathToPhoto(caminhoCompleto);
        }
    }
}