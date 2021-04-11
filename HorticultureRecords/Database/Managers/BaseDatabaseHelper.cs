using System.Configuration;
using System.Data.SqlClient;

namespace HorticultureRecords.Database
{
    static class BaseDatabaseHelper
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["FlowerDatabase"].ConnectionString;
    }
}
