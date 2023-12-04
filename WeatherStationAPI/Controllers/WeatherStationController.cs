/*
**********************************
* Author: Ante Marusic
* Project Task: Homework 3 - Weather Station API
**********************************
* Description:
*
*  Weather Station controller class implementing CRUD endpoints
*  Stores are stored in a list which can be manipulated using 
*  CRUD API endpoints given in this controller
*
**********************************
*/

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherStationAPI.Models.Domain;
using WeatherStationAPI.Repositories;

namespace WeatherStationAPI.Controllers
{
    [ApiController]
    public class WeatherStationController : ControllerBase
    {
        private readonly WeatherStationRepository m_weatherStationRepository;

        public WeatherStationController(WeatherStationRepository weatherStationRepository)
        {
            m_weatherStationRepository = weatherStationRepository;
        }

        /*
         * Create Operation: Create a weather station object
         */
        [HttpPost("/weatherstations/new")]
        public IActionResult PostNewWeatherStation([FromBody] WeatherStation weatherStation)
        {
            bool isSuccess = m_weatherStationRepository.CreateNewWeatherStation(weatherStation);

            if (isSuccess)
            {
                return Ok("Weather station is succesfully created ! \n");
            }
            else
            {
                return BadRequest("Error while creating a weather station ! \n");
            }
        }

        /*
         * Read Operation 1 - Get all stores
         */
        [HttpGet("/weatherstations/all")]
        public IActionResult GetAllWeatherStations()
        {
            return Ok(m_weatherStationRepository.GetAllWeatherStations());
        }

        /*
         * Read Operation 2 - Get the weather station with the specified ID
        */
        [HttpGet("/weatherstations/{id}")]
        public IActionResult GetWeatherStationById([FromRoute] int id)
        {
            var weatherStation = m_weatherStationRepository.GetWeatherStation(id);

            if (weatherStation is null)
            {
                return NotFound($"Could not find a weather station with ID = {id} \n");
            }
            else
            {
                return Ok(weatherStation);
            }
        }

        /*
         * Update Operation - Update the weather station with the specified ID
         */
        [HttpPost("/weatherstations/{id}")]
        public IActionResult UpdateWeatherStationById([FromRoute] int id, [FromBody] WeatherStation weatherStation)
        {
            if (m_weatherStationRepository.UpdateWeatherStation(id, weatherStation))
            {
                return Ok($"Successfully updated the weather station with ID = {id} \n");
            }
            else
            {
                return NotFound($"Could not find the weather station with ID = {id} \n");
            }
        }

        /*
         * Delete Operation - Delete the weather station with the specified ID
         */
        [HttpDelete("/weatherstations/{id}")]
        public IActionResult DeleteWeatherStationById([FromRoute] int id)
        {
            if (m_weatherStationRepository.DeleteWeatherStation(id))
            {
                return Ok($"Successfully deleted the weather station with ID = {id} \n");
            }
            else
            {
                return NotFound($"Could not find a weather station with ID = {id} \n");
            }
        }
    }
}
