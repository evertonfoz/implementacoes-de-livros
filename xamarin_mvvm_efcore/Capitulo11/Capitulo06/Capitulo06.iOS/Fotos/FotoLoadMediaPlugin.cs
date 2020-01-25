using System;
using System.IO;
using Capitulo06.iOS.Fotos;
using Interfaces.Fotos;

[assembly: Xamarin.Forms.Dependency(typeof(FotoLoadMediaPlugin))]
namespace Capitulo06.iOS.Fotos
{
    public class FotoLoadMediaPlugin : IFotoLoadMediaPlugin
    {
        public string GetDevicePathToPhoto()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Fotos");
        }

        public string GetPathToPhoto(string caminhoArmazenado)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Fotos", caminhoArmazenado);
        }

        public string SetPathToPhoto(string caminhoCompleto)
        {
            return caminhoCompleto.Substring(caminhoCompleto.LastIndexOf("/")+1);
        }
    }
}