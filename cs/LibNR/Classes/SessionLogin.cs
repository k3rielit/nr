using Newtonsoft.Json;

namespace LibNR {
    public class SessionLogin {
        public static SessionLogin FromJson(string json) {
            SessionLogin login = new();
            try {
                login = JsonConvert.DeserializeObject<SessionLogin>(json,Converter.Settings) ?? new();
            }
            catch(Exception ex) {
                Console.WriteLine($"ERROR SessionLogin.FromJson(): {ex.Message}");
            }
            return login;
        }

        [JsonProperty("easharpptr_u")]
        public string Token { get; set; } = string.Empty;

        [JsonProperty("easharpptr_p")]
        public int PersonaId { get; set; } = 0;
    }
}
