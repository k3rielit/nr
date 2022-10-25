using Newtonsoft.Json;

namespace LibNR {
    public class CrewMember {
        [JsonProperty("ID")]
        public int MemberId { get; set; } = 0;

        [JsonProperty("personaID")]
        public int PersonaId { get; set; } = 0;

        [JsonProperty("date_join")]
        public DateTimeOffset JoinedAt { get; set; } = DateTimeOffset.MinValue;

        [JsonProperty("crewID")]
        public int CrewId { get; set; } = 0;

        [JsonProperty("points")]
        public int Points { get; set; } = 0;

        [JsonProperty("canManage")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool CanManage { get; set; } = false;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("isAdmin")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool IsAdmin { get; set; } = false;

        [JsonProperty("isDeveloper")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool IsDeveloper { get; set; } = false;

        [JsonProperty("isYoutuber")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool IsYoutuber { get; set; } = false;

        [JsonProperty("premium")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool IsPremium { get; set; } = false;

        [JsonProperty("prestige")]
        public int Prestige { get; set; } = 0;

        [JsonProperty("level")]
        public int Level { get; set; } = 0;

        [JsonProperty("iconIndex")]
        public int IconIndex { get; set; } = 0;

        [JsonProperty("role")]
        public string Role { get; set; } = string.Empty;
    }
}
