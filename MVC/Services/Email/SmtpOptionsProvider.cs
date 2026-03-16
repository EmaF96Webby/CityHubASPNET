using Microsoft.Extensions.Options;

namespace MVC.Services.Email;

public class SmtpOptionsProvider
{
     public SmtpOptions Options { get; }

     public SmtpOptionsProvider(IOptions<SmtpOptions> options)
     {
          Options = options.Value;
     }

     public static SmtpOptions GetOptions(IServiceProvider serviceProvider)
     {
          var optionsWrapper = serviceProvider.GetRequiredService<IOptions<SmtpOptions>>();

          var options = optionsWrapper.Value;

          return options;
     }

}