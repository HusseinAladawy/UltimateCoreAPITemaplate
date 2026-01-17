namespace UltimateCoreAPITemaplate.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ErrorHandlingMiddleware> logger;
        private bool IsDevelopment;

        public ErrorHandlingMiddleware(RequestDelegate _next, ILogger<ErrorHandlingMiddleware> _logger, bool isDevelopment)
        {
            next = _next;
            logger = _logger;
            IsDevelopment = isDevelopment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An unhandled exception has occurred while processing the request.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            string message = "An unexpected error occurred. Please try again later.";
            if (IsDevelopment)
            {
                message = exception.Message;
            }
            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            };
            var jsonResponse = System.Text.Json.JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(jsonResponse);
        }
    }

    // Extension method must be defined in a non-generic static class
    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder, bool isDevelopment)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>(isDevelopment);
        }
    }
}
