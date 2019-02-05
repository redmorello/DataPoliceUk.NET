using Newtonsoft.Json;

namespace DataPoliceUk.Models
{
    public class ContactDetails
    {
        [JsonProperty("twitter")]
        public string Twitter { get; set; }
    }
}
