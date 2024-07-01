using System.Text.Json.Serialization;
using FoodieAPI.Domain.Interfaces.Repositories;
using FoodieAPI.Domain.Interfaces.Services;
using FoodieAPI.Infra.Configuration;
using FoodieAPI.Infra.Context;
using FoodieAPI.Infra.Repositories;
using FoodieAPI.Services.Implementations;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;

namespace FoodieAPI.Web
{
  public class Startup(IConfiguration configuration)
  {
    public IConfiguration Configuration { get; } = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<DataContext>();
      services.AddScoped<IUserRepository, UsersRepository>();
      services.AddScoped<IStoreRepository, StoreRepository>();
      services.AddScoped<IUserService, UserService>();
      services.AddScoped<IStoreService, StoreService>();

      services.AddControllers().AddNewtonsoftJson(options =>
      {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
      });

      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen(config =>
            {
              config.SwaggerDoc("v1", new OpenApiInfo { Title = "FoodieAPI", Version = "v1" });
            });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }


      app.UseHttpsRedirection();

      app.UseRouting();

      // app.Use(async (context, next) => {
      //                                   await next();

      //                                   if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
      //                                   {
      //                                   await context.Response.WriteAsync("Token Validation Has Failed. Request Access Denied");
      //                                   }
      //                                   });

      // app.UseCors(corsOrigins);
      // app.UseAuthentication();
      // app.UseAuthorization();

      AppConfiguration.MainDatabaseConnectionString = Configuration.GetConnectionString("MainDatabase");

      app.UseEndpoints(endpoints =>
        endpoints.MapControllers()
      );
    }


  }
}