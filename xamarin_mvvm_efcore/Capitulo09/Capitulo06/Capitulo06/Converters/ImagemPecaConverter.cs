using Capitulo06.Services;
using CasaDoCodigo.DAL;
using CasaDoCodigo.DataAccess;
using CasaDoCodigo.DataAccess.Interfaces;
using CasaDoCodigo.Models;
using Interfaces.Fotos;
using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Capitulo06.Converters
{
    public class ImagemPecaConverter : IValueConverter
    {
        private IDAL<Peca> pecasDAL = new PecaDAL(DependencyService.Get<IDBPath>().GetDbPath());

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string caminho = ((Label) parameter).Text;
            byte[] bytes = (byte[])value;
            if (!string.IsNullOrEmpty(caminho))
                //return DependencyService.Get<IFotoLoadMediaPlugin>().GetPathToPhoto(caminho);
                return caminho.Equals("consultar.png") ? caminho : DependencyService.Get<IFotoLoadMediaPlugin>().GetPathToPhoto(caminho);
            else
                return (bytes == null || bytes.Length == 0) ? "consultar.png" : ImageSource.FromStream(() => new MemoryStream(bytes));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
