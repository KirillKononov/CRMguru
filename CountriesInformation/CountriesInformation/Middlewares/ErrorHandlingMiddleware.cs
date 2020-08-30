using System;
using System.Net;
using System.Threading.Tasks;
using CountriesInformation.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CountriesInformation.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;

            var result = new ErrorViewModel
            {
                ErrorCode = (int)HttpStatusCode.InternalServerError,
                ErrorMessage = ex.Message,
                Succeed = false,
            };

            var jsonResult = JsonConvert.SerializeObject(result);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) code;
            return context.Response.WriteAsync(jsonResult);
        }
    }
}
