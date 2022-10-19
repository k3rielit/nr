using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LibNR {
    public class Players {

        public static async Task<PlayerInfo> GetInfo(int personaId,string token,int requestedPersonaId) {
            string raw = await Utils.ReqAsync(HttpMethod.Post,personaId,token,"{\"serviceName\":\"players\",\"methodName\":\"GetPlayer\",\"parameters\":[\""+requestedPersonaId+"\"]}");
            return PlayerInfo.FromJson(raw);
        }
        public static async Task<PlayerInfo> GetInfo(SessionLogin login,int requestedPersonaId) => await GetInfo(login.PersonaId,login.Token,requestedPersonaId);

    }
}
