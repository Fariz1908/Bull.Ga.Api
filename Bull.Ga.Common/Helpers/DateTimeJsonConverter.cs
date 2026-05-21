using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bull.Ga.Common.Helpers
{
    public class DateTimeJsonConverter : JsonConverter<DateTime>
    {
        private const string Format = "yyyy-MM-dd hh:mm:ss";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString()!, Format, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(Format, CultureInfo.InvariantCulture));
        }
    }
}
