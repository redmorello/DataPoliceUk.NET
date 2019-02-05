using Newtonsoft.Json;

namespace DataPoliceUk.Models
{
    public class Location
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("longitude")]
        public string Longitude { get; set; }
        [JsonProperty("postcode")]
        public string Postcode { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("latitude")]
        public string Latitude { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("description")]
        public object Description { get; set; }
        [JsonProperty("street")]
        public Street Street { get; set; }
    }
}
