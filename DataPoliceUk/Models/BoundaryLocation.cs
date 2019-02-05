using Newtonsoft.Json;

namespace DataPoliceUk.Models
{
    public class BoundaryLocation
    {
        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }
    }
}
