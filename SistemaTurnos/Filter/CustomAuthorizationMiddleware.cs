using SistemaTurnos.Common;
using System.Text.Json;

namespace SistemaTurnos.Filter
{
    public class CustomAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
            {
                context.Response.ContentType = "application/json";
                var result = JsonSerializer.Serialize(ErrorMessages.NeedLogIn);
                await context.Response.WriteAsync(result);
            }
            else if (context.Response.StatusCode == StatusCodes.Status403Forbidden)
            {
                context.Response.ContentType = "application/json";
                var result = JsonSerializer.Serialize(ErrorMessages.NeedLogIn);
                await context.Response.WriteAsync(result);
            }
        }
    }
}
