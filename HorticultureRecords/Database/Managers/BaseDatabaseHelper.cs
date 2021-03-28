using System.Data.SqlClient;

namespace HorticultureRecords.Database
{
    class BaseDatabaseHelper
    { 
        protected string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|HorticultureDatabase.mdf;Integrated Security=True";
    }
}
