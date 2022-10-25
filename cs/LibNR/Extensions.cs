using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LibNR {
    public static class Extensions {
        public static string ToJson(this RequestBody body) => JsonConvert.SerializeObject(body);
        public static string ToJson(this PRequestBody body) => JsonConvert.SerializeObject(body);
    }
}
