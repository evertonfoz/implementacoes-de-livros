using Capitulo06.Converters.NitoMvvmAsync;
using Capitulo06.Services;
using Interfaces.Fotos;
using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Capitulo06.Converters
{
    public class ImagemPecaConverterAsync : IValueConverter
    {
        private PecaService service = new PecaService();
        private ImageSource defaultImageSource;

        public ImagemPecaConverterAsync()
        {
            using (FileStream fileStream = new FileStream("disconnected.png", FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[fileStream.Length];
                fileStream.Read(bytes, 0, bytes.Length);
                defaultImageSource = ImageSource.FromStream(() => new MemoryStream(bytes));
            }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string caminho = value as string;
            string pecaID = (parameter as Label).Text;
            if (!string.IsNullOrEmpty(caminho))
                return DependencyService.Get<IFotoLoadMediaPlugin>().GetPathToPhoto(caminho);
            else
            {
                var task = Task.Run(async () => {
                    var bytes = await service.GetImagemById(new Guid(pecaID));
                    return bytes == null ? defaultImageSource : ImageSource.FromStream(() => new MemoryStream(bytes));
                });
                //var task = Task.Run(async () =>
                //{
                //    //var imagemBytes = await service.GetImagemById(new Guid(pecaID));
                //    return defaultImageSource;
                //    //return imagemBytes == null ? defaultImageSource : ImageSource.FromStream(() => new MemoryStream(imagemBytes));
                //    //return imagemBytes == null ? "consultar.png" : ImageSource.FromStream(() => new MemoryStream(imagemBytes));
                //});
                return new NotifyTask<ImageSource>(task, defaultImageSource);
                //return new NotifyTask<ImageSource>(task, defaultImageSource);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
