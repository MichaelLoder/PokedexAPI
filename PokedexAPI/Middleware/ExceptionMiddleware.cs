using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace PokedexAPI.Middleware
{
    [Serializable]
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILogger<ExceptionMiddleware> logger)
        {
            try
            {
                await _next.Invoke(context).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.LogRequestException(context));

                HandleException(context);
            }
        }
        private static void HandleException(HttpContext context)
        {
            var response = context.Response;
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}
