using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DataPoliceUk.AzureMapsWebsite.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityController : ControllerBase
    {
        // GET api/availability
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var client = new Client();
                var result = await client.GetAvailability();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
