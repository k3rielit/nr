using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LibNR {
    // Deserialization and serialization
    internal static class Converter {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore,
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
    internal class IntToBoolConverter : JsonConverter {
        public override bool CanConvert(Type t) => t == typeof(bool) || t == typeof(bool?);
        public override object ReadJson(JsonReader reader,Type t,object existingValue,JsonSerializer serializer) {
            if(reader.TokenType == JsonToken.Null) return false;
            var value = serializer.Deserialize<string>(reader);
            if(int.TryParse(value,out int i)) return i > 0;
            return false;
        }
        public override void WriteJson(JsonWriter writer,object untypedValue,JsonSerializer serializer) {
            if(untypedValue == null) serializer.Serialize(writer,false);
            else if(untypedValue is bool boolean) serializer.Serialize(writer,(boolean ? 1 : 0).ToString()); // serialization not tested
        }
        public static readonly IntToBoolConverter Singleton = new IntToBoolConverter();
    }
}
