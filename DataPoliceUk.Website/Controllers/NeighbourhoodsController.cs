using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DataPoliceUk.Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeighbourhoodsController : ControllerBase
    {
        // GET api/neighbourhoods/leicestershire
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var client = new Client();
                var result = await client.GetNeighbourhoods(id);
                return Ok(result.OrderBy(x=>x.Name));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // GET api/neighbourhoods/leicestershire/NC25
        [HttpGet("{forceId}/{id}")]
        public async Task<IActionResult> Get(string forceId, string id)
        {
            try
            {
                var client = new Client();
                var result = await client.GetNeighbourhood(forceId,id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // GET api/leicestershire/NC04/boundary
        [HttpGet("{forceId}/{id}/boundary")]
        public async Task<IActionResult> GetBoundary(string forceId, string id)
        {
            try
            {
                var client = new Client();
                var result = await client.GetNeighbourhoodBoundary(forceId, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}