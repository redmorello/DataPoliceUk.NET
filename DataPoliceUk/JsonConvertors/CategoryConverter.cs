using DataPoliceUk.Enums;
using Newtonsoft.Json;
using System;

namespace DataPoliceUk.JsonConvertors
{
    internal class CategoryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Category) || t == typeof(Category?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "anti-social-behaviour":
                    return Category.AntiSocialBehaviour.ToString();
                case "bicycle-theft":
                    return Category.BicycleTheft;
                case "burglary":
                    return Category.Burglary;
                case "criminal-damage-arson":
                    return Category.CriminalDamageArson;
                case "drugs":
                    return Category.Drugs;
                case "other-crime":
                    return Category.OtherCrime;
                case "other-theft":
                    return Category.OtherTheft;
                case "possession-of-weapons":
                    return Category.PossessionOfWeapons;
                case "public-order":
                    return Category.PublicOrder;
                case "robbery":
                    return Category.Robbery;
                case "shoplifting":
                    return Category.Shoplifting;
                case "theft-from-the-person":
                    return Category.TheftFromThePerson;
                case "vehicle-crime":
                    return Category.VehicleCrime;
                case "violent-crime":
                    return Category.ViolentCrime;
            }
            throw new Exception("Cannot unmarshal type Category");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Category)untypedValue;
            switch (value)
            {
                case Category.AntiSocialBehaviour:
                    serializer.Serialize(writer, "anti-social-behaviour");
                    return;
                case Category.BicycleTheft:
                    serializer.Serialize(writer, "bicycle-theft");
                    return;
                case Category.Burglary:
                    serializer.Serialize(writer, "burglary");
                    return;
                case Category.CriminalDamageArson:
                    serializer.Serialize(writer, "criminal-damage-arson");
                    return;
                case Category.Drugs:
                    serializer.Serialize(writer, "drugs");
                    return;
                case Category.OtherCrime:
                    serializer.Serialize(writer, "other-crime");
                    return;
                case Category.OtherTheft:
                    serializer.Serialize(writer, "other-theft");
                    return;
                case Category.PossessionOfWeapons:
                    serializer.Serialize(writer, "possession-of-weapons");
                    return;
                case Category.PublicOrder:
                    serializer.Serialize(writer, "public-order");
                    return;
                case Category.Robbery:
                    serializer.Serialize(writer, "robbery");
                    return;
                case Category.Shoplifting:
                    serializer.Serialize(writer, "shoplifting");
                    return;
                case Category.TheftFromThePerson:
                    serializer.Serialize(writer, "theft-from-the-person");
                    return;
                case Category.VehicleCrime:
                    serializer.Serialize(writer, "vehicle-crime");
                    return;
                case Category.ViolentCrime:
                    serializer.Serialize(writer, "violent-crime");
                    return;
            }
            throw new Exception("Cannot marshal type Category");
        }

        public static readonly CategoryConverter Singleton = new CategoryConverter();
    }
}
