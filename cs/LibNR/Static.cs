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

    // For cases when 0 and 1 is used instead of false and true
    internal class IntToBoolConverter : JsonConverter {
        public override bool CanConvert(Type t) => t == typeof(bool) || t == typeof(bool?);
        public override object ReadJson(JsonReader reader,Type t,object? existingValue,JsonSerializer serializer) {
            if(reader.TokenType == JsonToken.Null) return false;
            var value = serializer.Deserialize<string>(reader);
            if(int.TryParse(value,out int i)) return i > 0;
            return false;
        }
        public override void WriteJson(JsonWriter writer,object? untypedValue,JsonSerializer serializer) {
            if(untypedValue == null) serializer.Serialize(writer,false);
            else if(untypedValue is bool boolean) serializer.Serialize(writer,(boolean ? 1 : 0).ToString()); // serialization not tested
        }
        public static readonly IntToBoolConverter Singleton = new();
    }

    // For cases where a number has a comma or dot
    // Usually occurs in PlayerProfile
    internal class FancyIntConverter : JsonConverter {
        public override bool CanConvert(Type t) => t == typeof(int) || t == typeof(int?);
        public override object ReadJson(JsonReader reader,Type t,object? existingValue,JsonSerializer serializer) {
            if(reader.TokenType == JsonToken.Null) return 0;
            var value = (serializer.Deserialize<string>(reader) ?? string.Empty).Replace(",",string.Empty).Replace(".",string.Empty);
            if(int.TryParse(value,out int i)) return i;
            return 0;
        }
        public override void WriteJson(JsonWriter writer,object? untypedValue,JsonSerializer serializer) {
            if(untypedValue == null) serializer.Serialize(writer,false);
            else if(untypedValue is int integer) serializer.Serialize(writer,integer.ToString()); // serialization not tested, writes normal number
        }
        public static readonly FancyIntConverter Singleton = new();
    }

    // For cases where a value can be a number and a boolean false (PlayerProfile.CrewId for example)
    // Keeping the number representing the boolean as 0
    internal class BoolOrIntToInt : JsonConverter {
        public override bool CanConvert(Type t) => t == typeof(int) || t == typeof(int?);
        public override object ReadJson(JsonReader reader,Type t,object? existingValue,JsonSerializer serializer) {
            if(reader.TokenType == JsonToken.Null) return 0;
            var value = serializer.Deserialize<string>(reader) ?? string.Empty;
            if(value == "false") return 0;
            else if(int.TryParse(value,out int i)) return i;
            return 0;
        }
        public override void WriteJson(JsonWriter writer,object? untypedValue,JsonSerializer serializer) {
            if(untypedValue == null) serializer.Serialize(writer,false);
            else if(untypedValue is int integer) serializer.Serialize(writer,integer.ToString()); // serialization not tested, only writes number
        }
        public static readonly BoolOrIntToInt Singleton = new();
    }
}
