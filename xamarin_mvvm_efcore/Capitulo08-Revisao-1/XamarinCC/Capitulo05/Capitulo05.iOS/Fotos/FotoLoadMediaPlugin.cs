using Capitulo05.iOS.Fotos;
using Interfaces.Fotos;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(FotoLoadMediaPlugin))]
namespace Capitulo05.iOS.Fotos
{
    public class FotoLoadMediaPlugin : IFotoLoadMediaPlugin
    {
        public string SetPathToPhoto(string caminhoCompleto)
        {
            return caminhoCompleto.Substring(caminhoCompleto.LastIndexOf("/") + 1);
        }
        public string GetDevicePathToPhoto()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Fotos");
        }
        public string GetPathToPhoto(string caminhoArmazenado)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Fotos", caminhoArmazenado);
        }
    }
}