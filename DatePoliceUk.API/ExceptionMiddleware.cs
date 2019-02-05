using DataPoliceUk.ErrorHandling;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace DatePoliceUk.API
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILoggerManager _logger;

        public ExceptionMiddleware(RequestDelegate next) //, ILoggerManager logger)
        {
            //_logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                if (httpContext.Response.HasStarted)
                { 
                    //_logger.LogWarning("The response has already started, the http status code middleware will not be executed.");
                    throw;
                }

                //_logger.LogError($"Something went wrong: {ex}");
                httpContext.Response.Clear();
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var exceptionType = ex.InnerException.GetType();
                if (exceptionType == typeof(ApiRequestException))
                {
                    var e = ex.InnerException as ApiRequestException;
                    httpContext.Response.StatusCode = (int)e.StatusCode;
                    httpContext.Response.ContentType = "application/json";
                }
                
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToString());
        }
    }
}
