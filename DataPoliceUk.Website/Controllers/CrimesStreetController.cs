using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DataPoliceUk.Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrimesStreetController : ControllerBase
    {
        // GET api/crimes-street/all-crime?lat=52.629729&lng=-1.131592&date=2017-01
        /// <param name="id">Here is the description for ID.</param>
        [HttpGet("LatitudeLongitude/{id}/{lat}/{lng}/{date}")]
        public async Task<IActionResult> Get(string id, string lat, string lng, string date)
        {
            try
            {
                var client = new Client();
                var result = await client.GetStreetCrimeByLocation(id, lat, lng, date);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}