using Newtonsoft.Json;
using System.Collections.Generic;

namespace DataPoliceUk.Models
{
    public class Availability
    {
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("stop-and-search")]
        public List<string> StopAndSearch { get; set; }
}
}
