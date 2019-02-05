using Newtonsoft.Json;

namespace DataPoliceUk.Models
{
    public class OutcomeStatus
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }
    }
}
