/*
**********************************
* Author: Ante Marusic
* Project Task: Homework 3 - Weather Station API
**********************************
* Description:
*  
*  Interface dictating which CRUD operations for weather stations 
*  need to be implemented
*
**********************************
*/

using System.Collections.Generic;
using WeatherStationAPI.Models.Domain;

namespace WeatherStationAPI.Repositories.Interfaces
{
    public interface IWeatherStationRepository
    {
        bool CreateNewWeatherStation(WeatherStation weatherStation);

        IEnumerable<WeatherStation> GetAllWeatherStations();

        WeatherStation? GetWeatherStation(int id);

        bool UpdateWeatherStation(int id, WeatherStation weatherStation);

        bool DeleteWeatherStation(int id);
    }
}
