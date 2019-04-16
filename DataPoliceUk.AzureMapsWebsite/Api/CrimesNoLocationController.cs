using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DataPoliceUk.AzureMapsWebsite.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrimesNoLocationController : ControllerBase
    {
        // GET api/crimes-no-location?category=all-crime&force=leicestershire&date=2017-02
        [HttpGet("{category}/{force}")]
        public async Task<IActionResult> Get(string category, string force, string date)
        {
            try
            {
                var client = new Client();
                var result = await client.GetCrimesNoLocation(category, force, date);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
