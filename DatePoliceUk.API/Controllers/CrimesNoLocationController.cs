using DataPoliceUk;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DatePoliceUk.API.Controllers
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
