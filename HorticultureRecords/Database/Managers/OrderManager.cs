using HorticultureRecords.Database.Records;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HorticultureRecords.Database.Managers
{
    class OrderManager
    {
        public int Delete(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"DELETE FROM Orders WHERE Id = @id";
            command.Parameters.AddWithValue("@id", record.Id);

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.connectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    command.Connection = connection;
                    int deletedRows = command.ExecuteNonQuery();
                    return deletedRows;
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

        public int Insert(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT_ORDERS";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@customerName", SqlDbType.NVarChar).Value = (record as OrderRecord).Customer.Name;
            command.Parameters.Add("@customerPhoneNumber", SqlDbType.NVarChar).Value = (record as OrderRecord).Customer.PhoneNumber;
            command.Parameters.Add("@customerEmail", SqlDbType.NVarChar).Value = (record as OrderRecord).Customer.Email;
            command.Parameters.Add("@customerCityName", SqlDbType.NVarChar).Value = (record as OrderRecord).Customer.City;
            command.Parameters.Add("@customerAddress", SqlDbType.NVarChar).Value = (record as OrderRecord).Customer.Address;
            command.Parameters.Add("@flowerName", SqlDbType.NVarChar).Value = (record as OrderRecord).Flower.Name;
            command.Parameters.Add("@quantity", SqlDbType.Int).Value = (record as OrderRecord).Quantity;
            command.Parameters.Add("@isCompleted", SqlDbType.Bit).Value = (record as OrderRecord).IsCompleted;
            command.Parameters.Add("@isDeliveryRequested", SqlDbType.Bit).Value = (record as OrderRecord).IsDeliveryRequested;
            command.Parameters.Add("@comment", SqlDbType.NVarChar).Value = (record as OrderRecord).Comment;

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

        public int Update(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"UPDATE Orders SET IsCompleted = @isCompleted, IsDeliveryRequested = @isDeliveryRequested, Comment = @comment WHERE Id = @id";
            command.Parameters.AddWithValue("@isCompleted", (record as OrderRecord).IsCompleted);
            command.Parameters.AddWithValue("@isDeliveryRequested", (record as OrderRecord).IsDeliveryRequested);
            command.Parameters.AddWithValue("@comment", (record as OrderRecord).Comment);
            command.Parameters.AddWithValue("@id", record.Id);

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.connectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    command.Connection = connection;
                    int updatedRows = command.ExecuteNonQuery();

                    return updatedRows;
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

        public Record Select(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT Orders.Id, Customers.Id, Customers.Name, Orders.IsCompleted, Orders.IsDeliveryRequested, Orders.Comment FROM Orders INNER JOIN Customers ON Orders.CustomerId = Customers.Id WHERE Orders.Id = @id";
            command.Parameters.AddWithValue("@id", record.Id);

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.connectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    command.Connection = connection;
                    SqlDataReader reader = command.ExecuteReader();

                    OrderRecord selectedRecord = new OrderRecord();
                    if (reader.Read())
                    {
                        selectedRecord = new OrderRecord(
                            int.Parse(reader[0].ToString()),
                            int.Parse(reader[1].ToString()),
                            reader[2].ToString(),
                            Convert.ToBoolean(reader[3].ToString()),
                            Convert.ToBoolean(reader[4].ToString()),
                            reader[5].ToString()
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

        public List<Record> Select()
        {
            List<Record> records = new List<Record>();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT Orders.Id, Customers.Id, Customers.Name, Orders.IsCompleted, Orders.IsDeliveryRequested, Orders.Comment FROM Orders INNER JOIN Customers ON Orders.CustomerId = Customers.Id";

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.connectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    command.Connection = connection;
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        OrderRecord nextRecord = new OrderRecord(
                            int.Parse(reader[0].ToString()),
                            int.Parse(reader[1].ToString()),
                            reader[2].ToString(),
                            Convert.ToBoolean(reader[3].ToString()),
                            Convert.ToBoolean(reader[4].ToString()),
                            reader[5].ToString()
                        );
                        records.Add(nextRecord);
                    }
                    return records;
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
