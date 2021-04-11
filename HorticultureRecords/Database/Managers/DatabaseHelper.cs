using System.Configuration;
using System.Data.SqlClient;

namespace HorticultureRecords.Database
{
    static class DatabaseHelper
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["FlowerDatabase"].ConnectionString;
    }
}
