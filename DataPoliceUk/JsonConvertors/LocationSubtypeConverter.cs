using DataPoliceUk.Enums;
using Newtonsoft.Json;
using System;

namespace DataPoliceUk.JsonConvertors
{
    internal class LocationSubtypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(LocationSubtype) || t == typeof(LocationSubtype?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "":
                    return LocationSubtype.Empty;
                case "STATION":
                    return LocationSubtype.Station;
            }
            throw new Exception("Cannot unmarshal type LocationSubtype");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (LocationSubtype)untypedValue;
            switch (value)
            {
                case LocationSubtype.Empty:
                    serializer.Serialize(writer, "");
                    return;
                case LocationSubtype.Station:
                    serializer.Serialize(writer, "STATION");
                    return;
            }
            throw new Exception("Cannot marshal type LocationSubtype");
        }

        public static readonly LocationSubtypeConverter Singleton = new LocationSubtypeConverter();
    }
}
