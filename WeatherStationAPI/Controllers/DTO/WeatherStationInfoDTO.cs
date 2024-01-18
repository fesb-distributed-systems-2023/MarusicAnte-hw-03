using WeatherStationAPI.Models.Domain;

namespace WeatherStationAPI.Controllers.DTO
{
    public class WeatherStationInfoDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? Image { get; set; }
        public int Temperature { get; set; }
        public string? WeatherState { get; set; }
        public int Humidity { get; set; }
        public int WindSpeed { get; set; }

        public static WeatherStationInfoDTO FromModel(WeatherStation weatherStation)
        {
            return new WeatherStationInfoDTO
            {
                Id = weatherStation.Id,
                Name = weatherStation.Name,
                Location = weatherStation.Location,
                Image = weatherStation.Image,
                Temperature = weatherStation.Temperature,
                WeatherState = weatherStation.WeatherState,
                Humidity = weatherStation.Humidity,
                WindSpeed = weatherStation.WindSpeed,
            };
        }
    }
}
