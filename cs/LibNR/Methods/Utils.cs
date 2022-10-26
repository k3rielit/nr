using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LibNR {
    public static class Utils {
        public static async Task<T?> NrGet<T>(HttpMethod method, RequestBody body, int? personaId = null, string? token = null) {
            T? result = default;
            HttpClient client = new();
            var request = (personaId.HasValue && token!=null) ? new HttpRequestMessage {
                Method = method,
                RequestUri = new Uri("https://api.nightriderz.world/gateway.php?contentType=application%2Fjson"),
                Headers = {
                    { "easharpptr-p", personaId.ToString() },
                    { "easharpptr-u", token },
                },
                Content = new StringContent(body.ToJson())
            } : new HttpRequestMessage {
                Method = method,
                RequestUri = new Uri("https://api.nightriderz.world/gateway.php?contentType=application%2Fjson"),
                Content = new StringContent(body.ToJson())
            };
            try {
                using(var response = await client.SendAsync(request)) {
                    response.EnsureSuccessStatusCode();
                    var str = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<T>(str, Converter.Settings) ?? result;
                }
            }
            catch(Exception ex) {
                Console.WriteLine($"[ERROR DURING QUERY]\n > RequestBody:\"{body.ToJson()}\"\n > ErrorMessage:\"{ex.Message}\"");
            }
            return result;
        }

        public static async Task<T?> NrSet<T>(HttpMethod method, RequestBody body, int? personaId = null, string? token = null) {
            throw new NotImplementedException();
        }
    }
}
