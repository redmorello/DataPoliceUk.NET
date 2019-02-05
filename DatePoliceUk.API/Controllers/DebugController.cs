using DataPoliceUk;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DatePoliceUk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebugController : ControllerBase
    {
        // GET api/debug/ApiFreeResponse
        [HttpGet("ApiFreeResponse")]
        public async Task<IActionResult> GetApiFreeResponse(string apiUrl)
        {
            try
            {
                var client = new Client();
                var result = await client.GetApiFreeResponseAsync(apiUrl);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // GET api/debug/CrimeLastUpdated
        [HttpGet]
        [Route("CrimeLastUpdated")]
        public async Task<IActionResult> GetCrimeLastUpdated()
        {
            try
            {
                var client = new Client();
                var result = await client.GetCrimeLastUpdated();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
