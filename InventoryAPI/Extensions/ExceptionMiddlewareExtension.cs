using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace InventoryAPI.Extentions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerFactory logger)
        {
            //app.UseMiddleware<ExceptionMiddleware>();
            app.UseExceptionHandler(appError =>
            {

                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    //context.Request.

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var log = logger.CreateLogger("ConfigureExceptionHandler");
                        Exception exception = contextFeature.Error;
                        int code = 111;
                        string message = "Error processing request";

                        log.LogError(exception, exception.Message, null);

                        var responseString = JsonConvert.SerializeObject(new
                        {
                            Status = code,
                            Message = message
                        });

                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await context.Response.WriteAsync(responseString);
                    }
                });
            });
        }
    }
}
