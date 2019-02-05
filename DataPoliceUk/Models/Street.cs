using Newtonsoft.Json;

namespace DataPoliceUk.Models
{
    public class Street
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
