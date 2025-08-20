using Apartment.Application.Exceptions;
using Apartment.Application.Logging;
using Apartment.DataAccess;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace API.Core
{
    public class RefreshTokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JwtManager manager;

        public RefreshTokenMiddleware(RequestDelegate next, JwtManager manager)
        {
            _next = next;
            this.manager = manager;

        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {
                string result = "";
                string token = "";
                var header = httpContext.Request.Headers.Any();
                string authorizationHeader = null;
                if (header) authorizationHeader = httpContext.Request.Headers["Authorization"].FirstOrDefault();

                if (authorizationHeader != null && authorizationHeader.StartsWith("Bearer "))
                {
                    token = authorizationHeader.Substring("Bearer ".Length);
                    result = manager.RefreshToken(token);
                }

                await _next(httpContext);

            }
            catch (System.Exception ex)
            {
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsJsonAsync(new {ex.Message});

            }
        }
    }
}

