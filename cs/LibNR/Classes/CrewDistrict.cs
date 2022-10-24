using Newtonsoft.Json;

namespace LibNR {
    public class CrewDistrict {
        [JsonProperty("city")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("loop")]
        public List<CrewDistrict_Item> Districts { get; set; } = new();
    }

    public class CrewDistrict_Item {
        [JsonProperty("id")]
        public int Id { get; set; } = 0;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;
    }
}
