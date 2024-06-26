namespace FoodieAPI.Infra.Configuration
{
  public class AppConfiguration
  {
    public static string JWTKey { get; set; } = "NTEzN2MxMWUtMDkxNy00ODBmLWE2MzctNTdjNzcxMDE4N2Iz";

    public static bool IsDevelopment { get; set; } = false;

    public static string MainDatabaseConnectionString { get; set; }
    public static SMTPConfiguration SMTP = new();

    public class SMTPConfiguration
    {
      public string Host { get; set; }
      public int Port { get; set; }
      public string Username { get; set; }
      public string Password { get; set; }
    }
  }
}
