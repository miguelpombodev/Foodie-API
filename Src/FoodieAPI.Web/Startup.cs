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
    private IConfiguration Configuration { get; } = configuration;

    private void ConfigureApplicationSettings()
    {
      AppConfiguration.JwtKey = Configuration.GetSection("JWTKey").Value;
      AppConfiguration.MainDatabaseConnectionString = Configuration.GetConnectionString("MainDatabase");
      
      var mongoSettings = new AppConfiguration.MongoConfigurationSettings();
      Configuration.GetSection("MongoSettings").Bind(mongoSettings);
      AppConfiguration.MongoSettings = mongoSettings;
      
      var smtp = new AppConfiguration.SMTPConfiguration();
      Configuration.GetSection("SMTPConfiguration").Bind(smtp);
      AppConfiguration.SMTP = smtp;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      ConfigureApplicationSettings();
      
      services.AddDbContext<DataContext>();
      services.AddScoped<IUserRepository, UsersRepository>();
      services.AddScoped<IStoreRepository, StoreRepository>();
      services.AddScoped<IProductRepository, ProductsRepository>();
      services.AddScoped<IMiscelaneousRepository, MiscelaneousRepository>();
      services.AddScoped<IUserService, UserService>();
      services.AddScoped<IStoreService, StoreService>();
      services.AddScoped<IProductsService, ProductService>();
      services.AddScoped<IMiscelaneousService, MiscelaneousService>();
      services.AddScoped<ICacheService, CacheService>();
      services.AddSingleton<IDataEncryptionService, DataEncryptionService>();
      services.AddSingleton<MongoConfiguration>();

      services.AddStackExchangeRedisCache(options =>
      {
        options.Configuration = Configuration.GetConnectionString("RedisConnection");
        options.InstanceName = "FoodieAPI";
      });

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
              config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
              {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                Scheme = "Bearer"
              });
              config.AddSecurityDefinition("refresh_token", new OpenApiSecurityScheme
              {
                Description = "Add here the refresh token created when the login endpoint response",
                Name = "refresh_token",
                In = ParameterLocation.Header,
              });

              config.AddSecurityRequirement(new OpenApiSecurityRequirement
              {
                  {
                      new OpenApiSecurityScheme
                      {
                          Reference = new OpenApiReference
                          {
                              Type=ReferenceType.SecurityScheme,
                              Id="Bearer"
                          }
                      },
                      new string[]{}
                  }
              });
            });

      var key = Encoding.ASCII.GetBytes(AppConfiguration.JwtKey);
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
          ValidateAudience = false,
          ValidateLifetime = true
        };
      });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        AppConfiguration.IsDevelopment = true;
        app.UseSwagger();
        app.UseSwaggerUI();
      }
      app.UseExceptionHandler();

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCors("_myAllowSpecificOrigins");
      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
        endpoints.MapControllers()
      );
    }


  }
}