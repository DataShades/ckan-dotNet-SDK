using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ckan.NetSdk.v3
{
    public class CkanApiAuthentication
    {
        public const string DefaultAuthorizationHeaderName = "Authorization";

        public const string AuthorizationHeaderConfigurationName = "Ckan.NetSdk.AuthorizationHeaderName";
        public const string ApiKeyConfigurationName = "Ckan.NetSdk.ApiKey";

        public string ApiKey { get; private set; }

        public string AuthorizationHeaderName { get; private set; }

        public CkanApiAuthentication()
            : this(ConfigurationManager.AppSettings[ApiKeyConfigurationName], ConfigurationManager.AppSettings[AuthorizationHeaderConfigurationName])
        {
        }

        public CkanApiAuthentication(string apiKey)
            : this(apiKey, ConfigurationManager.AppSettings[AuthorizationHeaderConfigurationName])
        {

        }

        public CkanApiAuthentication(string apiKey, string authorizationHeaderName)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentNullException("apiKey");

            if (string.IsNullOrWhiteSpace(authorizationHeaderName))
                authorizationHeaderName = DefaultAuthorizationHeaderName;

            ApiKey = apiKey;
            AuthorizationHeaderName = authorizationHeaderName;
        }
    }
}
