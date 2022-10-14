using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibNR {
    public static class Utils {
        public static async Task<string> ReqAsync(HttpMethod method, string easharpptr_p, string easharpptr_u, string body, string path = "https://api.nightriderz.world/gateway.php?contentType=application%2Fjson") {
            HttpClient client = new();
            var request = new HttpRequestMessage {
                Method = method,
                RequestUri = new Uri(path),
                Headers = {
                    { "easharpptr-p", easharpptr_p },
                    { "easharpptr-u", easharpptr_u },
                },
                Content = new StringContent(body)
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

        public static async Task<string> ReqAsync(HttpMethod method, string body, string path = "https://api.nightriderz.world/gateway.php?contentType=application%2Fjson") {
            HttpClient client = new();
            var request = new HttpRequestMessage {
                Method = method,
                RequestUri = new Uri(path),
                Content = new StringContent(body)
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
    }
}
