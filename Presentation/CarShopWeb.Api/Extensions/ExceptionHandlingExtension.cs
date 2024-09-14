using CarShopWeb.Application.Models;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace CarShopWeb.Api.Extensions
{
    public static class ExceptionHandlingExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async content =>
                {
                    content.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    content.Response.ContentType = "application/json";
                    var ContentFeature = content.Features.Get<IExceptionHandlerFeature>();
                    if (ContentFeature != null)
                    {
                        await content.Response.WriteAsync(JsonSerializer.Serialize(new ErrorDetails()
                        {
                            StatusCode = content.Response.StatusCode,
                            Message = $"Internal Server Error: {ContentFeature.Error}"
                        }));

                    }
                });
            });
        }
    }
}
