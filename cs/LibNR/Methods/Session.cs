using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LibNR {
    public class Session {

        public static async Task<SessionLogin> Login(string email, string password, string param3 = "") {
            string raw = await Utils.ReqAsync(HttpMethod.Post, new PRequestBody { Service = "session", Method = "login", Params = { email, password, param3} });
            return SessionLogin.FromJson(raw);
        }

        public static async Task<SessionUserInfo> GetUserInfo(int personaId, string token) {
            string raw = await Utils.ReqAsync(HttpMethod.Post,personaId,token, new RequestBody { Service = "session", Method = "GetUserInfo" });
            return SessionUserInfo.FromJson(raw);
        }
        public static async Task<SessionUserInfo> GetUserInfo(SessionLogin login) => await GetUserInfo(login.PersonaId, login.Token);

    }
}
