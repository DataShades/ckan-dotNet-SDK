using Ckan.NetSdk.v3.Responses;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ckan.NetSdk.v3.Action
{
    public abstract class CkanApiActionBase
    {
        private const string ActionUrlTemplate = "{0}/api/3/action/{1}?{2}";

        private CkanApiClient CkanApiClient { get; set; }

        protected CkanApiActionBase(CkanApiClient ckanApiClient)
        {
            CkanApiClient = ckanApiClient;
        }

        protected async Task<T> DoRequest<T>(string action, HttpMethod method, object data) where T : CkanApiResponseBase
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    var queryString = string.Empty;

                    if (method == HttpMethod.Get)
                        queryString = BuildQueryString(data);

                    var httpWebRequest = HttpWebRequest.CreateHttp(string.Format(ActionUrlTemplate, CkanApiClient.BaseUrl, action, queryString));

                    httpWebRequest.Headers.Add(CkanApiClient.Authentication.AuthorizationHeaderName, CkanApiClient.Authentication.ApiKey);
                    httpWebRequest.Method = method.ToString().ToUpper();

                    httpWebRequest.ContentType = ContentType.Json;

                    if (method != HttpMethod.Get && data != null)
                    {
                        var parametersJson = JsonConvert.SerializeObject(data);

                        using (var streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync()))
                            await streamWriter.WriteAsync(parametersJson);
                    }

                    using (var streamReader = new StreamReader((await httpWebRequest.GetResponseAsync()).GetResponseStream()))
                        return JsonConvert.DeserializeObject<T>(await streamReader.ReadToEndAsync());
                }
                catch (Exception ex)
                {
                    return (T)new CkanApiResponseBase { IsSuccess = false, Error = new CkanApiResponseError { Message = ex.Message, Type = ex.GetType().Name } };
                }
            }
        }

        private string BuildQueryString(object parameters)
        {
            var result = new List<KeyValuePair<string, object>>();

            if (parameters != null)
            {
                foreach (var parameter in parameters.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    var value = parameter.GetValue(parameters);

                    if (value != null && (value is IEnumerable && !(value is string)))
                    {
                        foreach (var item in value as IEnumerable)
                            result.Add(new KeyValuePair<string, object>(parameter.Name, item));
                    }
                    else
                        result.Add(new KeyValuePair<string, object>(parameter.Name, value));
                }
            }

            return string.Join("&", result.Select(p => string.Format("{0}={1}", p.Key, p.Value)));
        }
    }
}
