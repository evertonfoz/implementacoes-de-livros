using Modulo1.Dal;
using Modulo1.Modelo;
using Plugin.Media;
using System;
using System.Linq;
using Xamarin.Forms;
using PCLStorage;

namespace Modulo1.Pages.TiposItensCardapio
{
    public partial class TiposItensCardapioNewPage : ContentPage
    {
        private TipoItemCardapioDAL dalTiposItensCardapio = TipoItemCardapioDAL.GetInstance();
        private string caminhoArquivo;

        public TiposItensCardapioNewPage()
        {
            InitializeComponent();
            PreparaParaNovoTipoItemCardapio();
			RegistraClickBotaoCamera(idtipoitemcardapio.Text.Trim());
			RegistraClickBotaoAlbum();
		}

		private void RegistraClickBotaoAlbum()
		{
            // Criação do método anônimo para captura do evento click do botão
            BtnAlbum.Clicked += async (sender, args) =>
			{
                // Inicialização do plugin de interação com a câmera e álbum
                await CrossMedia.Current.Initialize();

                // Verificação de disponibilização do álbum
                if (!CrossMedia.Current.IsPickPhotoSupported)
				{
					DisplayAlert("Álbum não suportado", "Não existe permissão para acessar o álbum de fotos", "OK");
					return;
				}

                // Método que habilita o álbum e permite a seleção de uma foto
                var file = await CrossMedia.Current.PickPhotoAsync();

                // Caso o usuário não tenha selecionado uma foto, clicando no botão cancelar
                if (file == null)
					return;
				
                /* Nas instruções abaixo é feito uso dos components PCLStorage
                   e PCLSpecialFolder */

                // Recupera o arquivo com base no caminho da foto selecionada
				var getArquivoPCL = FileSystem.Current.GetFileFromPathAsync(file.Path);

                // Recupera o caminho raiz da aplicação no dispositivo
				var rootFolder = FileSystem.Current.LocalStorage;

                /* Caso a pasta Fotos não exista, ela é criada para 
                   armazenamento da foto selecionada */
				var folderFoto = await rootFolder.CreateFolderAsync("Fotos", CreationCollisionOption.OpenIfExists);

                // Cria o arquivo referente a foto selecionada
				var setArquivoPCL = folderFoto.CreateFileAsync(getArquivoPCL.Result.Name, CreationCollisionOption.ReplaceExisting);

                // Faz a leitura do arquivo em bytes, para que ele possa ser escrito
				var arquivoLido = getArquivoPCL.Result.ReadAllBytesAsync();

                // Escreve o arquivo fisicamente
				var arquivoEscrito = setArquivoPCL.Result.WriteAllBytesAsync(arquivoLido.Result);

                // Guarda o caminho do arquivo para ser utilizado na gravação do item criado
				caminhoArquivo = setArquivoPCL.Result.Path;

                // Recupera o arquivo selecionado e o atribui ao controle no formulário
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
            // Criação do método anônimo para captura do evento click do botão
            BtnCamera.Clicked += async (sender, args) =>
            {
                // Inicialização do plugin de interação com a câmera
                await CrossMedia.Current.Initialize();

                // Verificação de disponibilização da câmera e se é possível tirar foto
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    DisplayAlert("Não existe câmera", "A câmera não está disponível.", "OK");
                    return;
                }

                /* Método que habilita a câmera, informando a pasta onde a foto deverá
                   ser armazenada, o nome a ser dado ao arquivo e se é ou não para 
                   armazenar a foto também no álbum */
                var file = await CrossMedia.Current.TakePhotoAsync(
                    new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
					Directory = FileSystem.Current.LocalStorage.Name,
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

        private void PreparaParaNovoTipoItemCardapio()
        {
            var novoId = dalTiposItensCardapio.GetAll().Max(x => x.Id) + 1;
            idtipoitemcardapio.Text = novoId.ToString().Trim();
            nome.Text = string.Empty;
			fototipoitemcardapio.Source = null;
        }
    }
}
