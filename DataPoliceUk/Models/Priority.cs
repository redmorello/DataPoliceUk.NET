using Newtonsoft.Json;
using System;

namespace DataPoliceUk.Models
{
    public class Priority
    {
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("issue-date")]
        public DateTimeOffset IssueDate { get; set; }

        [JsonProperty("action-date")]
        public DateTimeOffset? ActionDate { get; set; }

        [JsonProperty("issue")]
        public string Issue { get; set; }
    }
}
