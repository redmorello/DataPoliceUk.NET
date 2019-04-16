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
    public class CrimesAtLocationController : ControllerBase
    {
        private IMemoryCache _cache;
        private readonly IOptions<CustomConfig> _config;

        public CrimesAtLocationController(IOptions<CustomConfig> config, IMemoryCache memoryCache)
        {
            _config = config;
            _cache = memoryCache;
        }

        // GET api/crimes-at-location?date=2017-02&location_id=884227
        [HttpGet("SpecificLocation/{date}/{locationId}")]
        public async Task<IActionResult> GetBySpecificLocation(string date, string locationId)
        {
            try
            {
                if (!_cache.TryGetValue($"CrimesAtSpecificLocation-{date}-{locationId}", out List<CrimeAtLocation> result))
                {
                    var client = new Client();
                    result = await client.GetCrimesAtSpecificLocation(date, locationId);

                    _cache.Set($"CrimesAtSpecificLocation-{date}-{locationId}", result, TimeSpan.FromMinutes(_config.Value.CacheMinutes));
                }
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // GET api/crimes-at-location?date=2017-02&lat=52.629729&lng=-1.131592
        [HttpGet("LatitudeLongitude/{date}/{lat}/{lng}")]
        public async Task<IActionResult> GetByLatitudeLongitude(string date, string lat, string lng)
        {
            try
            {
                if (!_cache.TryGetValue($"CrimesAtLocation-{date}-{lat}-{lng}", out List<CrimeAtLocation> result))
                {
                    var client = new Client();
                    result = await client.GetCrimesAtLocation(date, lat, lng);

                    _cache.Set($"CrimesAtLocation-{date}-{lat}-{lng}", result, TimeSpan.FromMinutes(_config.Value.CacheMinutes));
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
