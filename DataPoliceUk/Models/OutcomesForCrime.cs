using Newtonsoft.Json;
using System.Collections.Generic;

namespace DataPoliceUk.Models
{
    public class OutcomesForCrime
    {
        [JsonProperty("outcomes")]
        public List<Outcome> Outcomes { get; set; }

        [JsonProperty("crime")]
        public Crime Crime { get; set; }
    }
}
