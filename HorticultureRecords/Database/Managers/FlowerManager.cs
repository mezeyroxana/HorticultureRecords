using HorticultureRecords.Database.Interfaces;
using HorticultureRecords.Database.Records;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HorticultureRecords.Database.Managers
{
    class FlowerManager : BaseDatabaseHelper, IDataManipulationLanguage, IQueryLanguage
    {
        public int Delete(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = @"DELETE_flowers";
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
            command.CommandText = @"INSERT INTO flowers (name, quantity, genus) VALUES (@name, @quantity, @genus)";
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
            command.CommandText = @"SELECT * FROM flowers WHERE id = @id";
            command.Parameters.AddWithValue("@id", record.Id);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                command.Connection = connection;
                SqlDataReader reader = command.ExecuteReader();

                FlowerRecord selectedRecord = new FlowerRecord();
                if (reader.Read())
                {
                    selectedRecord = new FlowerRecord(
                       int.Parse(reader["id"].ToString()),
                       reader["name"].ToString(),
                       int.Parse(reader["quantity"].ToString()),
                       reader["genus"].ToString());
                }
                return selectedRecord;
            }

        }

        public List<Record> Select()
        {
            List<Record> records = new List<Record>();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"SELECT * FROM flowers ORDER BY name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                command.Connection = connection;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    FlowerRecord nextRecord = new FlowerRecord(
                        int.Parse(reader["id"].ToString()),
                        reader["name"].ToString(),
                        int.Parse(reader["quantity"].ToString()),
                        reader["genus"].ToString());
                    records.Add(nextRecord);
                }
            }
            return records;
        }

        public int Update(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"UPDATE Flowers SET Name = @name, Quantity = @quantity, Genus = @genus WHERE Id = @id";
            command.Parameters.AddWithValue("@id", record.Id);
            command.Parameters.AddWithValue("@name", (record as FlowerRecord).Name);
            command.Parameters.AddWithValue("@quantity", (record as FlowerRecord).Quantity);
            command.Parameters.AddWithValue("@genus", (record as FlowerRecord).Genus);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                command.Connection = connection;
                int updatedRows = command.ExecuteNonQuery();
                return updatedRows;
            }
        }

        public List<Record> SelectOnlyAvailableFlowers()
        {
            List<Record> records = new List<Record>();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"SELECT * FROM flowers WHERE quantity > 0 ORDER BY name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                command.Connection = connection;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    FlowerRecord nextRecord = new FlowerRecord(
                        int.Parse(reader["id"].ToString()),
                        reader["name"].ToString(),
                        int.Parse(reader["quantity"].ToString()),
                        reader["genus"].ToString());
                    records.Add(nextRecord);
                }
            }
            return records;
        }

        public int SelectMarketableFlowerQuantity(FlowerRecord flower)
        {
            int allQuantityOfSelectedFlower = (Select(flower) as FlowerRecord).Quantity;
            int orderedQuantityOfSelectedFlower = new OrderManager().SelectMarketableFlowerQuantity(flower);
            return allQuantityOfSelectedFlower - orderedQuantityOfSelectedFlower;
        }
    }
}
