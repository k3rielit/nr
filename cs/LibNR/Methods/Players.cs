using Newtonsoft.Json;

namespace LibNR {
    public class Players {


        // Get basic profile data
        public static async Task<PlayerInfo> GetInfo(int personaId, string token, int requestedPersonaId) {
            string raw = await Utils.ReqAsync(HttpMethod.Post, personaId, token, new PRequestBody { Service = "players", Method = "GetPlayer", Params = { requestedPersonaId } });
            return PlayerInfo.FromJson(raw);
        }
        public static async Task<PlayerInfo> GetInfo(SessionLogin login, int requestedPersonaId) => await GetInfo(login.PersonaId, login.Token, requestedPersonaId);


        // Get a list of activities, 499 maximum
        public static async Task<List<PlayerActivity>> GetActivity(int personaId, string token, int requestedPersonaId) {
            string raw = await Utils.ReqAsync(HttpMethod.Post, personaId, token, new PRequestBody { Service = "players", Method = "GetActivity", Params = { requestedPersonaId } });
            List<PlayerActivity> activity = new();
            try {
                activity = JsonConvert.DeserializeObject<List<PlayerActivity>>(raw, Converter.Settings) ?? new();
            }
            catch(Exception ex) {
                Console.WriteLine($"ERROR Players.GetActivity(): {ex.Message}");
            }
            return activity;
        }
        public static async Task<List<PlayerActivity>> GetActivity(SessionLogin login, int requestedPersonaId) => await GetActivity(login.PersonaId, login.Token, requestedPersonaId);

    }
}
