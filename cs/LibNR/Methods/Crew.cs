using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LibNR {
    public class Crew {

        // Get all crew cards
        public static async Task<List<CrewCard>> GetCards(int personaId, string token) => await Utils.NrGet<List<CrewCard>>(HttpMethod.Post, new RequestBody { Service = "crew", Method = "GetCards" }, personaId, token) ?? new();
        public static async Task<List<CrewCard>> GetCards(SessionLogin login) => await GetCards(login.PersonaId, login.Token);


        // Get crew cards from a district
        // It got implemented, but it's better to get and cache all cards, and then filter
        public static async Task<List<CrewCard>> GetCards(int personaId, string token, int districtId) => await Utils.NrGet<List<CrewCard>>(HttpMethod.Post, new PRequestBody { Service = "crew", Method = "GetCards", Params = { districtId } }, personaId, token) ?? new();
        public static async Task<List<CrewCard>> GetCards(SessionLogin login, int districtId) => await GetCards(login.PersonaId, login.Token, districtId);


        // Get a list of available districts
        public static async Task<List<CrewDistrict>> GetDistricts(int personaId, string token) => await Utils.NrGet<List<CrewDistrict>>(HttpMethod.Post, new RequestBody { Service = "crew", Method = "GetDistrict" }, personaId, token) ?? new();
        public static async Task<List<CrewDistrict>> GetDistricts(SessionLogin login) => await GetDistricts(login.PersonaId, login.Token);


        // Gets the basic crew informations, excluding activity and members
        public static async Task<CrewInfo> GetInfo(int personaId, string token, int crewId) {
            var result = await Utils.NrGet<CrewInfo>(HttpMethod.Post, new PRequestBody { Service = "crew", Method = "GetInfo", Params = { crewId } }, personaId, token) ?? new() { CrewId = crewId };
            result.CrewId = crewId;
            return result;
        }
        public static async Task<CrewInfo> GetInfo(SessionLogin login, int crewId) => await GetInfo(login.PersonaId, login.Token, crewId);


        // Gets a list of all the members in a crew
        // Crew owners' CanManage is set to false for some reason
        public static async Task<List<CrewMember>> GetMembers(int personaId, string token, int crewId) => await Utils.NrGet<List<CrewMember>>(HttpMethod.Post, new PRequestBody { Service = "crew", Method = "GetMembers", Params = { crewId } }, personaId, token) ?? new();
        public static async Task<List<CrewMember>> GetMembers(SessionLogin login, int crewId) => await GetMembers(login.PersonaId, login.Token, crewId);


        // Get all the different kinds of crew activities
        public static async Task<List<CrewActivity>> GetActivity(int personaId, string token, int crewId, string activityType) => await Utils.NrGet<List<CrewActivity>>(HttpMethod.Post, new PRequestBody { Service = "crew", Method = "GetActivity", Params = { crewId, activityType } }, personaId, token) ?? new();
        public static async Task<List<CrewActivity>> GetActivity(SessionLogin login, int crewId, string activityType) => await GetActivity(login.PersonaId, login.Token, crewId, activityType);


        // Get a list about the status and price of different rew levels
        // Only works if you're the owner (or manager?) of the clan
        public static async Task<List<CrewLevel>> GetLevels(int personaId, string token, int crewId) => await Utils.NrGet<List<CrewLevel>>(HttpMethod.Post, new PRequestBody { Service = "crew", Method = "GetLevel", Params = { crewId } }, personaId, token) ?? new();
        public static async Task<List<CrewLevel>> GetLevels(SessionLogin login, int crewId) => await GetLevels(login.PersonaId, login.Token, crewId);

    }
}
