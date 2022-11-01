using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace MessageMedia.Messages.Models
{
    public class NumberTypeConverter:JsonConverter
    {
        private readonly StringEnumConverter _stringEnumConverter;

        public NumberTypeConverter()
        {
            _stringEnumConverter = new StringEnumConverter();
        }    

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null)
            {
                _stringEnumConverter.WriteJson(writer, value, serializer);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return _stringEnumConverter.ReadJson(reader, objectType, existingValue, serializer);
        }

        public override bool CanConvert(Type objectType)
        {
            return _stringEnumConverter.CanConvert(objectType);
        }
    }
}