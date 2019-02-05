using Newtonsoft.Json;

namespace DataPoliceUk.Models
{
    public class CrimeLastUpdated
    {
        [JsonProperty("date")]
        public string Date { get; set; }
    }
}
