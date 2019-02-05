using DataPoliceUk;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DatePoliceUk.API.Controllers
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
