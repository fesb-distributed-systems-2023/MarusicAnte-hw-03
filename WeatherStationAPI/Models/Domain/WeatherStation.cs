/*
 **********************************
 * Author: Ante Marusic
 * Project Task: Homework 3 - Weather Station API
 **********************************
 * Description:
 *  
 *  This file contains model which defines weather station class and it's properties.
 *
 **********************************
 */


namespace WeatherStationAPI.Models.Domain
{
    public class WeatherStation
    {
        // Unique ID
        public int Id { get; set; }

        // Weather Station name
        public string Name { get; set; }

        //  Weather Station location
        public string Location{ get; set; }

        // Wather state image
        public string Image { get; set; }

        // Value of temperature
        public int Temperature { get; set; }

        // Weather state
        public string WeatherState { get; set; }

        // Value of humidity
        public int Humidity { get; set; }

        // Value of wind speed
        public int WindSpeed { get; set; }
    }
}
