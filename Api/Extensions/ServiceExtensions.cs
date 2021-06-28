using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Extensions
{
   public static class ServiceExtensions
   {
      public static void ConfigureCors(this IServiceCollection services)
      {
         services.AddCors(options =>
         {
            options.AddPolicy("CorsPolicy", builder =>
            {
               builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
         });
      }

      public static void ConfigureSqlite(this IServiceCollection services, IConfiguration configuration)
      {
         services.AddDbContext<RepositoryContext>(options => options.UseSqlite(configuration.GetConnectionString("sqliteConnect"), b => b.MigrationsAssembly("Persistence")));
      }
   }
}
