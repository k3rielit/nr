using Newtonsoft.Json;

namespace LibNR {
    public class CrewActivity {

        [JsonProperty("time")]
        public string Time { get; set; } = string.Empty;

        [JsonProperty("value")]
        public string Message { get; set; } = string.Empty;

        [JsonProperty("points")]
        [JsonConverter(typeof(IntExtract))]
        public int Points { get; set; } = 0;

        [JsonProperty("pseudo")]
        public string Emitter { get; set; } = string.Empty;

        [JsonProperty("racename")]
        public string EventName { get; set; } = string.Empty;
    }
}
