using DataPoliceUk.Enums;
using Newtonsoft.Json;
using System;

namespace DataPoliceUk.JsonConvertors
{
    internal class LocationTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(LocationType) || t == typeof(LocationType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "BTP":
                    return LocationType.Btp;
                case "Force":
                    return LocationType.Force;
            }
            throw new Exception("Cannot unmarshal type LocationType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (LocationType)untypedValue;
            switch (value)
            {
                case LocationType.Btp:
                    serializer.Serialize(writer, "BTP");
                    return;
                case LocationType.Force:
                    serializer.Serialize(writer, "Force");
                    return;
            }
            throw new Exception("Cannot marshal type LocationType");
        }

        public static readonly LocationTypeConverter Singleton = new LocationTypeConverter();
    }
}
