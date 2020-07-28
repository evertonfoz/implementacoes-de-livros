using Capitulo05.Droid.DataAccess;
using CasaDoCodigo.DataAccess;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DatabasePath))]
namespace Capitulo05.Droid.DataAccess
{
    public class DatabasePath : IDBPath
    {
        public string GetDbPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Oficina.db");
        }
    }
}