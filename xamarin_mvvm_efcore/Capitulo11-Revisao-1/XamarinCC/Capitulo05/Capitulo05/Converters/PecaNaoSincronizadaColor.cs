using System;
using System.Globalization;
using Xamarin.Forms;

namespace Capitulo05.Converters
{
    public class PecaNaoSincronizadaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!((bool)value))
                return Color.Red;
            return Color.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}