using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Sygic.Maps.Clients.OptimizationApi.Model.Input
{
    [JsonConverter(typeof(CoordinatesStringConverter))]
    public struct Coordinates
    {
        public Coordinates(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public decimal Latitude { get; }
        public decimal Longitude { get; }

        public static Coordinates Parse(string value)
        {
            var coordinateParts = value.Split(',');
            var latitude = decimal.Parse(coordinateParts[0], CultureInfo.InvariantCulture);
            var longitude = decimal.Parse(coordinateParts[1], CultureInfo.InvariantCulture);

            return new Coordinates(latitude, longitude);
        }

        public override string ToString()
        {
            return FormattableString.Invariant($"{Latitude:F5},{Longitude:F5}");
        }
    }

    public class CoordinatesStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(string);
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) => Coordinates.Parse((string)reader.Value);
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => writer.WriteValue(value.ToString());
    }
}
