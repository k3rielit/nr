using Newtonsoft.Json;

namespace LibNR {
    public class PlayerActivity {

        [JsonProperty("place")]
        public int Place { get; set; } = 0;

        [JsonProperty("carId")]
        public int CarId { get; set; } = 0;

        [JsonProperty("eventID")]
        public int EventId { get; set; } = 0;

        [JsonProperty("eventSessionId")]
        public long EventSessionId { get; set; } = 0;

        [JsonProperty("DATE_PLAY")]
        public string PlayedAt { get; set; } = string.Empty;

        [JsonProperty("carClassHash")]
        public long CarClassHash { get; set; } = 0;

        [JsonProperty("eventDurationInMilliseconds")]
        [JsonConverter(typeof(TimeStampParser))]
        public TimeSpan Time { get; set; } = TimeSpan.Zero;

        [JsonProperty("topSpeed")]
        public int TopSpeed { get; set; } = 0;

        [JsonProperty("perfectStart")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool IsPerfectStart { get; set; } = false;

        [JsonProperty("finishReason")]
        public int FinishReason { get; set; } = 0; // to do

        [JsonProperty("hacksDetected")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool IsCheating { get; set; } = false;

        [JsonProperty("CarName")]
        public string CarName { get; set; } = string.Empty; // shorter car model identifier

        [JsonProperty("rating")]
        public int CarRating { get; set; } = 0;

        [JsonProperty("manufactor")]
        public string CarManufacturer { get; set; } = string.Empty;

        [JsonProperty("model")]
        public string CarModel { get; set; } = string.Empty; // full car model

        [JsonProperty("name")]
        public string EventName { get; set; } = string.Empty;

        [JsonProperty("eventModeId")]
        public int EventModeId { get; set; } = 0; // to do

        [JsonProperty("LOBBYID")]
        public string LobbyType { get; set; } = string.Empty; // singleplayer/multiplayer

        [JsonProperty("proprio")]
        public int PersonaId { get; set; } = 0;

        [JsonProperty("isPrivate")]
        public int IsPrivate { get; set; } = 0; // to do

        [JsonProperty("car")]
        public PlayerActivity_Car Car { get; set; } = new();

        [JsonProperty("pu")]
        public List<PlayerActivity_Powerup> Powerups { get; set; } = new();

        [JsonProperty("pu_nb")]
        public int PowerupCount { get; set; } = 0;

        [JsonProperty("race")]
        public PlayerActivity_Race Race { get; set; } = new();
    }

    public class PlayerActivity_Car {

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("class")]
        public string Class { get; set; } = "E";

        [JsonProperty("rating")]
        public int Rating { get; set; } = 0;
    }

    public class PlayerActivity_Powerup {

        [JsonProperty("longDescription")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("count")]
        public int Count { get; set; } = 0;

        [JsonProperty("powerupHash")]
        public long Hash { get; set; } = 0;

        [JsonProperty("icon")]
        public string IconFile { get; set; } = string.Empty;
    }

    public class PlayerActivity_Race {

        [JsonProperty("perfect")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool IsPerfect { get; set; } = false;
    }
}
