using WeatherStationAPI.Models.Domain;

namespace WeatherStationAPI.Controllers.DTO
{
    public class NewWeatherStationDTO
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
        public int Temperature { get; set; }
        public string WeatherState { get; set; }
        public int Humidity { get; set; }
        public int WindSpeed { get; set; }

        public WeatherStation ToModel()
        {
            return new WeatherStation
            {
                Id = -1,
                Name = Name,
                Location = Location,
                Temperature = Temperature,
                WeatherState = WeatherState,
                Humidity = Humidity,
                WindSpeed = WindSpeed
            };
        }
    }
}
