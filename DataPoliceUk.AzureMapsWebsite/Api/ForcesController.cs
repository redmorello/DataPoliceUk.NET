using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataPoliceUk.AzureMapsWebsite.Configuration;
using DataPoliceUk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace DataPoliceUk.AzureMapsWebsite.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForcesController : ControllerBase
    {
        private IMemoryCache _cache;
        private readonly IOptions<CustomConfig> _config;

        public ForcesController(IOptions<CustomConfig> config, IMemoryCache memoryCache)
        {
            _config = config;
            _cache = memoryCache;
        }

        // GET api/forces
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                if (!_cache.TryGetValue("ListOfForces", out List<Force> result))
                {
                    var client = new Client();
                    result = await client.GetForces();
                    
                    _cache.Set("ListOfForces", result, TimeSpan.FromMinutes(_config.Value.CacheMinutes));
                }
                
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
                if (!_cache.TryGetValue($"SpecificForce-{id}", out SpecificForce result))
                {
                    var client = new Client();
                    result = await client.GetForce(id);

                    _cache.Set($"SpecificForce-{id}", result, TimeSpan.FromMinutes(_config.Value.CacheMinutes));
                }
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
                if (!_cache.TryGetValue($"ForcePeople-{id}", out List<Person> result))
                {
                    var client = new Client();
                    result = await client.GetForcePeople(id);

                    _cache.Set($"ForcePeople-{id}", result, TimeSpan.FromMinutes(_config.Value.CacheMinutes));
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}