using HorticultureRecords.Database.Interfaces;
using HorticultureRecords.Database.Records;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HorticultureRecords.Database.Managers
{
    class OrderManager : BaseDatabaseHelper, IDataManipulationLanguage, IQueryLanguage
    {
        public int Delete(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = @"DELETE_ORDERS";
            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = record.Id;

            command.Connection = getConnection();
            int deletedRows = command.ExecuteNonQuery();

            command.Connection.Close();
            return deletedRows;
        }

        public int Insert(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT_ORDERS";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add("@customerName", System.Data.SqlDbType.NVarChar).Value = (record as OrderRecord).Customer.Name;
            command.Parameters.Add("@customerPhoneNumber", System.Data.SqlDbType.NVarChar).Value = (record as OrderRecord).Customer.PhoneNumber;
            command.Parameters.Add("@customerEmail", System.Data.SqlDbType.NVarChar).Value = (record as OrderRecord).Customer.Email;
            command.Parameters.Add("@customerCityZipcode", System.Data.SqlDbType.NChar).Value = (record as OrderRecord).Customer.City.Zipcode;
            command.Parameters.Add("@customerCityName", System.Data.SqlDbType.NVarChar).Value = (record as OrderRecord).Customer.City.Name;
            command.Parameters.Add("@customerAddress", System.Data.SqlDbType.NVarChar).Value = (record as OrderRecord).Customer.Address;
            command.Parameters.Add("@flowerName", System.Data.SqlDbType.NVarChar).Value = (record as OrderRecord).Flower.Name;
            command.Parameters.Add("@quantity", System.Data.SqlDbType.Int).Value = (record as OrderRecord).Quantity;
            command.Parameters.Add("@isCompleted", System.Data.SqlDbType.Bit).Value = (record as OrderRecord).IsCompleted;
            command.Parameters.Add("@isDeliveryRequested", System.Data.SqlDbType.Bit).Value = (record as OrderRecord).IsDeliveryRequested;

            command.Connection = getConnection();
            int affectedRows = command.ExecuteNonQuery();
            command.Connection.Close();
            return affectedRows;
        }

        public Record Select(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM orderDatas WHERE id = @id";
            command.Parameters.AddWithValue("@id", record.Id);

            command.Connection = getConnection();
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

            command.Connection.Close();
            return selectedRecord;
        }

        public int SelectMarketableFlowerQuantity(FlowerRecord flower)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT OrderedFlowers.FlowerId, SUM(OrderedFlowers.Quantity) FROM OrderedFlowers INNER JOIN OrderDatas ON OrderedFlowers.OrderId = OrderDatas.Id WHERE OrderedFlowers.FlowerId = @flowerId AND OrderDatas.IsCompleted = 0 GROUP BY OrderedFlowers.FlowerId";
            command.Parameters.AddWithValue("@flowerId", flower.Id);

            command.Connection = getConnection();
            SqlDataReader reader = command.ExecuteReader();

            int orderedQuantity = 0;
            if (reader.Read())
                orderedQuantity = int.Parse(reader[1].ToString());

            return orderedQuantity;
        }

        public List<Record> Select()
        {
            List<Record> records = new List<Record>();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"SELECT * FROM orders ORDER BY flowerId";

            command.Connection = getConnection();
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

            command.Connection.Close();
            return records;
        }

        public int Update(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "UPDATE_ORDERS";
            command.Parameters.Add("@isCompleted", System.Data.SqlDbType.Bit).Value = (record as OrderRecord).IsCompleted;
            command.Parameters.Add("@isDeliveryRequested", System.Data.SqlDbType.Bit).Value = (record as OrderRecord).IsDeliveryRequested;
            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = record.Id;

            command.Connection = getConnection();
            int updatedRows = command.ExecuteNonQuery();            

            command.Connection.Close();
            return updatedRows;
        }

        public int UpdateFlowerOrder(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "UPDATE_FLOWERORDERS";
            command.Parameters.AddWithValue("@orderId", (record as OrderRecord).Id);
            command.Parameters.AddWithValue("@flowerId", (record as OrderRecord).FlowerId);
            command.Parameters.AddWithValue("@quantity", (record as OrderRecord).Quantity);

            command.Connection = getConnection();
            int updatedRows = command.ExecuteNonQuery();

            command.Connection.Close();
            return updatedRows;
        }

        public int DeleteFlowerOrder(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"DELETE FROM OrderedFlowers WHERE OrderId = @orderId AND FlowerId = @flowerId";
            command.Parameters.AddWithValue("@orderId", record.Id);
            command.Parameters.AddWithValue("@flowerId", (record as OrderRecord).FlowerId);

            command.Connection = getConnection();
            int deletedRows = command.ExecuteNonQuery();

            command.Connection.Close();
            return deletedRows;
        }

        public List<Record> SelectFlowersForSpecificOrder(Record orderRecord)
        {
            List<Record> records = new List<Record>();
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"SELECT FlowerId, Quantity From OrderedFlowers WHERE OrderId = @orderId";
            command.Parameters.AddWithValue("@orderId", orderRecord.Id);

            command.Connection = getConnection();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                FlowerRecord nextRecord = new FlowerRecord(
                    int.Parse(reader["FlowerId"].ToString()),
                    int.Parse(reader["Quantity"].ToString())
                );
                records.Add(nextRecord);
            }

            command.Connection.Close();
            return records;
        }


        public List<Record> SelectOrders()
        {
            List<Record> records = new List<Record>();
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"SELECT Id, CustomerId, IsDeliveryRequested, IsCompleted FROM OrderDatas";

            command.Connection = getConnection();
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

            command.Connection.Close();
            return records;
        }
    }
}
