using System;
using System.Globalization;
using Xamarin.Forms;

namespace Capitulo06.Converters
{
    public class AtendimentoFinalizadoColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return Color.Yellow;
            return Color.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
