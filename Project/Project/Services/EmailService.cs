using System.Net;
using System.Net.Mail;
using System.Text;
using Microsoft.Extensions.Configuration;
using Project.Models;


namespace Project.Services;

public static class EmailService
{
    public static void SendEmail(User user)
    {
        var configBuilder = new ConfigurationBuilder();

        configBuilder.AddJsonFile("appSettings.json", optional: false, reloadOnChange: true);

        var config = configBuilder.Build();

        var smtpHost = config["SMTP:Host"];
        var smtpPort = config["SMTP:Port"];
        var smtpUsername = config["SMTP:Username"];
        var smtpPassword = config["SMTP:Password"];


        string htmlBody = File.ReadAllText("Templates/EmailTemplate.html");

        using var mailMessage = new MailMessage()
        {
            From = new MailAddress("MAIL"), // ENTER YOUR MAIL
            Subject = "Test Email",
            Body = htmlBody,
            IsBodyHtml = true,
        };
        
        using var smtpClient = new SmtpClient(smtpHost, int.Parse(smtpPort))
        {
            Credentials = new NetworkCredential(smtpUsername, smtpPassword),
            EnableSsl = true,
        };
        
        mailMessage.To.Add(new MailAddress(user.Email));
        
        // Прикрепляем PDF-файлы
        foreach (var path in PdfService.pdfPaths) // pdfPaths — список путей к созданным PDF
        {
            mailMessage.Attachments.Add(new Attachment(path));
        }

        smtpClient.Send(mailMessage);
        
    }
}