using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ckan.NetSdk.v3.Responses
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CkanApiResponseError
    {
        [JsonProperty("__type")]
        public string Type { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
