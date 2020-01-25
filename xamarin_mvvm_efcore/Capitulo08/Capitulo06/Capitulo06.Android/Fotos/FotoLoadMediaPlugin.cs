using Capitulo06.Droid.Fotos;
using Interfaces.Fotos;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(FotoLoadMediaPlugin))]
namespace Capitulo06.Droid.Fotos
{
    public class FotoLoadMediaPlugin : IFotoLoadMediaPlugin
    {
        public string GetDevicePathToPhoto()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "Fotos");
        }

        public string SetPathToPhoto(string caminhoCompleto)
        {
            return caminhoCompleto;
        }

        public string GetPathToPhoto(string caminhoArmazenado)
        {
            return caminhoArmazenado;
        }
    }
}