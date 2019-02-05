using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace DataPoliceUk.JsonConvertors
{
    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                CategoryConverter.Singleton,
                LocationSubtypeConverter.Singleton,
                LocationTypeConverter.Singleton,
                OutcomeStatusCategoryConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
