using System;
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
    public class OutcomesForCrimeController : ControllerBase
    {
        private IMemoryCache _cache;
        private readonly IOptions<CustomConfig> _config;

        public OutcomesForCrimeController(IOptions<CustomConfig> config, IMemoryCache memoryCache)
        {
            _config = config;
            _cache = memoryCache;
        }

        // GET api/outcomes-for-crime/590d68b69228a9ff95b675bb4af591b38de561aa03129dc09a03ef34f537588c
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                if (!_cache.TryGetValue($"OutcomesForCrime-{id}", out OutcomesForCrime result))
                {
                    var client = new Client();
                    result = await client.GetOutcomesForCrime(id);

                    _cache.Set($"OutcomesForCrime-{id}", result, TimeSpan.FromMinutes(_config.Value.CacheMinutes));
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
