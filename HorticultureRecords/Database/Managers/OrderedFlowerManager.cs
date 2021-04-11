using HorticultureRecords.Database.Records;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HorticultureRecords.Database.Managers
{
    class OrderedFlowerManager
    {
        public int Save(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "UPDATE_FLOWERORDERS";
            command.Parameters.AddWithValue("@orderId", (record as OrderRecord).Id);
            command.Parameters.AddWithValue("@flowerId", (record as OrderRecord).FlowerId);
            command.Parameters.AddWithValue("@quantity", (record as OrderRecord).Quantity);

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

        public int Delete(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"DELETE FROM OrderedFlowers WHERE OrderId = @orderId AND FlowerId = @flowerId";
            command.Parameters.AddWithValue("@orderId", record.Id);
            command.Parameters.AddWithValue("@flowerId", (record as OrderRecord).FlowerId);

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

        public List<Record> Select(Record orderRecord)
        {
            List<Record> records = new List<Record>();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT FlowerId, Quantity From OrderedFlowers WHERE OrderId = @orderId";
            command.Parameters.AddWithValue("@orderId", orderRecord.Id);

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
                        FlowerRecord nextRecord = new FlowerRecord(
                            int.Parse(reader["FlowerId"].ToString()),
                            int.Parse(reader["Quantity"].ToString())
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
