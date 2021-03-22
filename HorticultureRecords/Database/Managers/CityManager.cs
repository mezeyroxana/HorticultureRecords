using HorticultureRecords.Database.Records;
using System.Data;
using System.Data.SqlClient;

namespace HorticultureRecords.Database.Managers
{
    class CityManager : BaseDatabaseHelper
    {
        public CityRecord SelectCityByZipcode(string zipcode)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT * FROM Cities WHERE zipcode = @zipcode";
            command.Parameters.AddWithValue("@zipcode", zipcode);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                command.Connection = connection;
                SqlDataReader reader = command.ExecuteReader();

                CityRecord selectedRecord = new CityRecord();
                if (reader.Read())
                {
                    selectedRecord = new CityRecord(
                        reader["zipcode"].ToString(),
                        reader["cityName"].ToString()
                    );
                }
                return selectedRecord;
            }
        }

        public CityRecord SelectZipcodeByCity(string city)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT * FROM Cities WHERE cityName = @city";
            command.Parameters.AddWithValue("@city", city);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                command.Connection = connection;
                SqlDataReader reader = command.ExecuteReader();

                CityRecord selectedRecord = new CityRecord();
                if (reader.Read())
                {
                    selectedRecord = new CityRecord(
                        reader["zipcode"].ToString(),
                        reader["cityName"].ToString()
                    );
                }
                return selectedRecord;
            }
        }
    }
}
