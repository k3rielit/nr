using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibNR;

namespace NightRiderz {
    internal class Program {
        static void Main(string[] args) {
            Console.OutputEncoding = Encoding.Latin1;
            Console.Title = "Testing LibNR";
            Run();
            Console.ReadLine();
        }
        static async void Run() {
            // Login
            var token = await Session.Login("email","password");

            // User Info
            var userInfo = await Session.GetUserInfo(token);
            Console.WriteLine($"User: #{userInfo.User.Id}");
            Console.WriteLine($"Personas[{userInfo.PersonaCount}]:");
            Console.WriteLine($" - Main {userInfo.Persona.Name}#{userInfo.Persona.Id} Lv{userInfo.Persona.Level}  {userInfo.Persona.Rep} REP  {userInfo.Persona.Cash} $  {userInfo.Persona.SpeedBoost} SB");
            foreach(var persona in userInfo.Others) {
                Console.WriteLine($" - Alt  {persona.Name}#{persona.Id}  Lv{persona.Level}  {persona.Rep} REP  {persona.Cash} $  {persona.SpeedBoost} SB");
            }

            // Crew Cards
            Thread.Sleep(2000);
            var crewCards = await Crew.GetCards(token);
            foreach(var crew in crewCards) {
                Console.WriteLine($"{crew.Tag,-11} {crew.Name+'#'+crew.CrewId,-30} Lv{crew.Level}\t{crew.MemberCount} Members\t{crew.Points} CP");
            }

            // Player Profile
            Thread.Sleep(2000);
            var playerInfo = await Players.GetInfo(token,100);
            Console.WriteLine($"Got: {playerInfo.Name}#{playerInfo.PersonaId} ({playerInfo.Role})  Lv{playerInfo.Level}  {playerInfo.Cash} $  {playerInfo.SpeedBoost} SB");
            foreach(var otherPersona in playerInfo.OtherPersonas) {
                Console.WriteLine($" - Alt {otherPersona.Name}#{otherPersona.PersonaId}");
            }

            // Crew districts
            Thread.Sleep(2000);
            var districts = await Crew.GetDistricts(token);
            foreach(var city in districts) {
                Console.WriteLine($"{city.Name}:");
                foreach(var district in city.Districts) {
                    Console.WriteLine($" - #{district.Id} {district.Name}");
                }
            }

            return;
        }
    }
}