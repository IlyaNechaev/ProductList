using Microsoft.AspNetCore.Mvc.Filters;

namespace PL.Web.Middleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly Random _random;

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
            _random = new Random();
        }
        public async Task Invoke(HttpContext context,
            ILogger<ExceptionHandler> logger)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var logNumber = _random.Next();

                logger.LogError($"({logNumber})Ошибка контроллера: {ex.Message}");
                await context.Response.WriteAsync($"Internal Server Error. See logs for more details (log {logNumber})");
            }
        }
    }
}
