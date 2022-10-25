using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LibNR {
    public static class Utils {
        public static async Task<string> ReqAsync(HttpMethod method, int personaId, string token, RequestBody body, string path = "https://api.nightriderz.world/gateway.php?contentType=application%2Fjson") {
            HttpClient client = new();
            var request = new HttpRequestMessage {
                Method = method,
                RequestUri = new Uri(path),
                Headers = {
                    { "easharpptr-p", personaId.ToString() },
                    { "easharpptr-u", token },
                },
                Content = new StringContent(body.ToJson())
            };
            try {
                using(var response = await client.SendAsync(request)) {
                    response.EnsureSuccessStatusCode();
                    var str = await response.Content.ReadAsStringAsync();
                    return str;
                }
            }
            catch(Exception) {
                // TODO: better error handling, or rethrow option ...
            }
            return string.Empty;
        }

        public static async Task<string> ReqAsync(HttpMethod method, RequestBody body, string path = "https://api.nightriderz.world/gateway.php?contentType=application%2Fjson") {
            HttpClient client = new();
            var request = new HttpRequestMessage {
                Method = method,
                RequestUri = new Uri(path),
                Content = new StringContent(body.ToJson())
            };
            try {
                using(var response = await client.SendAsync(request)) {
                    response.EnsureSuccessStatusCode();
                    var str = await response.Content.ReadAsStringAsync();
                    return str;
                }
            }
            catch(Exception) {
                // TODO: better error handling, or rethrow option ...
            }
            return string.Empty;
        }

        // Serialization
        public static string ToJson(this SessionUserInfo self) => JsonConvert.SerializeObject(self,LibNR.Converter.Settings);
    }
}
