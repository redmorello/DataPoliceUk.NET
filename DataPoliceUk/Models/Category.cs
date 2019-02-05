using Newtonsoft.Json;

namespace DataPoliceUk.Models
{
    public class Category
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
