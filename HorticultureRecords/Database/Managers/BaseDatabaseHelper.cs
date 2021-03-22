using System.Data.SqlClient;

namespace HorticultureRecords.Database
{
    class BaseDatabaseHelper
    {
        public BaseDatabaseHelper() { }

        protected string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|HorticultureDatabase.mdf;Integrated Security=True";
        /*protected SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection();
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|HorticultureDatabase.mdf;Integrated Security=True";
            connection.ConnectionString = connectionString;
            connection.Open();
            return connection;
        }*/


    }
}
