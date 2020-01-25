using Capitulo06.iOS.DataAccess;
using CasaDoCodigo.DataAccess.Interfaces;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DatabasePath))]
namespace Capitulo06.iOS.DataAccess
{
    public class DatabasePath : IDBPath
    {
        public string GetDbPath()
        {
            var caminhoCompleto = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", "OficinaEFC5.db");
            return caminhoCompleto;
        }
    }
}
