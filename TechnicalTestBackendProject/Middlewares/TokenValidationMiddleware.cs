using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.Middlewares
{
    public class TokenValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ITokenRepository _tokenRepository;

        public TokenValidationMiddleware(RequestDelegate next, ITokenRepository tokenRepository)
        {
            _next = next;
            _tokenRepository = tokenRepository;
        }

        public async Task Invoke(HttpContext context)
        {
            // Check if the request is for the public API
            var path = context.Request.Path.Value?.ToLower();
            if (path?.StartsWith("/api/public") == true)
            {
                await _next(context);
                return;
            }

            // Check if the user is authenticated
            if (!context.User.Identity?.IsAuthenticated ?? true)
            {
                await _next(context);
                return;
            }

            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (!string.IsNullOrEmpty(token) && !await _tokenRepository.IsTokenValidAsync(token))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid token or expired.");
                return;
            }

            await _next(context);
        }
    }
}
