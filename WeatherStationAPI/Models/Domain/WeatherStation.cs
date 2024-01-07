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

        // Value of temperature
        public double Temperature { get; set; }

        // Value of humidity
        public double Humidity { get; set; }

        // Value of wind speed
        public double WindSpeed { get; set; }
    }
}
