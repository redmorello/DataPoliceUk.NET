using DataPoliceUk;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DatePoliceUk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrimeCategoriesController : ControllerBase
    {
        // GET api/crime-categories?date=2011-08
        [HttpGet("{date}")]
        public async Task<IActionResult> Get(string date)
        {
            try
            {
                var client = new Client();
                var result = await client.GetCrimeCategories(date);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }
}
