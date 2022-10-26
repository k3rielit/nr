using Newtonsoft.Json;

namespace LibNR {
    public class CrewLevel {

        [JsonProperty("price")]
        [JsonConverter(typeof(IntExtract))]
        public int Price { get; set; } = 0;

        [JsonProperty("level")]
        public int Level { get; set; } = 0;

        [JsonProperty("background")]
        public string BackgroundColor { get; set; } = "#f1f2f3";

        [JsonProperty("icon")]
        public string Status { get; set; } = string.Empty;
    }
}
