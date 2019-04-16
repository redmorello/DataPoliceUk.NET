using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DataPoliceUk.AzureMapsWebsite.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StopAndSearchController : ControllerBase
    {
        // GET api/stops-street?lat=52.629729&lng=-1.131592&date=2018-06
        [HttpGet("ByArea/{lat}/{lng}")]
        public async Task<IActionResult> GetStopAndSearchesByArea(string lat, string lng, string date)
        {
            try
            {
                var client = new Client();
                var result = await client.GetStopAndSearchByArea(lat, lng, date);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // GET api/stops-street?poly=52.2,0.5:52.8,0.2:52.1,0.88&date=2018-06
        [HttpGet("ByPolyArea/{poly}")]
        public async Task<IActionResult> GetStopAndSearchesByPolyArea(string poly, string date)
        {
            try
            {
                var client = new Client();
                var result = await client.GetStopAndSearchByPolyArea(poly, date);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // GET api/stops-at-location?location_id=883407&date=2017-01
        [HttpGet("ByLocation/{locationId}")]
        public async Task<IActionResult> GetStopAndSearchesByLocation(string locationId, string date)
        {
            try
            {
                var client = new Client();
                var result = await client.GetStopAndSearchByLocation(locationId, date);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // GET api/stops-no-location?force=cleveland&date=2017-01
        [HttpGet("NoLocation/{forceId}")]
        public async Task<IActionResult> GetStopAndSearchesNoLocation(string forceId, string date)
        {
            try
            {
                var client = new Client();
                var result = await client.GetStopAndSearchNoLocation(forceId, date);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // GET api/stops-force?force=avon-and-somerset&date=2017-01
        [HttpGet("ByForce/{forceId}")]
        public async Task<IActionResult> GetStopAndSearchesByForce(string forceId, string date)
        {
            try
            {
                var client = new Client();
                var result = await client.GetStopAndSearchByForce(forceId, date);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
