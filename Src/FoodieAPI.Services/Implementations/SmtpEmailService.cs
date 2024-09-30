using MailKit.Net.Smtp;
using FoodieAPI.Infra.Configuration;
using MimeKit;

namespace FoodieAPI.Services.Implementations;

public static class SmtpEmailService
{
    public static bool SendEmail(string to, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Foodie", "no-respond@foodie.com"));
        message.To.Add(new MailboxAddress("User",to));
        message.Subject = subject;


        var bodyBuilder = new BodyBuilder
        {
            HtmlBody = body
        };

        message.Body = bodyBuilder.ToMessageBody();
        
        using var client = new SmtpClient();
        try
        {
            client.Connect(AppConfiguration.SMTP.Host, AppConfiguration.SMTP.Port, false);
            client.Authenticate(AppConfiguration.SMTP.Username, AppConfiguration.SMTP.Password);
            client.Send(message);
            client.Disconnect(true);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return true;
    }
}