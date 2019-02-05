using Newtonsoft.Json;
using System.Collections.Generic;

namespace DataPoliceUk.Models
{
    public class SpecificForce
    {
        [JsonProperty("description")]
        public object Description { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("engagement_methods")]
        public List<EngagementMethod> EngagementMethods { get; set; }
        [JsonProperty("telephone")]
        public string Telephone { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
