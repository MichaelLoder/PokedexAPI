using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PokedexAPI.Middleware
{
    public static class ExceptionExtension
    {
        public static string LogRequestException(this Exception ex, HttpContext content)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{content.Request.Path}{content.Request.QueryString.ToString()}");
            stringBuilder.AppendLine(ex.ToString());
            return stringBuilder.ToString();
        }
    }
}
