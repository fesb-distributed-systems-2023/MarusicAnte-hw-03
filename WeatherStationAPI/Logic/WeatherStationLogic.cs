using WeatherStationAPI.Repositories.Interfaces;
using WeatherStationAPI.Configuration;
using WeatherStationAPI.Exceptions;
using WeatherStationAPI.Models.Domain;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;

namespace WeatherStationAPI.Logic
{
    public class WeatherStationLogic : IWeatherStationLogic
    {
        private readonly IWeatherStationRepository _wsRepository;
        private readonly ValidationConfiguration _validation;
        public WeatherStationLogic(IWeatherStationRepository wsRepository, IOptions<ValidationConfiguration> configuration)
        {
            _wsRepository = wsRepository;
            _validation = configuration.Value;
        }

        private void ValidateNameField(string name)
        {
            if (name is null)
            {
                throw new UserErrorMessage("Name field cannot be empty.");
            }

            if (!Regex.IsMatch(name, _validation.IsTextOnlyRegex))
            {
                throw new UserErrorMessage("Name field must contain only letters.");
            }

            if (name.Length > _validation.NameMaxcharacters)
            {
                throw new UserErrorMessage("Name field too long");
            }
        }

        private void ValidateLocationField(string location)
        {
            if (location is null)
            {
                throw new UserErrorMessage("Location field cannot be empty.");
            }

            if (location.Length > _validation.LocationMaxCharacters)
            {
                throw new UserErrorMessage($"Location field too long.");
            }

            if (!Regex.IsMatch(location, _validation.LocationRegex))
            {
                throw new UserErrorMessage("Invalid location format. It can contain letters, numbers, and commas.");
            }
        }


        private void ValidateTemperatureField(int temperature)
        {
            if (temperature.ToString() is null)
            {
                throw new UserErrorMessage("Temperature field cannot be empty.");
            }

            if (!Regex.IsMatch(temperature.ToString(), _validation.IsIntegerNumberRegex))
            {
                throw new UserErrorMessage("Invalid temperature format. Please enter a valid integer.");
            }

            if (temperature < -50 || temperature > 100)
            {
                throw new UserErrorMessage("Temperature cannot be less than -50 and greater than 100.");
            }
        }

        private void ValidateWeatherStateField(string? weatherState)
        {
            if (weatherState is null)
            {
                throw new UserErrorMessage("Weather state field cannot be empty.");
            }

            if (!Regex.IsMatch(weatherState, _validation.IsTextOnlyRegex))
            {
                throw new UserErrorMessage("Weather state field only can contain string.");
            }

            if (weatherState.Length > _validation.WeatherStateMaxCharacters)
            {
                throw new UserErrorMessage("Weather state field too long");
            }
        }

        private void ValidateHumidityField(int humidity)
        {
            if (humidity.ToString() is null)
            {
                throw new UserErrorMessage("Humidity field cannot be empty.");
            }

            if (humidity.ToString().Length > 4)
            {
                throw new UserErrorMessage("Humidity field too long.");
            }

            if (!Regex.IsMatch(humidity.ToString(), _validation.IsIntegerNumberRegex))
            {
                throw new UserErrorMessage("Humidity must be a integer number.");
            }
        }

        private void ValidateWindSpeedField(int windSpeed)
        {
            if (windSpeed.ToString() is null)
            {
                throw new UserErrorMessage("Wind speed field cannot be empty.");
            }

            if (windSpeed.ToString().Length > 4)
            {
                throw new UserErrorMessage("Wind speed field too long.");
            }

            if (!Regex.IsMatch(windSpeed.ToString(), _validation.IsIntegerNumberRegex))
            {
                throw new UserErrorMessage("Wind speed must be integer number.");
            }
        }

        public void CreateNewWeatherStation(WeatherStation? weatherStation)
        {
            if (weatherStation == null)
            {
                throw new UserErrorMessage("Cannot create a new weather station. " +
                                           "No weather station specified or the weather " +
                                           "station is invalid");
            }

            weatherStation.Id = -1;
            ValidateNameField(weatherStation.Name);
            ValidateLocationField(weatherStation.Location);
            ValidateTemperatureField(weatherStation.Temperature);
            ValidateWeatherStateField(weatherStation.WeatherState);
            ValidateHumidityField(weatherStation.Humidity);

            _wsRepository.CreateNewWeatherStation(weatherStation);
        }

        public void UpdateWeatherStation(int id, WeatherStation? weatherStation)
        {
            if (weatherStation is null)
            {
                throw new UserErrorMessage("Cannot update weather station.  All fields must be entered correctly.");
            }

            weatherStation.Id = -1;
            ValidateNameField(weatherStation.Name);
            ValidateLocationField(weatherStation.Location);
            ValidateTemperatureField(weatherStation.Temperature);
            ValidateWeatherStateField(weatherStation.WeatherState);
            ValidateHumidityField(weatherStation.Humidity);

            _wsRepository.UpdateWeatherStation(id, weatherStation);
        }

        public void DeleteWeatherStation(int id)
        {
            _wsRepository.DeleteWeatherStation(id);
        }

        public WeatherStation? GetWeatherStation(int id)
        {
            return _wsRepository.GetWeatherStation(id);
        }

        public IEnumerable<WeatherStation> GetAllWeatherStations()
        {
            return _wsRepository.GetAllWeatherStations();
        }
    }
}
