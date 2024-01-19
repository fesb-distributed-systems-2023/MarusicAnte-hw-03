using Microsoft.Data.Sqlite;
using WeatherStationAPI.Models.Domain;
using WeatherStationAPI.Repositories.Interfaces;
using System.Reflection.PortableExecutable;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WeatherStationAPI.Repositories
{
    public class WeatherStationRepository_SQL : IWeatherStationRepository
    {
        private readonly string _connectionString = $"Data Source=" +
            $"C:\\Users\\User\\Desktop\\FESB\\5. godina\\DIS\\Labovi\\MarusicAnte-hw-03\\WeatherStationAPI\\SQL\\WeatherStations.db";

        public bool CreateNewWeatherStation(WeatherStation weatherStation)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
                INSERT INTO WeatherStations (Name, Location, Temperature, WeatherState, Humidity, WindSpeed)
                VALUES ($name, $location, $temperature, $weatherState, $humidity, $windSpeed)";

            command.Parameters.AddWithValue("$name", weatherStation.Name);
            command.Parameters.AddWithValue("$location", weatherStation.Location);
            command.Parameters.AddWithValue("$temperature", weatherStation.Temperature);
            command.Parameters.AddWithValue("$weatherState", weatherStation.WeatherState);
            command.Parameters.AddWithValue("$humidity", weatherStation.Humidity);
            command.Parameters.AddWithValue("$windSpeed", weatherStation.WindSpeed);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected < 1)
            {
                return false;
            }

            return true;
        }   

        public bool DeleteWeatherStation(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
             DELETE FROM WeatherStations
             WHERE ID = $id";

            command.Parameters.AddWithValue("$id", id);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected < 1)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<WeatherStation> GetAllWeatherStations()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
     SELECT ID, Name, Location, Temperature, WeatherState, Humidity, WindSpeed FROM WeatherStations";

            using var reader = command.ExecuteReader();

            var results = new List<WeatherStation>();

            while (reader.Read())
            {
                var row = new WeatherStation
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Location = reader.GetString(2),
                    Temperature = reader.GetInt32(3),
                    WeatherState = reader.GetString(4),
                    Humidity = reader.GetInt32(5), 
                    WindSpeed = reader.GetInt32(6) 
                };

                results.Add(row);
            }

            return results;
        }

        public WeatherStation? GetWeatherStation(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
                @"SELECT ID, Name, Location, Temperature, WeatherState, Humidity, WindSpeed 
                  FROM WeatherStations
                  WHERE ID == $id";

            command.Parameters.AddWithValue("$id", id);

            using var reader = command.ExecuteReader();

            WeatherStation? result = null;

            if (reader.Read()) 
            {
                result = new WeatherStation
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Location = reader.GetString(2),
                    Temperature = reader.GetInt32(3),
                    WeatherState = reader.GetString(4),
                    Humidity = reader.GetInt32(5),
                    WindSpeed = reader.GetInt32(6)
                };
            }
            return result;
        }

        public bool UpdateWeatherStation(int id, WeatherStation weatherStation)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
                @"UPDATE WeatherStations
                  SET
                      Name = $name,
                      Location = $location,
                      Temperature = $temperature,
                      WeatherState = $weatherState,
                      Humidity = $humidity,
                      WindSpeed = $windSpeed
                  WHERE
                      ID == $id";

            command.Parameters.AddWithValue("$id", id);
            command.Parameters.AddWithValue("$name", weatherStation.Name);
            command.Parameters.AddWithValue("$location", weatherStation.Location);
            command.Parameters.AddWithValue("$temperature", weatherStation.Temperature);
            command.Parameters.AddWithValue("$weatherState", weatherStation.WeatherState);
            command.Parameters.AddWithValue("$humidity", weatherStation.Humidity);
            command.Parameters.AddWithValue("$windSpeed", weatherStation.WindSpeed);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected < 1)
            {
                return false;
            }
            return true;
        }
    }
}
