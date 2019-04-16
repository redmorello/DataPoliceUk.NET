using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DataPoliceUk.AzureMapsWebsite.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutcomesForCrimeController : ControllerBase
    {
        // GET api/outcomes-for-crime/590d68b69228a9ff95b675bb4af591b38de561aa03129dc09a03ef34f537588c
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var client = new Client();
                var result = await client.GetOutcomesForCrime(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
