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
    public class OutcomesAtLocationController : ControllerBase
    {
        private IMemoryCache _cache;
        private readonly IOptions<CustomConfig> _config;

        public OutcomesAtLocationController(IOptions<CustomConfig> config, IMemoryCache memoryCache)
        {
            _config = config;
            _cache = memoryCache;
        }

        // GET api/outcomes-at-location?date=2017-01&location_id=883498
        [HttpGet("SpecificLocation/{locationId}")]
        public async Task<IActionResult> GetBySpecificLocation(string locationId, string date)
        {
            try
            {
                if (!_cache.TryGetValue($"OutcomesAtSpecificLocation-{locationId}-{date}", out List<OutcomeAtLocation> result))
                {
                    var client = new Client();
                    result = await client.GetOutcomesAtSpecificLocation(locationId, date);

                    _cache.Set($"OutcomesAtSpecificLocation-{locationId}-{date}", result, TimeSpan.FromMinutes(_config.Value.CacheMinutes));
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // GET api/outcomes-at-location?date=2017-01&lat=52.629729&lng=-1.131592
        [HttpGet("LatitudeLongitude/{lat}/{lng}")]
        public async Task<IActionResult> GetByLatitudeLongitude(string lat, string lng, string date)
        {
            try
            {
                if (!_cache.TryGetValue($"OutcomesAtLocation-{lat}-{lng}-{date}", out List<OutcomeAtLocation> result))
                {
                    var client = new Client();
                    result = await client.GetOutcomesAtLocation(lat, lng, date);

                    _cache.Set($"OutcomesAtLocation-{lat}-{lng}-{date}", result, TimeSpan.FromMinutes(_config.Value.CacheMinutes));
                }
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // GET api/outcomes-at-location?date=2017-01&poly=52.268,0.543:52.794,0.238:52.130,0.478
        [HttpGet("CustomArea/{poly}")]
        public async Task<IActionResult> GetByCusomArea(string poly, string date)
        {
            try
            {
                if (!_cache.TryGetValue($"OutcomesAtCustomLocation-{poly}-{date}", out List<OutcomeAtLocation> result))
                {
                    var client = new Client();
                    result = await client.GetOutcomesAtCustomLocation(poly, date);

                    _cache.Set($"OutcomesAtCustomLocation-{poly}-{date}", result, TimeSpan.FromMinutes(_config.Value.CacheMinutes));
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
