using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;

namespace BLL.Interfaces
{
    public class RestClient : IRestClient
    {
        public async Task<T> Get<T>(string url)
        {
            return await url.GetJsonAsync<T>();
        }

        public async Task<T> Post<T>(string url, string body)
        {
            var response = await url.PostJsonAsync(body);
            return await response.GetJsonAsync<T>();
        }
    }
}
