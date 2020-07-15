using SQLite;

namespace Modulo1.Infrastructure
{
    public interface IDatabaseConnection
    {
        SQLiteConnection DbConnection();
    }
}
