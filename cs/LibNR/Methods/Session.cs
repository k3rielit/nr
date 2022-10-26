using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LibNR {
    public class Session {

        public static async Task<SessionLogin> Login(string email, string password, string param3 = "") => await Utils.NrGet<SessionLogin>(HttpMethod.Post, new PRequestBody { Service = "session", Method = "login", Params = { email, password, param3 } }) ?? new();

        public static async Task<SessionUserInfo> GetUserInfo(int personaId, string token) => await Utils.NrGet<SessionUserInfo>(HttpMethod.Post, new RequestBody { Service = "session", Method = "GetUserInfo" }, personaId, token) ?? new();
        public static async Task<SessionUserInfo> GetUserInfo(SessionLogin login) => await GetUserInfo(login.PersonaId, login.Token);

    }
}
