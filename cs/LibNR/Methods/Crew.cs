using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LibNR {
    public class Crew {

        // Get all crew cards
        public static async Task<List<CrewCard>> GetCards(int personaId, string token) {
            string raw = await Utils.ReqAsync(HttpMethod.Post, personaId, token, new RequestBody { Service = "crew", Method = "GetCards" });
            List<CrewCard> cards = new();
            try {
                cards = JsonConvert.DeserializeObject<List<CrewCard>>(raw, Converter.Settings) ?? new();
            }
            catch(Exception ex) {
                Console.WriteLine($"ERROR Crew.GetCards(): {ex.Message}");
            }
            return cards;
        }
        public static async Task<List<CrewCard>> GetCards(SessionLogin login) => await GetCards(login.PersonaId, login.Token);


        // Get crew cards from a district
        // It got implemented, but it's better to get and cache all cards, and then filter
        public static async Task<List<CrewCard>> GetCards(int personaId, string token, int districtId) {
            string raw = await Utils.ReqAsync(HttpMethod.Post, personaId, token, new PRequestBody { Service = "crew", Method = "GetCards", Params = { districtId } });
            List<CrewCard> cards = new();
            try {
                cards = JsonConvert.DeserializeObject<List<CrewCard>>(raw, Converter.Settings) ?? new();
            }
            catch(Exception ex) {
                Console.WriteLine($"ERROR Crew.GetCards(): {ex.Message}");
            }
            return cards;
        }
        public static async Task<List<CrewCard>> GetCards(SessionLogin login, int districtId) => await GetCards(login.PersonaId, login.Token, districtId);


        // Get a list of available districts
        public static async Task<List<CrewDistrict>> GetDistricts(int personaId, string token) {
            string raw = await Utils.ReqAsync(HttpMethod.Post, personaId, token, new RequestBody { Service = "crew", Method = "GetDistrict" });
            List<CrewDistrict> districts = new();
            try {
                districts = JsonConvert.DeserializeObject<List<CrewDistrict>>(raw, Converter.Settings) ?? new();
            }
            catch(Exception ex) {
                Console.WriteLine($"ERROR Crew.GetDistricts(): {ex.Message}");
            }
            return districts;
        }
        public static async Task<List<CrewDistrict>> GetDistricts(SessionLogin login) => await GetDistricts(login.PersonaId, login.Token);


        // Gets the basic crew informations, excluding activity and members
        public static async Task<CrewInfo> GetInfo(int personaId, string token, int crewId) {
            string raw = await Utils.ReqAsync(HttpMethod.Post, personaId, token, new PRequestBody { Service = "crew", Method = "GetInfo", Params = { crewId } });
            var result = CrewInfo.FromJson(raw);
            result.CrewId = crewId;
            return result;
        }
        public static async Task<CrewInfo> GetInfo(SessionLogin login, int crewId) => await GetInfo(login.PersonaId, login.Token, crewId);


        // Gets a list of all the members in a crew
        // Crew owners' CanManage is set to false for some reason
        public static async Task<List<CrewMember>> GetMembers(int personaId, string token, int crewId) {
            string raw = await Utils.ReqAsync(HttpMethod.Post, personaId, token, new PRequestBody { Service = "crew", Method = "GetMembers", Params = { crewId } });
            List<CrewMember> members = new();
            try {
                members = JsonConvert.DeserializeObject<List<CrewMember>>(raw, Converter.Settings) ?? new();
            }
            catch(Exception ex) {
                Console.WriteLine($"ERROR Crew.GetMembers(): {ex.Message}");
            }
            return members;
        }
        public static async Task<List<CrewMember>> GetMembers(SessionLogin login, int crewId) => await GetMembers(login.PersonaId, login.Token, crewId);


        // Get all the different kinds of crew activities
        public static async Task<List<CrewActivity>> GetActivity(int personaId, string token, int crewId, string activityType) {
            string raw = await Utils.ReqAsync(HttpMethod.Post, personaId, token, new PRequestBody { Service = "crew", Method = "GetActivity", Params = { crewId, activityType } });
            List<CrewActivity> activities = new();
            try {
                activities = JsonConvert.DeserializeObject<List<CrewActivity>>(raw, Converter.Settings) ?? new();
            }
            catch(Exception ex) {
                Console.WriteLine($"ERROR Crew.GetActivity(): {ex.Message}");
            }
            return activities;
        }
        public static async Task<List<CrewActivity>> GetActivity(SessionLogin login, int crewId, string activityType) => await GetActivity(login.PersonaId, login.Token, crewId, activityType);


        // Get a list about the status and price of different rew levels
        // Only works if you're the owner (or manager?) of the clan
        public static async Task<List<CrewLevel>> GetLevels(int personaId, string token, int crewId) {
            string raw = await Utils.ReqAsync(HttpMethod.Post, personaId, token, new PRequestBody { Service = "crew", Method = "GetLevel", Params = { crewId } });
            List<CrewLevel> levels = new();
            try {
                levels = JsonConvert.DeserializeObject<List<CrewLevel>>(raw, Converter.Settings) ?? new();
            }
            catch(Exception ex) {
                Console.WriteLine($"ERROR Crew.GetLevels(): {ex.Message}");
            }
            return levels;
        }
        public static async Task<List<CrewLevel>> GetLevels(SessionLogin login, int crewId) => await GetLevels(login.PersonaId, login.Token, crewId);

    }
}
