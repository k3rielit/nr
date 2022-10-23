using Newtonsoft.Json;

namespace LibNR {
    public class CrewCard {
        [JsonProperty("tag")]
        public string Tag { get; set; } = string.Empty;

        [JsonProperty("cover_version")]
        public int CoverVersion { get; set; } = 0;

        [JsonProperty("thumb_version")]
        public int ThumbnailVersion { get; set; } = 0;

        [JsonProperty("crewid")]
        public int CrewId { get; set; } = 0;

        [JsonProperty("nb_points")]
        public int Points { get; set; } = 0;

        [JsonProperty("level")]
        public int Level { get; set; } = 0;

        [JsonProperty("open")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool IsOpen { get; set; } = false;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("nb_member")]
        public int MemberCount { get; set; } = 0;

        [JsonProperty("city")]
        public string City { get; set; } = string.Empty;

        [JsonProperty("district")]
        public string DistrictName { get; set; } = string.Empty;

        [JsonProperty("districtid")]
        public int DistrictId { get; set; } = 0;
    }
}
