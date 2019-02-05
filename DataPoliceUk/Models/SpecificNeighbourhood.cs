using Newtonsoft.Json;
using System.Collections.Generic;

namespace DataPoliceUk.Models
{
    public class SpecificNeighbourhood
    {
        [JsonProperty("url_force")]
        public string UrlForce { get; set; }
        [JsonProperty("contact_details")]
        public ContactDetails ContactDetails { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("links")]
        public List<Link> Links { get; set; }
        [JsonProperty("centre")]
        public Centre Centre { get; set; }
        [JsonProperty("locations")]
        public List<Location> Locations { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("population")]
        public string Population { get; set; }
    }
}
