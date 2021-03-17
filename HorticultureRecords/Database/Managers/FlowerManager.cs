using HorticultureRecords.Database.Interfaces;
using HorticultureRecords.Database.Records;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HorticultureRecords.Database.Managers
{
    class FlowerManager : BaseDatabaseHelper, IDataManipulationLanguage, IQueryLanguage
    {
        public int Delete(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = @"DELETE_flowers";
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
            command.CommandText = @"INSERT INTO flowers (name, quantity, genus) VALUES (@name, @quantity, @genus)";
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
            command.CommandText = @"SELECT * FROM flowers WHERE id = @id";
            command.Parameters.AddWithValue("@id", record.Id);

            command.Connection = getConnection();
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

            command.Connection.Close();
            return selectedRecord;
        }

        public List<Record> Select()
        {
            List<Record> records = new List<Record>();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"SELECT * FROM flowers ORDER BY name";

            command.Connection = getConnection();
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
            command.Connection.Close();
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

            command.Connection = getConnection();
            int updatedRows = command.ExecuteNonQuery();

            command.Connection.Close();
            return updatedRows;
        }

        public List<Record> SelectOnlyAvailableFlowers()
        {
            List<Record> records = new List<Record>();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"SELECT * FROM flowers WHERE quantity > 0 ORDER BY name";

            command.Connection = getConnection();
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
            command.Connection.Close();
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
