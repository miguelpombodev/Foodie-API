using Serilog;
using Serilog.Formatting.Json;

namespace FoodieAPI.Web
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = CreateHostBuilder(args);
      host.UseSerilog((context, loggerConfig) =>
      {
        loggerConfig.WriteTo.Console(new JsonFormatter());
      });
      host.Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
      {
        webBuilder.UseStartup<Startup>();
      });
  }
}