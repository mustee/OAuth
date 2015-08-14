using System.Data.Common;

namespace OAuth.Data
{
    public interface IDatabaseConnection
    {
        DbConnection Connection { get; }
    }
}
