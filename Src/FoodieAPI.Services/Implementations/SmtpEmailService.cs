using System.Net;

using System.Net.Mail;
using FoodieAPI.Infra.Configuration;
using Serilog;

namespace FoodieAPI.Services.Implementations;

public static class SmtpEmailService
{
    private static readonly SmtpClient SmtpClient = new SmtpClient(AppConfiguration.SMTP.Host)
    {
        Port = AppConfiguration.SMTP.Port,
        Credentials = new NetworkCredential(AppConfiguration.SMTP.Username, AppConfiguration.SMTP.Password),
        EnableSsl = true
    };

    private static readonly ILogger Logger;

    public static bool SendEmail(string to, string subject, string body)
    {
        Logger.Information($"Sending email to {to} with subject {subject}");
        
        SmtpClient.Send("from@example.com", to, subject, body);

        return true;
    }
}