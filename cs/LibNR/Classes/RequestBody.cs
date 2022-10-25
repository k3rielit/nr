using Newtonsoft.Json;

namespace LibNR {
    public class RequestBody {

        [JsonProperty("serviceName")]
        public string Service { get; set; } = string.Empty;

        [JsonProperty("methodName")]
        public string Method { get; set; } = string.Empty;
    }
    public class PRequestBody : RequestBody {

        [JsonProperty("parameters")]
        public List<object> Params { get; set; } = new();
    }
}
