using Newtonsoft.Json;

namespace DataPoliceUk.Models
{
    public class OutcomeAtLocation
    {
        [JsonProperty("category")]
        public Category Category { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("person_id")]
        public object PersonId { get; set; }

        [JsonProperty("crime")]
        public Crime Crime { get; set; }
    }
}
