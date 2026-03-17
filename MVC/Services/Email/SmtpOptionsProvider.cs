using Microsoft.Extensions.Options;

namespace MVC.Services.Email;

public class SmtpOptionsProvider
{
     public SmtpOptions Options { get; }

     public SmtpOptionsProvider(IOptions<SmtpOptions> optionsWrapper)
     {
          var options = optionsWrapper.Value;

          Options = options;
     }

     public static SmtpOptions GetOptions(IServiceProvider serviceProvider)
     {
          var service = serviceProvider.GetRequiredService<SmtpOptionsProvider>();

          var options = service.Options;

          return options;
     }
}