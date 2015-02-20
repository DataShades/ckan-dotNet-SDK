using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ckan.NetSdk.v3.Entities
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CkanUser
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("fullname")]
        public string FullName { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("sysadmin")]
        public bool IsSystemAdministrator { get; set; }

    }
}
