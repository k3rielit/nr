using Newtonsoft.Json;

namespace LibNR {
    public class PlayerInfo {
        public static PlayerInfo FromJson(string json) {
            PlayerInfo info = new();
            try {
                info = JsonConvert.DeserializeObject<PlayerInfo>(json,Converter.Settings) ?? new();
            }
            catch(Exception ex) {
                Console.WriteLine($"ERROR PlayerInfo.FromJson(): {ex.Message}");
            }
            return info;
        }

        [JsonProperty("boost")]
        [JsonConverter(typeof(FancyIntConverter))]
        public int SpeedBoost { get; set; } = 0;

        [JsonProperty("ID")]
        public int PersonaId { get; set; } = 0;

        [JsonProperty("cash")]
        [JsonConverter(typeof(FancyIntConverter))]
        public int Cash { get; set; } = 0;

        [JsonProperty("level")]
        public int Level { get; set; } = 0;

        [JsonProperty("motto")]
        public string Motto { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("score")]
        [JsonConverter(typeof(FancyIntConverter))]
        public int Score { get; set; } = 0;

        [JsonProperty("created")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.MinValue;

        [JsonProperty("prestige")]
        [JsonConverter(typeof(FancyIntConverter))]
        public int Prestige { get; set; } = 0;

        [JsonProperty("iconIndex")]
        [JsonConverter(typeof(FancyIntConverter))]
        public int IconIndex { get; set; } = 0;

        [JsonProperty("last_login")]
        public DateTimeOffset LastLoginAt { get; set; } = DateTimeOffset.MinValue;

        [JsonProperty("curCarIndex")]
        public int CurrentCarIndex { get; set; } = 0;

        [JsonProperty("USERID")]
        public int UserId { get; set; } = 0;

        [JsonProperty("streak")]
        [JsonConverter(typeof(FancyIntConverter))]
        public int Streak { get; set; } = 0;

        [JsonProperty("isAdmin")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool IsAdmin { get; set; } = false;

        [JsonProperty("premium")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool IsPremium { get; set; } = false;

        [JsonProperty("isYoutuber")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool IsYoutuber { get; set; } = false;

        [JsonProperty("isDeveloper")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool IsDeveloper { get; set; } = false;

        [JsonProperty("challenges")]
        [JsonConverter(typeof(FancyIntConverter))]
        public int Challenges { get; set; } = 0;

        [JsonProperty("cars")]
        [JsonConverter(typeof(FancyIntConverter))]
        public int CarCount { get; set; } = 0;

        [JsonProperty("role")]
        public string Role { get; set; } = string.Empty;

        [JsonProperty("otherpersona")]
        public List<PlayerInfo_OtherPersona> OtherPersonas { get; set; } = new();

        [JsonProperty("crew_name")]
        public string CrewName { get; set; } = string.Empty;

        [JsonProperty("crew_id")]
        [JsonConverter(typeof(BoolOrIntToInt))]
        public int CrewId { get; set; } = 0;

        [JsonProperty("races")]
        [JsonConverter(typeof(FancyIntConverter))]
        public int RaceCount { get; set; } = 0;
    }

    public class PlayerInfo_OtherPersona {
        [JsonProperty("ID")]
        public int PersonaId { get; set; } = 0;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("premium")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool IsPremium { get; set; } = false;

        [JsonProperty("discord")]
        public long DiscordId { get; set; } = 0;

        [JsonProperty("iduser")]
        public int UserId { get; set; } = 0;
    }
}
