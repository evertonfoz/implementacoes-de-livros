using System;
using System.Globalization;
using Xamarin.Forms;

namespace Capitulo05.Converters
{
    public class BooleanNegadoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valor = (bool)value;
            return !valor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}