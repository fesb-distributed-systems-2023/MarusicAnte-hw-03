using WeatherStationAPI.Models.Domain;

namespace WeatherStationAPI.Logic
{
    public interface IWeatherStationLogic
    {
        void CreateNewWeatherStation(WeatherStation? weatherStation);
        void DeleteWeatherStation(int id);
        IEnumerable<WeatherStation> GetAllWeatherStations();
        WeatherStation? GetWeatherStation(int id);
        void UpdateWeatherStation(int id, WeatherStation? weatherStation);
    }
}