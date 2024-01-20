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
using WeatherStationAPI.Filters;
using WeatherStationAPI.Logic;
using WeatherStationAPI.Controllers.DTO;


namespace WeatherStationAPI.Controllers
{
    [LogFilter]
    [ApiController]
    public class WeatherStationController : ControllerBase
    {
        
        private readonly IWeatherStationLogic _weatherStationLogic;
        public WeatherStationController(IWeatherStationLogic weatherStationLogic)
        {
            _weatherStationLogic = weatherStationLogic;
        }

        /*
         * Create Operation: Create a weather station object
         */
        [HttpPost("/weatherstations/new")]
        public IActionResult PostNewWeatherStation([FromBody] NewWeatherStationDTO weatherStation)
        {
            _weatherStationLogic.CreateNewWeatherStation(weatherStation.ToModel());

            return Ok("Weather station succesfully created.");
        }

        /*
         * Read Operation 1 - Get all weather stations
         */
        [HttpGet("/weatherstations/all")]
        public ActionResult<IEnumerable<WeatherStationInfoDTO>> GetAllWeatherStations()
        {
            return Ok(_weatherStationLogic.GetAllWeatherStations().Select(x => WeatherStationInfoDTO.FromModel(x)));
        }

        /*
         * Read Operation 2 - Get the weather station with the specified ID
        */
        [HttpGet("/weatherstations/{id}")]
        public ActionResult<WeatherStationInfoDTO> GetWeatherStationById([FromRoute] int id)
        {
            var weatherStation = _weatherStationLogic.GetWeatherStation(id);

            if (weatherStation == null)
            {
                return NotFound($"Could not find a weather station with ID = {id}");
            }
            else
            {
                return Ok(WeatherStationInfoDTO.FromModel(weatherStation));
            }
        }

        /*
         * Update Operation - Update the weather station with the specified ID
         */
        [HttpPost("/weatherstations/{id}")]
        public IActionResult UpdateWeatherStationById([FromRoute] int id, [FromBody] NewWeatherStationDTO weatherStation)
        {
            if (weatherStation is null)
            {
                return BadRequest("Wrong weather station format.");
            }

            var existingWeatherStation = _weatherStationLogic.GetWeatherStation(id);
            if(existingWeatherStation is null) 
            {
                return NotFound($"Could not find the store with ID = {id}");
            }

            _weatherStationLogic.UpdateWeatherStation(id, weatherStation.ToModel());

            return Ok();
        }

        /*
         * Delete Operation - Delete the weather station with the specified ID
         */
        [HttpDelete("/weatherstations/{id}")]
        public IActionResult DeleteWeatherStationById([FromRoute] int id)
        {
            var existingWeatherStation = _weatherStationLogic.GetWeatherStation(id);
            if(existingWeatherStation is null)
            {
                return NotFound($"Email with ID {id} not found.");
            }
            
            _weatherStationLogic.DeleteWeatherStation(id);
            
            return Ok();
        }
    }
}
