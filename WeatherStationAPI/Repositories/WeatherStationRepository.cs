/*
**********************************
* Author: Ante Marusic
* Project Task: Homework 3 - Weather Station
**********************************
* Description:
*
*  It is a class that has a list of all weather stations and 
*  implements CRUD operations from IStoreRepository interface
*
**********************************
*/

using WeatherStationAPI.Models.Domain;
using WeatherStationAPI.Repositories.Interfaces;

public class WeatherStationRepository : IWeatherStationRepository
{
    private readonly ICollection<WeatherStation> m_lstWeatherStation;
    private readonly object m_lock = new object();
    private int m_oIdCount;

    public WeatherStationRepository()
    {
        m_lstWeatherStation = new List<WeatherStation>();
        m_oIdCount = 0;
    }

    private int GenerateId()
    {
        lock (m_lock)
        {
            m_oIdCount++;
        }

        return m_oIdCount;
    }

    public bool CreateNewWeatherStation(WeatherStation weatherStation)
    {
        weatherStation.Id = GenerateId();

        lock (m_lock)
        {
            m_lstWeatherStation.Add(weatherStation);
        }

        return true;
    }

    public bool DeleteWeatherStation(int id)
    {
        var itemToDelete = m_lstWeatherStation.FirstOrDefault(ws => ws.Id == id);
        if (itemToDelete == null)
        {
            return false;
        }

        lock (m_lock)
        {
            m_lstWeatherStation.Remove(itemToDelete);
        }

        return true;
    }

    public WeatherStation? GetWeatherStation(int id)
    {
        return m_lstWeatherStation.FirstOrDefault(ws => ws.Id == id);
    }

    public IEnumerable<WeatherStation> GetAllWeatherStations()
    {
        return m_lstWeatherStation;
    }

    public bool UpdateWeatherStation(int id, WeatherStation newWeatherStation)
    {
        lock (m_lock)
        {
            var curWeatherStation = m_lstWeatherStation.FirstOrDefault(ws => ws.Id == id);

            if (curWeatherStation == null)
            {
                return false;
            }

            curWeatherStation.Id = newWeatherStation.Id;
            curWeatherStation.Name = newWeatherStation.Name;
            curWeatherStation.Location = newWeatherStation.Location;
            curWeatherStation.Temperature = newWeatherStation.Temperature;
            curWeatherStation.Humidity = newWeatherStation.Humidity;
            curWeatherStation.WindSpeed = newWeatherStation.WindSpeed;
        }

        return true;
    }
}
