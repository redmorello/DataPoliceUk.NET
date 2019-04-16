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
    public class CrimesStreetController : ControllerBase
    {
        private IMemoryCache _cache;
        private readonly IOptions<CustomConfig> _config;

        public CrimesStreetController(IOptions<CustomConfig> config, IMemoryCache memoryCache)
        {
            _config = config;
            _cache = memoryCache;
        }

        // GET api/crimes-street/all-crime?lat=52.629729&lng=-1.131592&date=2017-01
        /// <param name="id">Here is the description for ID.</param>
        [HttpGet("LatitudeLongitude/{id}/{lat}/{lng}/{date}")]
        public async Task<IActionResult> Get(string id, string lat, string lng, string date)
        {
            try
            {
                if (!_cache.TryGetValue($"StreetCrimeByLocation-{id}-{lat}-{lng}-{date}", out List<Crime> result))
                {
                    var client = new Client();
                    result = await client.GetStreetCrimeByLocation(id, lat, lng, date);

                    _cache.Set($"StreetCrimeByLocation-{id}-{lat}-{lng}-{date}", result, TimeSpan.FromMinutes(_config.Value.CacheMinutes));
                }
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // GET api/crimes-street/all-crime?poly=52.268,0.543:52.794,0.238:52.130,0.478&date=2017-01
        [HttpGet("CustomArea/{id}/{poly}/{date}")]
        public async Task<IActionResult> Get(string id, string poly, string date)
        {
            try
            {
                if (!_cache.TryGetValue($"StreetCrimeByPolyArea-{id}-{poly}-{date}", out List<Crime> result))
                {
                    var client = new Client();
                    result = await client.GetStreetCrimeByPolyArea(id, poly, date);

                    _cache.Set($"StreetCrimeByPolyArea-{id}-{poly}-{date}", result, TimeSpan.FromMinutes(_config.Value.CacheMinutes));
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
