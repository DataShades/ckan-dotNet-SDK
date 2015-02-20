using Ckan.NetSdk.v3.Entities;
using Ckan.NetSdk.v3.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ckan.NetSdk.v3.Action
{
    public class UserActions : CkanApiActionBase
    {
        internal UserActions(CkanApiClient ckanApiClient)
            : base(ckanApiClient)
        {

        }

        /// <summary>
        /// Return a list of the site’s user accounts.
        /// </summary>
        public async Task<CkanApiResponseBase<List<CkanUser>>> GetAll(string query = null, string orderBy = null)
        {
            return await DoRequest<CkanApiResponseBase<List<CkanUser>>>("user_list", HttpMethod.Get, new { q = query, order_by = orderBy });
        }
    }
}
