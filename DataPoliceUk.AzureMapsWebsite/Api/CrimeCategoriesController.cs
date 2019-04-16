using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DataPoliceUk.AzureMapsWebsite.Api
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
