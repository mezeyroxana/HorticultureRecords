using HorticultureRecords.Database.Interfaces;
using HorticultureRecords.Database.Records;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HorticultureRecords.Database.Managers
{
    class CustomerManager : BaseDatabaseHelper, IDataManipulationLanguage, IQueryLanguage
    {
        public int Delete(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = @"DELETE_customers";
            command.Parameters.Add("p_id", System.Data.SqlDbType.Int).Value = record.Id;

            command.Connection = getConnection();
            int deletedRows = command.ExecuteNonQuery();

            command.Connection.Close();
            return deletedRows;
        }

        public int Insert(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"INSERT INTO customers (name, phonenumber, email, address) VALUES (@name, @phonenumber, @email, @address)";
            command.Parameters.AddWithValue("@name", (record as FlowerRecord).Name);
            command.Parameters.AddWithValue("@quantity", (record as FlowerRecord).Quantity);
            command.Parameters.AddWithValue("@genus", (record as FlowerRecord).Genus);

            command.Connection = getConnection();
            int insertedRows = command.ExecuteNonQuery();

            command.Connection.Close();
            return insertedRows;
        }

        public Record Select(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"SELECT * FROM Customers WHERE id = @id";
            command.Parameters.AddWithValue("@id", record.Id);

            command.Connection = getConnection();
            SqlDataReader reader = command.ExecuteReader();

            CustomerRecord selectedRecord = new CustomerRecord();
            if (reader.Read())
            {
                selectedRecord = new CustomerRecord(
                    int.Parse(reader["id"].ToString()),
                    reader["name"].ToString(),
                    reader["phonenumber"].ToString(),
                    reader["email"].ToString(),
                    reader["cityId"].ToString(),
                    reader["address"].ToString()
                );
            }

            command.Connection.Close();
            return selectedRecord;
        }

        public List<Record> Select()
        {
            List<Record> records = new List<Record>();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"SELECT * FROM customers ORDER BY name";

            command.Connection = getConnection();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                CustomerRecord nextRecord = new CustomerRecord(
                    int.Parse(reader["id"].ToString()),
                    reader["name"].ToString(),
                    reader["phonenumber"].ToString(),
                    reader["email"].ToString(),
                    reader["cityId"].ToString(),
                    reader["address"].ToString());
                records.Add(nextRecord);
            }

            command.Connection.Close();
            return records;
        }

        public int Update(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE_CUSTOMERS";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = record.Id;
            command.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = (record as CustomerRecord).Name;
            command.Parameters.Add("@phoneNumber", System.Data.SqlDbType.NVarChar).Value = (record as CustomerRecord).PhoneNumber;
            command.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = (record as CustomerRecord).Email;
            command.Parameters.Add("@zipcode", System.Data.SqlDbType.NChar).Value = (record as CustomerRecord).Zipcode;
            command.Parameters.Add("@cityName", System.Data.SqlDbType.NVarChar).Value = (record as CustomerRecord).CityName;
            command.Parameters.Add("@address", System.Data.SqlDbType.NVarChar).Value = (record as CustomerRecord).Address;

            command.Connection = getConnection();
            int affectedRows = command.ExecuteNonQuery();
            command.Connection.Close();
            return affectedRows;
        }
    }
}
