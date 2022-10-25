namespace LibNR {
    public class Players {

        public static async Task<PlayerInfo> GetInfo(int personaId, string token, int requestedPersonaId) {
            string raw = await Utils.ReqAsync(HttpMethod.Post, personaId, token, new PRequestBody { Service = "players", Method = "GetPlayer", Params = { requestedPersonaId } });
            return PlayerInfo.FromJson(raw);
        }
        public static async Task<PlayerInfo> GetInfo(SessionLogin login, int requestedPersonaId) => await GetInfo(login.PersonaId, login.Token, requestedPersonaId);

    }
}
