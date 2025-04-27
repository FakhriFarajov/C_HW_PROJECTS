using System.Data.SqlTypes;
 using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;


public class EmailMessage
{
    public string From { get; set; }
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}

public class EmailSender
{
    public void SendEmail(EmailMessage emailMessage)
    {
        var configBuilder = new ConfigurationBuilder();

        configBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        var config = configBuilder.Build();
        
        
        var smtpHost = config["Smtp:Host"];
        var smtpPort = config["Smtp:Port"];
        var smtpUser = config["Smtp:Username"];
        var smtpPassword = config["Smtp:Password"];
        
        using var smtpClient = new SmtpClient(smtpHost, int.Parse(smtpPort))
        {
            Credentials = new NetworkCredential(smtpUser, smtpPassword),
            EnableSsl = true
        };
        
        using var message = new MailMessage()
        {
            From = new MailAddress(emailMessage.From),
            Subject = emailMessage.Subject,
            Body = emailMessage.Body,
            IsBodyHtml = false
        };
        message.To.Add(emailMessage.To);

        try
        {
            smtpClient.Send(message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}