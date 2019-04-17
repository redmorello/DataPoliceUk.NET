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
    public class NeighbourhoodsController : ControllerBase
    {
        private IMemoryCache _cache;
        private readonly IOptions<CustomConfig> _config;

        public NeighbourhoodsController(IOptions<CustomConfig> config, IMemoryCache memoryCache)
        {
            _config = config;
            _cache = memoryCache;
        }

        // GET api/neighbourhoods
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                if (!_cache.TryGetValue($"Neighbourhoods-{id}", out List<Neighbourhood> result))
                {
                    var client = new Client();
                    result = await client.GetNeighbourhoods(id);
                                        
                    _cache.Set($"Neighbourhoods-{id}", result, TimeSpan.FromMinutes(_config.Value.CacheMinutes));
                }
                
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
                if (!_cache.TryGetValue($"SpecificNeighbourhood-{forceId}-{id}", out SpecificNeighbourhood result))
                {
                    var client = new Client();
                    result = await client.GetNeighbourhood(forceId, id);

                    _cache.Set($"SpecificNeighbourhood-{forceId}-{id}", result, TimeSpan.FromMinutes(_config.Value.CacheMinutes));
                }
                
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
                if (!_cache.TryGetValue($"BoundaryLocations-{forceId}-{id}", out List<BoundaryLocation> result))
                {
                    var client = new Client();
                    result = await client.GetNeighbourhoodBoundary(forceId, id);

                    _cache.Set($"BoundaryLocations-{forceId}-{id}", result, TimeSpan.FromMinutes(_config.Value.CacheMinutes));
                }
                
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
                if (!_cache.TryGetValue($"NeighbourhoodPeople-{forceId}-{id}", out List<Person> result))
                {
                    var client = new Client();
                    result = await client.GetNeighbourhoodPeople(forceId, id);

                    _cache.Set($"NeighbourhoodPeople-{forceId}-{id}", result, TimeSpan.FromMinutes(_config.Value.CacheMinutes));
                }
                
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
                if (!_cache.TryGetValue($"NeighbourhoodEvents-{forceId}-{id}", out List<Event> result))
                {
                    var client = new Client();
                    result = await client.GetNeighbourhoodEvents(forceId, id);

                    _cache.Set($"NeighbourhoodEvents-{forceId}-{id}", result, TimeSpan.FromMinutes(_config.Value.CacheMinutes));
                }
                
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
                if (!_cache.TryGetValue($"NeighbourhoodPriorities-{forceId}-{id}", out List<Priority> result))
                {
                    var client = new Client();
                    result = await client.GetNeighbourhoodPriorities(forceId, id);

                    _cache.Set($"NeighbourhoodPriorities-{forceId}-{id}", result, TimeSpan.FromMinutes(_config.Value.CacheMinutes));
                }
                
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
                if (!_cache.TryGetValue($"NeighbourhoodByLocation-{lat}-{lng}", out NeighbourhoodResult result))
                {
                    var client = new Client();
                    result = await client.GetNeighbourhoodByLocation(lat, lng);

                    _cache.Set($"NeighbourhoodByLocation-{lat}-{lng}", result, TimeSpan.FromMinutes(_config.Value.CacheMinutes));
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
