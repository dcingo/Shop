using FluentValidation;
using Microsoft.AspNetCore.Http;
using Shop.Application.Common.Exceptions;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shop.WebAPI.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _netx;

        public CustomExceptionHandlerMiddleware(RequestDelegate netx)
        {
            _netx = netx;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _netx(context);
            }
            catch(Exception exception)
            {
                await HandExceptionAsyn(context, exception);
            }
        }

        private Task HandExceptionAsyn(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var resul = string.Empty;
            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    resul = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if(resul == string.Empty)
            {
                resul = JsonSerializer.Serialize(new {error = exception.Message});
            }

            return context.Response.WriteAsync(resul);

        }


    }
}
