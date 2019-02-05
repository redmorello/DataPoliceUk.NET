using Newtonsoft.Json;

namespace DataPoliceUk.Models
{
    public class Neighbourhood
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
