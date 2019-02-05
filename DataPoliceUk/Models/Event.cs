using Newtonsoft.Json;
using System;

namespace DataPoliceUk.Models
{
    public class Event
    {
        [JsonProperty("contact_details")]
        public ContactDetails ContactDetails { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("start_date")]
        public DateTimeOffset StartDate { get; set; }

        [JsonProperty("end_date")]
        public DateTimeOffset EndDate { get; set; }
    }
}
