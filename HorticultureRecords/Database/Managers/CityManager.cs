using HorticultureRecords.Database.Interfaces;
using HorticultureRecords.Database.Records;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HorticultureRecords.Database.Managers
{
    class CityManager : BaseDatabaseHelper
    {
        public CityRecord SelectCityByZipcode(string zipcode)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"SELECT * FROM Cities WHERE zipcode = @zipcode";
            command.Parameters.AddWithValue("@zipcode", zipcode);

            command.Connection = getConnection();
            SqlDataReader reader = command.ExecuteReader();

            CityRecord selectedRecord = new CityRecord();
            if (reader.Read())
            {
                selectedRecord = new CityRecord(
                    reader["zipcode"].ToString(),
                    reader["cityName"].ToString()
                );
            }

            command.Connection.Close();
            return selectedRecord;
        }

        public CityRecord SelectZipcodeByCity(string city)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"SELECT * FROM Cities WHERE cityName = @city";
            command.Parameters.AddWithValue("@city", city);

            command.Connection = getConnection();
            SqlDataReader reader = command.ExecuteReader();

            CityRecord selectedRecord = new CityRecord();
            if (reader.Read())
            {
                selectedRecord = new CityRecord(
                    reader["zipcode"].ToString(),
                    reader["cityName"].ToString()
                );
            }

            command.Connection.Close();
            return selectedRecord;
        }
    }
}
