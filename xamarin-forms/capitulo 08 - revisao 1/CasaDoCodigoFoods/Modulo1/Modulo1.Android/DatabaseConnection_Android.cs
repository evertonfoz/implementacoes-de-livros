using Modulo1.Droid;
using Modulo1.Infrastructure;
using SQLite;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_Android))]
namespace Modulo1.Droid
{
    public class DatabaseConnection_Android : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "CCFoodsDb.db");
            return new SQLiteConnection(path);
        }
    }
}