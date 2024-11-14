namespace FoodieAPI.Infra.Configuration;

public class AppConfiguration
{
  public static MongoConfigurationSettings MongoSettings = new();
  public static SMTPConfiguration SMTP = new();
  public static string JwtKey { get; set; }

  public static bool IsDevelopment { get; set; } = false;
  public static string MainDatabaseConnectionString { get; set; }

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
    public string? MongoUser { get; set; }
    public string? MongoPassword { get; set; }
    public string MongoHost { get; set; } = "localhost";
    public string MongoPort { get; set; } = "27017";


    public string GetMongoUrl()
    {
      if ( string.IsNullOrEmpty(MongoUser) && string.IsNullOrEmpty(MongoPassword) )
        return $"mongodb://{MongoHost}:{MongoPort}";

      return $"mongodb://{MongoUser}:{MongoPassword}@{MongoHost}:{MongoPort}";
    }
  }
}