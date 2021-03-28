using HorticultureRecords.Database.Interfaces;
using HorticultureRecords.Database.Records;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HorticultureRecords.Database.Managers
{
    class OrderManager : BaseDatabaseHelper, IDataManipulationLanguage, IQueryLanguage
    {
        public int Delete(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = @"DELETE_ORDERS";
            command.Parameters.Add("@id", SqlDbType.Int).Value = record.Id;

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

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                command.Connection = connection;
                int affectedRows = command.ExecuteNonQuery();
                return affectedRows;
            }
        }

        public Record Select(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM orderDatas WHERE id = @id";
            command.Parameters.AddWithValue("@id", record.Id);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                command.Connection = connection;
                SqlDataReader reader = command.ExecuteReader();

                OrderRecord selectedRecord = new OrderRecord();
                if (reader.Read())
                {
                    selectedRecord = new OrderRecord(
                        int.Parse(reader["id"].ToString()),
                        int.Parse(reader["customerId"].ToString()),
                        Convert.ToBoolean(reader["isCompleted"].ToString()),
                        Convert.ToBoolean(reader["isDeliveryRequested"].ToString())
                    );
                }
                return selectedRecord;
            }
        }

        public int SelectMarketableFlowerQuantity(FlowerRecord flower)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT OrderedFlowers.FlowerId, SUM(OrderedFlowers.Quantity) FROM OrderedFlowers INNER JOIN OrderDatas ON OrderedFlowers.OrderId = OrderDatas.Id WHERE OrderedFlowers.FlowerId = @flowerId AND OrderDatas.IsCompleted = 0 GROUP BY OrderedFlowers.FlowerId";
            command.Parameters.AddWithValue("@flowerId", flower.Id);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                command.Connection = connection;
                SqlDataReader reader = command.ExecuteReader();

                int orderedQuantity = 0;
                if (reader.Read())
                    orderedQuantity = int.Parse(reader[1].ToString());
                return orderedQuantity;
            }
        }

        public List<Record> Select()
        {
            List<Record> records = new List<Record>();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT * FROM orders ORDER BY flowerId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                command.Connection = connection;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    OrderRecord nextRecord = new OrderRecord(
                        int.Parse(reader["id"].ToString()),
                        int.Parse(reader["customerId"].ToString()),
                        Convert.ToBoolean(reader["isCompleted"].ToString()),
                        Convert.ToBoolean(reader["isDeliveryRequested"].ToString())
                    );
                    records.Add(nextRecord);
                }
                return records;
            }
        }

        public int Update(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "UPDATE_ORDERS";
            command.Parameters.Add("@isCompleted", SqlDbType.Bit).Value = (record as OrderRecord).IsCompleted;
            command.Parameters.Add("@isDeliveryRequested", SqlDbType.Bit).Value = (record as OrderRecord).IsDeliveryRequested;
            command.Parameters.Add("@id", SqlDbType.Int).Value = record.Id;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                command.Connection = connection;
                int updatedRows = command.ExecuteNonQuery();

                return updatedRows;
            }
        }

        public int UpdateFlowerOrder(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "UPDATE_FLOWERORDERS";
            command.Parameters.AddWithValue("@orderId", (record as OrderRecord).Id);
            command.Parameters.AddWithValue("@flowerId", (record as OrderRecord).FlowerId);
            command.Parameters.AddWithValue("@quantity", (record as OrderRecord).Quantity);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                command.Connection = connection;
                int updatedRows = command.ExecuteNonQuery();
                return updatedRows;
            }
        }

        public int DeleteFlowerOrder(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"DELETE FROM OrderedFlowers WHERE OrderId = @orderId AND FlowerId = @flowerId";
            command.Parameters.AddWithValue("@orderId", record.Id);
            command.Parameters.AddWithValue("@flowerId", (record as OrderRecord).FlowerId);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                command.Connection = connection;
                int deletedRows = command.ExecuteNonQuery();
                return deletedRows;
            }

        }

        public List<Record> SelectFlowersForSpecificOrder(Record orderRecord)
        {
            List<Record> records = new List<Record>();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT FlowerId, Quantity From OrderedFlowers WHERE OrderId = @orderId";
            command.Parameters.AddWithValue("@orderId", orderRecord.Id);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                command.Connection = connection;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    FlowerRecord nextRecord = new FlowerRecord(
                        int.Parse(reader["FlowerId"].ToString()),
                        int.Parse(reader["Quantity"].ToString())
                    );
                    records.Add(nextRecord);
                }
                return records;
            }
        }


        public List<Record> SelectOrders()
        {
            List<Record> records = new List<Record>();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT Id, CustomerId, IsDeliveryRequested, IsCompleted FROM OrderDatas";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                command.Connection = connection;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    OrderRecord nextRecord = new OrderRecord(
                        int.Parse(reader["Id"].ToString()),
                        int.Parse(reader["customerId"].ToString()),
                        Convert.ToBoolean(reader["isCompleted"].ToString()),
                        Convert.ToBoolean(reader["isDeliveryRequested"].ToString())
                    );
                    records.Add(nextRecord);
                }
                return records;
            }
        }
    }
}
