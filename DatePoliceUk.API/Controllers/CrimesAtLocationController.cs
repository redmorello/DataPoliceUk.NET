using DataPoliceUk;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DatePoliceUk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrimesAtLocationController : ControllerBase
    {
        // GET api/crimes-at-location?date=2017-02&location_id=884227
        [HttpGet("SpecificLocation/{date}/{locationId}")]
        public async Task<IActionResult> GetBySpecificLocation(string date, string locationId)
        {
            try
            {
                var client = new Client();
                var result = await client.GetCrimesAtSpecificLocation(date, locationId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // GET api/crimes-at-location?date=2017-02&lat=52.629729&lng=-1.131592
        [HttpGet("LatitudeLongitude/{date}/{lat}/{lng}")]
        public async Task<IActionResult> GetByLatitudeLongitude(string date, string lat, string lng)
        {
            try
            {
                var client = new Client();
                var result = await client.GetCrimesAtLocation(date, lat, lng);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
