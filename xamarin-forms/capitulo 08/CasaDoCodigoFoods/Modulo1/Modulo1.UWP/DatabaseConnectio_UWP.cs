using Modulo1.Infraestructure;
using Modulo1.UWP;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using System.IO;
using Windows.Storage;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnectio_UWP))]
namespace Modulo1.UWP
{
    public class DatabaseConnectio_UWP : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "CCFoodsDb.db3";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbName);
            var platform = new SQLitePlatformWinRT();
            return new SQLiteConnection(platform, path);
        }
    }
}
