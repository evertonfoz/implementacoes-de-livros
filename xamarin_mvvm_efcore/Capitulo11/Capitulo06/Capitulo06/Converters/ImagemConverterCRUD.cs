using CasaDoCodigo.DAL;
using CasaDoCodigo.DataAccess;
using CasaDoCodigo.DataAccess.Interfaces;
using CasaDoCodigo.Models;
using Interfaces.Fotos;
using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace Capitulo06.Converters
{
    public class ImagemConverterCRUD : IValueConverter
    {
        private IDAL<Peca> pecasDAL = new PecaDAL(DependencyService.Get<IDBPath>().GetDbPath());

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var pecaID = (Guid)value;
            if (pecaID == Guid.Empty)
                return "consultar.png";
            var peca = pecasDAL.GetByIdAsync(pecaID).Result;
            string caminho = peca.CaminhoImagem;
            if (!string.IsNullOrEmpty(caminho))
                return DependencyService.Get<IFotoLoadMediaPlugin>().GetPathToPhoto(caminho);
            else
                return (peca.ImagemEmBytes == null) ? "consultar.png" : ImageSource.FromStream(() => new MemoryStream(peca.ImagemEmBytes));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
