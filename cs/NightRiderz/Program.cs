using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightRiderz {
    internal class Program {
        static void Main(string[] args) {
            Run();
            Console.ReadLine();
        }
        static async void Run() {
            // load credentials from file
            // load previous token from file, into a LibNR.Data.AuthToken, try logging in, if not, request new token
            // config.json
            LibNR.Data.AuthToken token = await LibNR.Data.AuthToken.Create("email","password");
            LibNR.Account.Login(token);
            Console.WriteLine(token.easharpptr_u);
            Console.WriteLine(token.easharpptr_p);
            Console.WriteLine(LibNR.Account.LoggedIn);
        }
    }
}