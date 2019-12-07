using SQLite;

namespace Modulo1.Infraestructure
{
    public interface IDatabaseConnection
    {
        SQLiteConnection DbConnection();
    }
}
