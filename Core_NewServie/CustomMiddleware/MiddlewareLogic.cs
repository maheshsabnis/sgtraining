using System;
using System.ComponentModel;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
 

namespace Core_NewServie.CustomMiddleware
{

    public class ExceptionInformation
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class CustomExceptionMiddlewareLogic
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddlewareLogic(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Method will be invoked by RequestDelegate
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext ctx)
        {
            try
            {
                // if no exception continue with next middleare in pipeline
                await _next(ctx);
            }
            catch (Exception ex)
            {
                // write logic for handling exception
                // 1. Set the custom error code
                ctx.Response.StatusCode = 500; // internal server error
                var errorInfo = new ExceptionInformation()
                {
                     ErrorCode = ctx.Response.StatusCode,
                     ErrorMessage = ex.Message
                };

                // 2. Serialize the Error Message in JSON format and wtrite into response
                var errorMessage = JsonSerializer.Serialize(errorInfo);

                await ctx.Response.WriteAsync(errorMessage);
            }
        }
    }

    /// <summary>
    /// Class that contains extension method to register
    /// the middleware into pipeline
    /// </summary>
    public static class CustomMiddlewareExpension
    {
        /// <summary>
        /// This will be an extension method for IApplicationBuilder
        /// </summary>
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddlewareLogic>();
        }
    }
}
