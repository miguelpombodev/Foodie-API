using Microsoft.AspNetCore.Authentication.JwtBearer;
using FoodieAPI.Domain;
using FoodieAPI.Domain.Interfaces.Repositories;
using FoodieAPI.Domain.Interfaces.Services;
using FoodieAPI.Infra;
using FoodieAPI.Infra.Configuration;
using FoodieAPI.Infra.Context;
using FoodieAPI.Infra.Repositories;
using FoodieAPI.Services;
using FoodieAPI.Services.Implementations;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
      services.AddScoped<IProductRepository, ProductsRepository>();
      services.AddScoped<IUserService, UserService>();
      services.AddScoped<IStoreService, StoreService>();
      services.AddScoped<IProductsService, ProductService>();
      services.AddSingleton<IDataEncryptionService, DataEncryptionService>();
      services.AddSingleton<ITokenService, TokenService>();

      services.AddCors(options =>
          {
            options.AddPolicy(name: "_myAllowSpecificOrigins", policy =>
            {
              policy.AllowAnyOrigin();
              policy.AllowAnyHeader();
              policy.AllowAnyMethod();
            });
          });

      services.AddProblemDetails().AddExceptionHandler<GlobalExceptionHandler>();

      services.AddControllers().AddNewtonsoftJson(options =>
      {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
      });

      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen(config =>
            {
              config.EnableAnnotations();
              config.SwaggerDoc("v1", new OpenApiInfo { Title = "FoodieAPI", Version = "v1" });
            });

      var key = Encoding.ASCII.GetBytes(AppConfiguration.JWTKey);
      services.AddAuthentication(option =>
      {
        option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(option =>
      {
        option.RequireHttpsMetadata = false;
        option.SaveToken = true;
        option.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = false,
          ValidateAudience = false
        };
      });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }
      app.UseExceptionHandler();

      app.UseHttpsRedirection();

      app.UseRouting();

      // app.Use(async (context, next) => {
      //                                   await next();

      //                                   if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
      //                                   {
      //                                   await context.Response.WriteAsync("Token Validation Has Failed. Request Access Denied");
      //                                   }
      //                                   });

      app.UseCors("_myAllowSpecificOrigins");
      app.UseAuthentication();
      app.UseAuthorization();

      AppConfiguration.MainDatabaseConnectionString = Configuration.GetConnectionString("MainDatabase");

      app.UseEndpoints(endpoints =>
        endpoints.MapControllers()
      );
    }


  }
}