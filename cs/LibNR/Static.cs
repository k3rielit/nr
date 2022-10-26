using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LibNR {
    public struct Activity {
        public const string All = "all";
        public const string Race = "race";
        public const string Join = "join";
        public const string Leave = "leave";
        public const string Drop = "sb";
    }

    public class GameHashes {
        public static readonly Dictionary<int, string> Powerups = new() {
            [-1681514783] = "Nitrous",
            [2236629] = "Slingshot",
            [957701799] = "Ready",
            [1805681994] = "Juggernaut",
            // todo
        };
        public static readonly Dictionary<int, string> CarClasses = new() {
            // to do
        };
    }

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

    // Extracts a number from any string by discarding any non-digit characters, then parsing it
    internal class IntExtract : JsonConverter {
        public override bool CanConvert(Type t) => t == typeof(int) || t == typeof(int?);
        public override object ReadJson(JsonReader reader,Type t,object? existingValue,JsonSerializer serializer) {
            if(reader.TokenType == JsonToken.Null) return 0;
            string raw = serializer.Deserialize<string>(reader) ?? string.Empty, extracted = "";
            foreach(char c in raw) extracted += char.IsDigit(c) ? c : string.Empty;
            if(int.TryParse(extracted,out int i)) return i;
            return 0;
        }
        public override void WriteJson(JsonWriter writer,object? untypedValue,JsonSerializer serializer) {
            if(untypedValue == null) serializer.Serialize(writer,false);
            else if(untypedValue is int integer) serializer.Serialize(writer,integer.ToString()); // serialization not tested
        }
        public static readonly IntExtract Singleton = new();
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
            else if(untypedValue is int integer) serializer.Serialize(writer,integer.ToString()); // serialization not tested
        }
        public static readonly BoolOrIntToInt Singleton = new();
    }

    // Parsing minute:seconds.milliseconds timestamp found in race data
    internal class TimeStampParser : JsonConverter {
        public override bool CanConvert(Type t) => t == typeof(TimeSpan) || t == typeof(TimeSpan?);
        public override object ReadJson(JsonReader reader, Type t, object? existingValue, JsonSerializer serializer) {
            if(reader.TokenType == JsonToken.Null) return TimeSpan.Zero;
            var value = serializer.Deserialize<string>(reader) ?? string.Empty;
            if(TimeSpan.TryParseExact(value, @"mm\:ss\.fff", null, out TimeSpan ts)) return ts;
            return TimeSpan.Zero;
        }
        public override void WriteJson(JsonWriter writer, object? untypedValue, JsonSerializer serializer) {
            if(untypedValue == null) serializer.Serialize(writer, "00:00.000");
            else if(untypedValue is TimeSpan ts) serializer.Serialize(writer, ts.ToString(@"mm\:ss\.fff")); // serialization not tested
        }
        public static readonly TimeStampParser Singleton = new();
    }
}
