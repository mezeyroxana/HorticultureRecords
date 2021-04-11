using HorticultureRecords.Database.Records;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HorticultureRecords.Database.Managers
{
    class CustomerManager
    {
        public Record Select(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT * FROM Customers WHERE id = @id";
            command.Parameters.AddWithValue("@id", record.Id);

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.connectionString))
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
            catch (InvalidOperationException)
            {
                throw new DatabaseException("Nem sikerült kapcsolatot létesíteni az adatbázissal!");
            }
            catch (SqlException)
            {
                throw new DatabaseException("Nem sikerült a művelet végrehajtása!");
            }
            catch (Exception)
            {
                throw new DatabaseException("Adatbázishiba lépett fel!");
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

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.connectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    command.Connection = connection;
                    int affectedRows = command.ExecuteNonQuery();
                    return affectedRows;
                }
            }
            catch (InvalidOperationException)
            {
                throw new DatabaseException("Nem sikerült kapcsolatot létesíteni az adatbázissal!");
            }
            catch (SqlException)
            {
                throw new DatabaseException("Nem sikerült a művelet végrehajtása!");
            }
            catch (Exception)
            {
                throw new DatabaseException("Adatbázishiba lépett fel!");
            }
        }
    }
}
