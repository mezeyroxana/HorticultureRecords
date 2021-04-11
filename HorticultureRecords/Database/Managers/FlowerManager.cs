using HorticultureRecords.Database.Records;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HorticultureRecords.Database.Managers
{
    class FlowerManager
    {
        public Record Select(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT Flowers.Id, Flowers.Name, Flowers.Quantity, Flowers.AvailableQuantity, FlowerGenera.Genus FROM Flowers INNER JOIN FlowerGenera ON Flowers.GenusId = FlowerGenera.Id WHERE Flowers.Id = @id";
            command.Parameters.AddWithValue("@id", record.Id);

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.connectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    command.Connection = connection;
                    SqlDataReader reader = command.ExecuteReader();

                    FlowerRecord selectedRecord = new FlowerRecord();
                    if (reader.Read())
                    {
                        selectedRecord = new FlowerRecord(
                           int.Parse(reader[0].ToString()),
                           reader[1].ToString(),
                           int.Parse(reader[2].ToString()),
                           reader[4].ToString(),
                           int.Parse(reader[3].ToString()));
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
            command.CommandText = @"SELECT Flowers.Id, Flowers.Name, Flowers.Quantity, Flowers.AvailableQuantity, FlowerGenera.Genus FROM Flowers INNER JOIN FlowerGenera ON Flowers.GenusId = FlowerGenera.Id ORDER BY Flowers.GenusId";

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
                            int.Parse(reader[0].ToString()),
                            reader[1].ToString(),
                            int.Parse(reader[2].ToString()),
                            reader[4].ToString(),
                            int.Parse(reader[3].ToString()));
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

        public int Update(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"UPDATE Flowers SET Name = @name, Quantity = @quantity WHERE Id = @id";
            command.Parameters.AddWithValue("@id", record.Id);
            command.Parameters.AddWithValue("@name", (record as FlowerRecord).Name);
            command.Parameters.AddWithValue("@quantity", (record as FlowerRecord).Quantity);

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

        //Those Flowers where Quantity is bigger than 0
        public List<Record> SelectFlowersInStock()
        {
            List<Record> records = new List<Record>();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT Flowers.Id, Flowers.Name, Flowers.Quantity, FlowerGenera.Genus FROM Flowers INNER JOIN FlowerGenera ON Flowers.GenusId = FlowerGenera.Id WHERE Flowers.Quantity > 0 ORDER BY Flowers.GenusId";

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
                            int.Parse(reader[0].ToString()),
                            reader[1].ToString(),
                            int.Parse(reader[2].ToString()),
                            reader[3].ToString());
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

        //Those Flowers where AvailableQuantity is bigger than 0
        public List<Record> SelectAvailableFlowers()
        {
            List<Record> records = new List<Record>();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT Flowers.Id, Flowers.Name, Flowers.Quantity, FlowerGenera.Genus FROM Flowers INNER JOIN FlowerGenera ON Flowers.GenusId = FlowerGenera.Id WHERE Flowers.AvailableQuantity > 0 ORDER BY Flowers.GenusId";

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
                            int.Parse(reader[0].ToString()),
                            reader[1].ToString(),
                            int.Parse(reader[2].ToString()),
                            reader[3].ToString());
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

        //Same as SelectAvailableFlowers but it return for one specific flower
        public int SelectAvailableFlowers(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT AvailableQuantity FROM Flowers WHERE Id = @id";
            command.Parameters.AddWithValue("@id", record.Id);

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.connectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    command.Connection = connection;
                    SqlDataReader reader = command.ExecuteReader();

                    int availableFlowers = 0;
                    if (reader.Read())
                        availableFlowers = int.Parse(reader[0].ToString());
                    return availableFlowers;
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

        public int SelectFlowerIdByFlowerName(Record record)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT Id From Flowers WHERE Name = @name";
            command.Parameters.AddWithValue("@name", (record as FlowerRecord).Name);

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.connectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    command.Connection = connection;
                    SqlDataReader reader = command.ExecuteReader();
                    int flowerId = -1;
                    if (reader.Read())
                        flowerId = int.Parse(reader[0].ToString());

                    return flowerId;
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
