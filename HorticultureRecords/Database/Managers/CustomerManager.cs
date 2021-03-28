using HorticultureRecords.Database.Interfaces;
using HorticultureRecords.Database.Records;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HorticultureRecords.Database.Managers
{
    class CustomerManager : BaseDatabaseHelper, IDataManipulationLanguage, IQueryLanguage
    {
        public int Delete(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = @"DELETE_customers";
            command.Parameters.Add("p_id", SqlDbType.Int).Value = record.Id;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                command.Connection = connection;
                int deletedRows = command.ExecuteNonQuery();
                return deletedRows;
            }
        }

        public int Insert(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"INSERT INTO customers (name, phonenumber, email, address) VALUES (@name, @phonenumber, @email, @address)";
            command.Parameters.AddWithValue("@name", (record as FlowerRecord).Name);
            command.Parameters.AddWithValue("@quantity", (record as FlowerRecord).Quantity);
            command.Parameters.AddWithValue("@genus", (record as FlowerRecord).Genus);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                command.Connection = connection;
                int insertedRows = command.ExecuteNonQuery();
                return insertedRows;
            }
        }

        public Record Select(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT * FROM Customers WHERE id = @id";
            command.Parameters.AddWithValue("@id", record.Id);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                command.Connection = connection;
                SqlDataReader reader = command.ExecuteReader();

                CustomerRecord selectedRecord = new CustomerRecord();
                if (reader.Read())
                {
                    selectedRecord = new CustomerRecord(
                        int.Parse(reader["id"].ToString()),
                        reader["name"].ToString(),
                        reader["phonenumber"].ToString(),
                        reader["email"].ToString(),
                        reader["city"].ToString(),
                        reader["address"].ToString()
                    );
                }
                return selectedRecord;
            }
        }

        public List<Record> Select()
        {
            List<Record> records = new List<Record>();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT * FROM customers ORDER BY name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                command.Connection = connection;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CustomerRecord nextRecord = new CustomerRecord(
                        int.Parse(reader["id"].ToString()),
                        reader["name"].ToString(),
                        reader["phonenumber"].ToString(),
                        reader["email"].ToString(),
                        reader["city"].ToString(),
                        reader["address"].ToString());
                    records.Add(nextRecord);
                }
                return records;
            }
        }

        public int Update(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = @"UPDATE Customers SET Name = @name, PhoneNumber = @phoneNumber, Email = @email, City = @city, Address = @address WHERE Id = @id;";
            command.CommandType = CommandType.Text;

            command.Parameters.AddWithValue("@id", record.Id);
            command.Parameters.AddWithValue("@name", (record as CustomerRecord).Name);
            command.Parameters.AddWithValue("@phoneNumber", (record as CustomerRecord).PhoneNumber);
            command.Parameters.AddWithValue("@email", (record as CustomerRecord).Email);
            command.Parameters.AddWithValue("@city", (record as CustomerRecord).City);
            command.Parameters.AddWithValue("@address", (record as CustomerRecord).Address);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                command.Connection = connection;
                int affectedRows = command.ExecuteNonQuery();
                return affectedRows;
            }
        }
    }
}
