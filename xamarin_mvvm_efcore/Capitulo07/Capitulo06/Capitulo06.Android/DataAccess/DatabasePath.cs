using Capitulo06.Droid.DataAccess;
using CasaDoCodigo.DataAccess.Interfaces;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DatabasePath))]
namespace Capitulo06.Droid.DataAccess
{
    public class DatabasePath : IDBPath
    {
        public string GetDbPath()
        {
            var caminhoCompleto = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "OficinaEFC5.db");
            return caminhoCompleto;
        }
    }
}