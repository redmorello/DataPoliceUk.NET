using Newtonsoft.Json;

namespace DataPoliceUk.Models
{
    public class CategoryClass
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
