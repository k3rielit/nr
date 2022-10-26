using Newtonsoft.Json;

namespace LibNR {
    public class PlayerFriend {

        [JsonProperty("id")]
        public int PersonaId { get; set; } = 0;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("score")]
        [JsonConverter(typeof(IntExtract))]
        public int Score { get; set; } = 0;

        [JsonProperty("prestige")]
        public int Prestige { get; set; } = 0;

        [JsonProperty("level")]
        public int Level { get; set; } = 0;

        [JsonProperty("last_login")]
        public DateTimeOffset LastLoginAt { get; set; } = DateTimeOffset.MinValue;

        [JsonProperty("iconIndex")]
        public int IconIndex { get; set; } = 0;

        [JsonProperty("role")]
        public string Role { get; set; } = string.Empty;
    }
}
