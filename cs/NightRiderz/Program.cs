using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibNR;
using LibNR.RawClasses;

namespace NightRiderz {
    internal class Program {
        static void Main(string[] args) {
            Run();
            Console.ReadLine();
        }
        static async void Run() {
            rSessionLogin token = await Session.Login("email","password");
            rSessionUserInfo userInfo = await Session.GetUserInfo(token);
            Console.WriteLine($"Persona: {userInfo.persona.name}#{token.easharpptr_p}");
            Console.WriteLine($"Lv{userInfo.persona.level} {userInfo.persona.cash}$ {userInfo.persona.boost}SB ");
        }
    }
}