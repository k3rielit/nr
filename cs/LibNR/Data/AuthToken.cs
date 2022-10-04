using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LibNR.Data {
    public class AuthToken {
        public string easharpptr_u { get; set; } = string.Empty;
        public string easharpptr_p { get; set; } = string.Empty;
        public static async Task<AuthToken> Create(string email, string password, string param3 = "") {
            AuthToken token = new();
            var client = new HttpClient();
            var request = new HttpRequestMessage {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.nightriderz.world/gateway.php?contentType=application%2Fjson"),
                Content = new StringContent("{\"serviceName\": \"session\",\"methodName\": \"login\",\"parameters\": [\""+email+"\",\""+password+"\",\""+param3+"\"]}")
            };
            try {
                using(var response = await client.SendAsync(request)) {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    token = JsonConvert.DeserializeObject<AuthToken>(body) ?? token;
                }
            }
            catch(Exception) {
                // TODO: better error handling, or rethrow option ...
            }
            return token;
        }
    }
}
