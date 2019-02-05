using Newtonsoft.Json;

namespace DataPoliceUk.Models
{
    public class EngagementMethod
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("description")]
        public object Description { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
