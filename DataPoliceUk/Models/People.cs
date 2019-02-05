using Newtonsoft.Json;

namespace DataPoliceUk.Models
{
    public class Person
    {
        [JsonProperty("bio")]
        public string Bio { get; set; }
        [JsonProperty("contact_details")]
        public ContactDetails ContactDetails { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("rank")]
        public string Rank { get; set; }
    }
}
