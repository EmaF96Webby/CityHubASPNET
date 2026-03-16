using CL.Models;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace MVC.Services.Email;

public class SmtpEmailSender : IEmailSender
{
     private readonly SmtpOptions _options;
     private readonly IRazorRenderer _razor;

     private BodyBuilder _builder = null!;

     public SmtpEmailSender(SmtpOptions options, IRazorRenderer razor)
     {
          _options = options;
          _razor = razor;
     }

     public async Task SendBookingConfirmedAsync(Booking booking, string toEmail)
     {
          MimeMessage message = new MimeMessage();

          AddHeaders(message, toEmail);

          await AddBodyAsync(booking);

          AddAttachments();

          FinalizeBody(message);

          await SendMessageAsync(message);
     }

     // -------------------------
     // HEADERS
     // -------------------------

     private void AddHeaders(MimeMessage message, string toEmail)
     {
          MailboxAddress fromAddress = new MailboxAddress(_options.FromName, _options.FromEmail);
          MailboxAddress toAddress = MailboxAddress.Parse(toEmail);

          message.From.Add(fromAddress);
          message.To.Add(toAddress);
          message.Subject = "Grazie per la tua prenotazione";
     }

     // -------------------------
     // BODY
     // -------------------------

     private async Task AddBodyAsync(Booking booking)
     {
          string html = await _razor.RenderAsync("EmailTemplates/Bookings/Confirmed.cshtml", booking);

          _builder = new BodyBuilder
          {
               HtmlBody = html
          };
     }

     private void FinalizeBody(MimeMessage message)
     {
          message.Body = _builder.ToMessageBody();
     }

     // -------------------------
     // ATTACHMENTS
     // -------------------------

     private void AddAttachments()
     {
          // _builder.Attachments.Add("wwwroot/files/booking.pdf");
     }

     // -------------------------
     // SMTP
     // -------------------------

     private async Task SendMessageAsync(MimeMessage message)
     {
          using MailKit.Net.Smtp.SmtpClient client = new();

          await client.ConnectAsync(_options.Host, _options.Port, SecureSocketOptions.StartTls);

          await client.AuthenticateAsync(_options.Username, _options.Password);

          await client.SendAsync(message);

          await client.DisconnectAsync(true);
     }
}