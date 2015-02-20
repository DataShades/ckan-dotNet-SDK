using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ckan.NetSdk.v3.Responses
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CkanApiResponseBase
    {
        [JsonProperty("success")]
        public bool IsSuccess { get; set; }

        [JsonProperty("error")]
        public CkanApiResponseError Error { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class CkanApiResponseBase<T> : CkanApiResponseBase where T : class
    {
        [JsonProperty("result")]
        public T Data { get; set; }
    }
}
