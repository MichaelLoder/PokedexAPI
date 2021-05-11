using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRestClient
    {
        Task<T> Get<T>(string url);
        Task<T> Post<T>(string url, string body);
    }
}
