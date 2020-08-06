using System;
using System.Globalization;
using Xamarin.Forms;

namespace Capitulo05.Converters
{
    public class ImagemNaoCarregadaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value == null) && string.IsNullOrEmpty(((Label)parameter).Text) ? true : false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}