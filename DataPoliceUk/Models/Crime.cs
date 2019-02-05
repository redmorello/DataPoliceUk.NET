using Newtonsoft.Json;

namespace DataPoliceUk.Models
{
    public class Crime
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("location_type")]
        public string LocationType { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("context")]
        public string Context { get; set; }

        [JsonProperty("outcome_status")]
        public OutcomeStatus OutcomeStatus { get; set; }

        [JsonProperty("persistent_id")]
        public string PersistentId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("location_subtype")]
        public string LocationSubtype { get; set; }

        [JsonProperty("month")]
        public string Month { get; set; }
    }
}
