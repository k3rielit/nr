using Newtonsoft.Json;

namespace LibNR {
    public class Players {


        // Get basic profile data
        public static async Task<PlayerInfo> GetInfo(int personaId, string token, int requestedPersonaId) => await Utils.NrGet<PlayerInfo>(HttpMethod.Post, new PRequestBody { Service = "players", Method = "GetPlayer", Params = { requestedPersonaId } }, personaId, token) ?? new();
        public static async Task<PlayerInfo> GetInfo(SessionLogin login, int requestedPersonaId) => await GetInfo(login.PersonaId, login.Token, requestedPersonaId);


        // Get a list of activities, 499 maximum
        public static async Task<List<PlayerActivity>> GetActivity(int personaId, string token, int requestedPersonaId) => await Utils.NrGet<List<PlayerActivity>>(HttpMethod.Post, new PRequestBody { Service = "players", Method = "GetActivity", Params = { requestedPersonaId } }, personaId, token) ?? new();
        public static async Task<List<PlayerActivity>> GetActivity(SessionLogin login, int requestedPersonaId) => await GetActivity(login.PersonaId, login.Token, requestedPersonaId);


        // Get a list of friends
        public static async Task<List<PlayerFriend>> GetFriends(int personaId, string token, int requestedPersonaId) => await Utils.NrGet<List<PlayerFriend>>(HttpMethod.Post, new PRequestBody { Service = "players", Method = "GetFriends", Params = { requestedPersonaId } }, personaId, token) ?? new();
        public static async Task<List<PlayerFriend>> GetFriends(SessionLogin login, int requestedPersonaId) => await GetFriends(login.PersonaId, login.Token, requestedPersonaId);

    }
}
