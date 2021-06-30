using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Extensions
{
   public static class ExceptionMiddlewareExtension
   {
      public static void ConfigureExceptionHandler(this IApplicationBuilder app)
      {
         app.UseExceptionHandler(appError =>
         {
            appError.Run(async context =>
            {
               context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
               context.Response.ContentType = "application/json";

               var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

               if (contextFeature != null)
               {
                  Console.WriteLine(contextFeature.Error.StackTrace);
                  await context.Response.WriteAsync(
                     JsonSerializer.Serialize(
                        new
                        {
                           StatusCode = context.Response.StatusCode,
                           Message = "Internal server error"
                        })
                  );
               }
            });
         });
      }
   }
}
