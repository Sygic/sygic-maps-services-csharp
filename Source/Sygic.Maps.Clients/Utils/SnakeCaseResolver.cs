using System.Text.RegularExpressions;
using Newtonsoft.Json.Serialization;

namespace Sygic.Maps.Clients.Utils
{
    public class SnakeCaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return GetSnakeCase(propertyName);
        }

        private static string GetSnakeCase(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            return Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLowerInvariant();
        }
    }
}
