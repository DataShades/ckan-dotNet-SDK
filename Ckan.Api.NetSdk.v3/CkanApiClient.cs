using Ckan.NetSdk.v3.Action;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ckan.NetSdk.v3
{
    public sealed class CkanApiClient
    {
        public const string BaseUrlConfigurationName = "Ckan.NetSdk.BaseUrl";

        public string BaseUrl { get; private set; }

        public CkanApiAuthentication Authentication { get; private set; }

        public UserActions User { get; private set; }

        public CkanApiClient()
            : this(ConfigurationManager.AppSettings[BaseUrlConfigurationName], new CkanApiAuthentication())
        {

        }

        public CkanApiClient(string baseUrl)
            : this(baseUrl, new CkanApiAuthentication())
        {

        }

        public CkanApiClient(CkanApiAuthentication authentication)
            : this(ConfigurationManager.AppSettings[BaseUrlConfigurationName], authentication)
        {

        }

        public CkanApiClient(string baseUrl, CkanApiAuthentication authentication)
        {
            if (authentication == null)
                throw new ArgumentNullException("authentication");

            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new ArgumentNullException("baseUrl");

            BaseUrl = baseUrl;
            Authentication = authentication;

            User = new UserActions(this);
        }
    }
}
