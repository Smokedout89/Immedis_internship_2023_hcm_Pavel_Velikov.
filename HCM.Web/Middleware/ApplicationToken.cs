namespace HCM.Web.Middleware
{
    public class ApplicationToken
    {
        private readonly RequestDelegate _next;

        public ApplicationToken(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            string? token = httpContext.Session.GetString("ApplicationToken");

            if (!string.IsNullOrEmpty(token))
            {
                httpContext.Request.Headers.Add("ApplicationToken", token);
            }

            return _next(httpContext);
        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApplicationToken>();
        }
    }
}
