using Microsoft.AspNetCore.Http;
using ItBolt;
using ApiClient.Services;

namespace ApiClient.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        public JwtMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IFelhasznaloService felhasznaloService, IJwtUtils jwtUtils)
        {
            var token1 = context.Request.Headers.Authorization.FirstOrDefault();
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var felhId = jwtUtils.ValidateJwtToken(token);
            if (felhId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["Felhasznalo"] = felhasznaloService.GetById(felhId.Value);
            }

            await _next(context);

        }
    }
}
