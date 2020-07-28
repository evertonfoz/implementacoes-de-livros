using Capitulo05.iOS.DataAccess;
using CasaDoCodigo.DataAccess;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DatabasePath))]
namespace Capitulo05.iOS.DataAccess
{
    public class DatabasePath : IDBPath
    {
        public string GetDbPath()
        {
            var caminhoCompleto = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", "Oficina.db1");
            return caminhoCompleto;
        }
    }
}