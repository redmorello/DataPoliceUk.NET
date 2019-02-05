using DataPoliceUk;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DatePoliceUk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutcomesAtLocationController : ControllerBase
    {
        // GET api/outcomes-at-location?date=2017-01&location_id=883498
        [HttpGet("SpecificLocation/{locationId}")]
        public async Task<IActionResult> GetBySpecificLocation(string locationId, string date)
        {
            try
            {
                var client = new Client();
                var result = await client.GetOutcomesAtSpecificLocation(locationId, date);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // GET api/outcomes-at-location?date=2017-01&lat=52.629729&lng=-1.131592
        [HttpGet("LatitudeLongitude/{lat}/{lng}")]
        public async Task<IActionResult> GetByLatitudeLongitude(string lat, string lng, string date)
        {
            try
            {
                var client = new Client();
                var result = await client.GetOutcomesAtLocation(lat, lng, date);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // GET api/outcomes-at-location?date=2017-01&poly=52.268,0.543:52.794,0.238:52.130,0.478
        [HttpGet("CustomArea/{poly}")]
        public async Task<IActionResult> GetByCusomArea(string poly, string date)
        {
            try
            {
                var client = new Client();
                var result = await client.GetOutcomesAtCustomLocation(poly, date);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
