using App_Todo_Backend.Exceptions;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;

namespace App_Todo_Backend.Middleware
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionsMiddleware> _logger;

        public ExceptionsMiddleware(RequestDelegate next, ILogger<ExceptionsMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong while procesing {httpContext.Request.Path}: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            int statusCode = (int)HttpStatusCode.InternalServerError;

            var errorDetails = new ErrorDetails()
            {
                ErrorType = "Failure",
                ErrorMessage = exception.Message
            };

            switch (exception)
            {
                case NotFoundException:
                    statusCode = (int)HttpStatusCode.NotFound;
                    errorDetails.ErrorType = "Not Found";
                    break;
                case UnauthorizedAccessException:
                    statusCode = (int)HttpStatusCode.Unauthorized;
                    errorDetails.ErrorType = "Unauthorized";
                    break;
                case Exception:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    errorDetails.ErrorType = "Internal Server Error";
                    break;
                default:
                    break;
            }

            string result = JsonConvert.SerializeObject(errorDetails);
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(result);
        }
    }

    internal class ErrorDetails
    {
        public ErrorDetails()
        {
        }

        public string ErrorType { get; set; }
        public string ErrorMessage { get; set; }
    }
}
