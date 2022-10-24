using Newtonsoft.Json;

namespace LibNR {
    public class CrewInfo {
        public static CrewInfo FromJson(string json) {
            CrewInfo info = new();
            try {
                info = JsonConvert.DeserializeObject<CrewInfo>(json,Converter.Settings) ?? new();
            }
            catch(Exception ex) {
                Console.WriteLine($"ERROR CrewInfo.FromJson(): {ex.Message}");
            }
            return info;
        }

        [JsonProperty("ID")]
        public int CrewId { get; set; } = 0; // Seems to also be DistrictId by default, but it's repurposed as the crew id because that's missing

        [JsonProperty("tag")]
        public string Tag { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("motto")]
        public string Motto { get; set; } = string.Empty;

        [JsonProperty("color")]
        public string Color { get; set; } = "#ffffff";

        [JsonProperty("cover_version")]
        public int CoverVersion { get; set; } = 0;

        [JsonProperty("thumb_version")]
        public int ThumbnailVersion { get; set; } = 0;

        [JsonProperty("district_id")]
        public int DistrictId { get; set; } = 0;

        [JsonProperty("create_date")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.MinValue;

        [JsonProperty("open")]
        public bool IsOpen { get; set; } = false;

        [JsonProperty("nb_member")]
        public int MemberCount { get; set; } = 0;

        [JsonProperty("nb_points")]
        public int Points { get; set; } = 0;

        [JsonProperty("level")]
        public int Level { get; set; } = 0;

        [JsonProperty("ownerUserId")]
        public int OwnerPersonaId { get; set; } = 0;

        [JsonProperty("maxPoints")]
        public int MaxPoints { get; set; } = 0;

        [JsonProperty("dropSB")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool DropsEnabled { get; set; } = false; // Gets instantly enabled after 1 race

        [JsonProperty("city")]
        public string City { get; set; } = string.Empty;

        [JsonProperty("district")]
        public string DistrictName { get; set; } = string.Empty;

        [JsonProperty("nb_crew")]
        public int nb_crew { get; set; } = 0; // Unsure what it's meant for

        [JsonProperty("ownername")]
        public string OwnerName { get; set; } = string.Empty;
    }
}
