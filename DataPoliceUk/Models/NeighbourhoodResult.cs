using Newtonsoft.Json;

namespace DataPoliceUk.Models
{
    public class NeighbourhoodResult
    {
        [JsonProperty("force")]
        public string Force { get; set; }
        [JsonProperty("neighbourhood")]
        public string Neighbourhood { get; set; }
    }
}
