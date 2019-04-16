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
    public class CrimesNoLocationController : ControllerBase
    {
        private IMemoryCache _cache;
        private readonly IOptions<CustomConfig> _config;

        public CrimesNoLocationController(IOptions<CustomConfig> config, IMemoryCache memoryCache)
        {
            _config = config;
            _cache = memoryCache;
        }

        // GET api/crimes-no-location?category=all-crime&force=leicestershire&date=2017-02
        [HttpGet("{category}/{force}")]
        public async Task<IActionResult> Get(string category, string force, string date)
        {
            try
            {
                if (!_cache.TryGetValue($"CrimesNoLocation-{category}-{force}-{date}", out List<CrimesNoLocation> result))
                {
                    var client = new Client();
                    result = await client.GetCrimesNoLocation(category, force, date);

                    _cache.Set($"CrimesNoLocation-{category}-{force}-{date}", result, TimeSpan.FromMinutes(_config.Value.CacheMinutes));
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
