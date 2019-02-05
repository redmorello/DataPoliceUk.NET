using DataPoliceUk;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DatePoliceUk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeighbourhoodsController : ControllerBase
    {
        // GET api/neighbourhoods
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var client = new Client();
                var result = await client.GetNeighbourhoods(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // GET api/neighbourhoods
        [HttpGet("{forceId}/{id}")]
        public async Task<IActionResult> Get(string forceId, string id)
        {
            try
            {
                var client = new Client();
                var result = await client.GetNeighbourhood(forceId, id);
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

        // GET api/leicestershire/NC04/people
        [HttpGet("{forceId}/{id}/people")]
        public async Task<IActionResult> GetNeighbourhoodPeople(string forceId, string id)
        {
            try
            {
                var client = new Client();
                var result = await client.GetNeighbourhoodPeople(forceId, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // GET api/leicestershire/NC04/events
        [HttpGet("{forceId}/{id}/events")]
        public async Task<IActionResult> GetNeighbourhoodEvents(string forceId, string id)
        {
            try
            {
                var client = new Client();
                var result = await client.GetNeighbourhoodEvents(forceId, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // GET api/leicestershire/NC04/priorities
        [HttpGet("{forceId}/{id}/priorities")]
        public async Task<IActionResult> GetNeighbourhoodPriorities(string forceId, string id)
        {
            try
            {
                var client = new Client();
                var result = await client.GetNeighbourhoodPriorities(forceId, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // GET api/locate-neighbourhood?q=51.500617,-0.124629
        [HttpGet("locate-neighbourhood/{lat}/{lng}")]
        public async Task<IActionResult> GetNeighbourhoodByLocation(string lat, string lng)
        {
            try
            {
                var client = new Client();
                var result = await client.GetNeighbourhoodByLocation(lat, lng);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
