namespace FoodieAPI.Infra.Configuration
{
  public class AppConfiguration
  {
    public static string JwtKey { get; set; }

    public static bool IsDevelopment { get; set; } = false;

    public static MongoConfigurationSettings MongoSettings = new();
    public static string MainDatabaseConnectionString { get; set; }
    public static SMTPConfiguration SMTP = new();

    public class SMTPConfiguration
    {
      public string Host { get; set; }
      public int Port { get; set; }
      public string Username { get; set; }
      public string Password { get; set; }
    }

    public class MongoConfigurationSettings
    {
      public string DatabaseName { get; set; }
      public string CollectionName { get; set; }
      public string MongoUser { get; set; }
      public string MongoPassword { get; set; }
      public string MongoHost { get; set; }
      public string MongoPort { get; set; }
    }
  }
}
