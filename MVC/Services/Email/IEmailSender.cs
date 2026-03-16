using CL.Models;

namespace MVC.Services.Email;

public interface IEmailSender
{
     public Task SendBookingConfirmedAsync(Booking booking, string toEmail);

}
