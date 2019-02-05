using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DataPoliceUk.Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForcesController : ControllerBase
    {
        // GET api/forces
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var client = new Client();
                var result = await client.GetForces();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // GET api/forces/leicestershire
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var client = new Client();
                var result = await client.GetForce(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // GET api/forces/leicestershire/people
        [HttpGet("{id}/people")]
        public async Task<IActionResult> GetPeople(string id)
        {
            try
            {
                var client = new Client();
                var result = await client.GetForcePeople(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}