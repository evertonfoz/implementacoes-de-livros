using Interfaces.Fotos;
using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace Capitulo05.Converters
{
    public class ImagemPecaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string caminho = ((Label)parameter).Text;
            byte[] bytes = (byte[])value;
            if (!string.IsNullOrEmpty(caminho))
                return DependencyService.Get<IFotoLoadMediaPlugin>().GetPathToPhoto(caminho);
            else
                return (bytes == null || bytes.Length == 0) ? "consultar.png" : ImageSource.FromStream(() => new MemoryStream(bytes));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
