using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibNR.RawClasses;
using Newtonsoft.Json;

namespace LibNR {
    public class Session {

        public static async Task<rSessionLogin> Login(string email, string password, string param3 = "") {
            rSessionLogin login = new();
            string raw = await Utils.ReqAsync(HttpMethod.Post, "{\"serviceName\":\"session\",\"methodName\":\"login\",\"parameters\":[\""+email+"\",\""+password+"\",\""+param3+"\"]}");
            try {
                login = JsonConvert.DeserializeObject<rSessionLogin>(raw) ?? login;
            }
            catch(Exception ex) {
                Console.WriteLine("\nSession.Login(); ERROR\n"+ex.Message);
            }
            return login;
        }

        public static async Task<rSessionUserInfo> GetUserInfo(string easharpptr_p, string easharpptr_u) {
            rSessionUserInfo userInfo = new();
            string raw = await Utils.ReqAsync(HttpMethod.Post,easharpptr_p,easharpptr_u,"{\"serviceName\":\"session\",\"methodName\":\"GetUserInfo\"}");
            try {
                userInfo = JsonConvert.DeserializeObject<rSessionUserInfo>(raw) ?? userInfo;
            }
            catch(Exception ex) {
                Console.WriteLine("\nSession.GetUserInfo(); ERROR\n" + ex.Message);
            }
            return userInfo;
        }
        public static async Task<rSessionUserInfo> GetUserInfo(rSessionLogin login) => await GetUserInfo(login.easharpptr_p, login.easharpptr_u);

    }
}
