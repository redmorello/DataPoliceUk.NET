using Newtonsoft.Json;
using System;

namespace DataPoliceUk.Models
{
    public class StopAndSearch
    {
        [JsonProperty("age_range")]
        public string AgeRange { get; set; }

        [JsonProperty("outcome")]
        public string Outcome { get; set; }

        [JsonProperty("involved_person")]
        public bool InvolvedPerson { get; set; }

        [JsonProperty("self_defined_ethnicity")]
        public string SelfDefinedEthnicity { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("legislation")]
        public string Legislation { get; set; }

        [JsonProperty("outcome_linked_to_object_of_search")]
        public bool? OutcomeLinkedToObjectOfSearch { get; set; }

        [JsonProperty("datetime")]
        public DateTimeOffset Datetime { get; set; }

        [JsonProperty("removal_of_more_than_outer_clothing")]
        public bool? RemovalOfMoreThanOuterClothing { get; set; }

        [JsonProperty("outcome_object")]
        public OutcomeObject OutcomeObject { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("operation")]
        public object Operation { get; set; }

        [JsonProperty("officer_defined_ethnicity")]
        public string OfficerDefinedEthnicity { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("operation_name")]
        public object OperationName { get; set; }

        [JsonProperty("object_of_search")]
        public string ObjectOfSearch { get; set; }
    }
}
