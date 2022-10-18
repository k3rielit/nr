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
            SessionLogin token = await Session.Login("email","password");
            // User info
            SessionUserInfo userInfo = await Session.GetUserInfo(token);
            Console.WriteLine($"User: #{userInfo.User.Id}");
            Console.WriteLine($"Personas[{userInfo.PersonaCount}]:");
            Console.WriteLine($" - Main {userInfo.Persona.Name}#{userInfo.Persona.Id} Lv{userInfo.Persona.Level}  {userInfo.Persona.Rep} REP  {userInfo.Persona.Cash} $  {userInfo.Persona.SpeedBoost} SB");
            foreach(var persona in userInfo.Others) {
                Console.WriteLine($" - Alt  {persona.Name}#{persona.Id}  Lv{persona.Level}  {persona.Rep} REP  {persona.Cash} $  {persona.SpeedBoost} SB");
            }
            // Crew cards
            List<CrewCard> crewCards = await Crew.GetCards(token);
            foreach(var crew in crewCards) {
                Console.WriteLine($"{crew.Tag,-11} {crew.Name+'#'+crew.CrewId,-30} Lv{crew.Level}\t{crew.MemberCount} Members\t{crew.Points} CP");
            }
            return;
        }
    }
}