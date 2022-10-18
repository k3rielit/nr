using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LibNR {
    public class Crew {
        public static async Task<List<CrewCard>> GetCards(int personaId,string token) {
            string raw = await Utils.ReqAsync(HttpMethod.Post,personaId,token,"{\"serviceName\":\"crew\",\"methodName\":\"GetCards\"}");
            List<CrewCard> cards = new();
            try {
                cards = JsonConvert.DeserializeObject<List<CrewCard>>(raw,Converter.Settings) ?? new();
            }
            catch(Exception ex) {
                Console.WriteLine($"ERROR Crew.GetCards(): {ex.Message}");
            }
            return cards;
        }
        public static async Task<List<CrewCard>> GetCards(SessionLogin login) => await GetCards(login.PersonaId,login.Token);
    }
}
