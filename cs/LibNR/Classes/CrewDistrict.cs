using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
