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
    public class StopAndSearchController : ControllerBase
    {
        private IMemoryCache _cache;
        private readonly IOptions<CustomConfig> _config;

        public StopAndSearchController(IOptions<CustomConfig> config, IMemoryCache memoryCache)
        {
            _config = config;
            _cache = memoryCache;
        }

        // GET api/stops-street?lat=52.629729&lng=-1.131592&date=2018-06
        [HttpGet("ByArea/{lat}/{lng}")]
        public async Task<IActionResult> GetStopAndSearchesByArea(string lat, string lng, string date)
        {
            try
            {
                if (!_cache.TryGetValue($"StopAndSearchByArea-{lat}-{lng}-{date}", out List<StopAndSearch> result))
                {
                    var client = new Client();
                    result = await client.GetStopAndSearchByArea(lat, lng, date);

                    _cache.Set($"StopAndSearchByArea-{lat}-{lng}-{date}", result, TimeSpan.FromMinutes(_config.Value.CacheMinutes));
                }
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // GET api/stops-street?poly=52.2,0.5:52.8,0.2:52.1,0.88&date=2018-06
        [HttpGet("ByPolyArea/{poly}")]
        public async Task<IActionResult> GetStopAndSearchesByPolyArea(string poly, string date)
        {
            try
            {
                if (!_cache.TryGetValue($"StopAndSearchByPolyArea-{poly}-{date}", out List<StopAndSearch> result))
                {
                    var client = new Client();
                    result = await client.GetStopAndSearchByPolyArea(poly, date);

                    _cache.Set($"StopAndSearchByPolyArea-{poly}-{date}", result, TimeSpan.FromMinutes(_config.Value.CacheMinutes));
                }
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // GET api/stops-at-location?location_id=883407&date=2017-01
        [HttpGet("ByLocation/{locationId}")]
        public async Task<IActionResult> GetStopAndSearchesByLocation(string locationId, string date)
        {
            try
            {
                if (!_cache.TryGetValue($"StopAndSearchByLocation-{locationId}-{date}", out List<StopAndSearch> result))
                {
                    var client = new Client();
                    result = await client.GetStopAndSearchByLocation(locationId, date);

                    _cache.Set($"StopAndSearchByLocation-{locationId}-{date}", result, TimeSpan.FromMinutes(_config.Value.CacheMinutes));
                }
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // GET api/stops-no-location?force=cleveland&date=2017-01
        [HttpGet("NoLocation/{forceId}")]
        public async Task<IActionResult> GetStopAndSearchesNoLocation(string forceId, string date)
        {
            try
            {
                if (!_cache.TryGetValue($"StopAndSearchNoLocation-{forceId}-{date}", out List<StopAndSearch> result))
                {
                    var client = new Client();
                    result = await client.GetStopAndSearchNoLocation(forceId, date);

                    _cache.Set($"StopAndSearchNoLocation-{forceId}-{date}", result, TimeSpan.FromMinutes(_config.Value.CacheMinutes));
                }
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // GET api/stops-force?force=avon-and-somerset&date=2017-01
        [HttpGet("ByForce/{forceId}")]
        public async Task<IActionResult> GetStopAndSearchesByForce(string forceId, string date)
        {
            try
            {
                if (!_cache.TryGetValue($"StopAndSearchByForce-{forceId}-{date}", out List<StopAndSearch> result))
                {
                    var client = new Client();
                    result = await client.GetStopAndSearchByForce(forceId, date);

                    _cache.Set($"StopAndSearchByForce-{forceId}-{date}", result, TimeSpan.FromMinutes(_config.Value.CacheMinutes));
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
