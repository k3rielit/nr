using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LibNR {
    public class Crew {
        // Get all crew cards
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

        // Get crew cards from a district
        // It got implemented, but it's better to get and cache all cards, and then filter
        public static async Task<List<CrewCard>> GetCards(int personaId,string token,int districtId) {
            string raw = await Utils.ReqAsync(HttpMethod.Post,personaId,token,"{\"serviceName\":\"crew\",\"methodName\":\"GetCards\",\"parameters\":["+districtId+"]}");
            List<CrewCard> cards = new();
            try {
                cards = JsonConvert.DeserializeObject<List<CrewCard>>(raw,Converter.Settings) ?? new();
            }
            catch(Exception ex) {
                Console.WriteLine($"ERROR Crew.GetCards(): {ex.Message}");
            }
            return cards;
        }
        public static async Task<List<CrewCard>> GetCards(SessionLogin login,int districtId) => await GetCards(login.PersonaId,login.Token,districtId);


    }
}
