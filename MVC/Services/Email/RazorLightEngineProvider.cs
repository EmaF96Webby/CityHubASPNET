using Microsoft.AspNetCore.Hosting;
using RazorLight;

namespace MVC.Services.Email;

public class RazorLightEngineProvider
{
     public RazorLightEngine Engine { get; }

     public RazorLightEngineProvider(IWebHostEnvironment env)
     {
          var templatesRoot = Path.Combine(env.ContentRootPath, "Views");

          var builder = new RazorLightEngineBuilder();

          builder.UseFileSystemProject(templatesRoot);

          builder.UseMemoryCachingProvider();

          var engine = builder.Build();

          Engine = engine;
     }

     public static RazorLightEngine GetEngine(IServiceProvider serviceProvider)
     {
          var service = serviceProvider.GetRequiredService<RazorLightEngineProvider>();

          var engine = service.Engine;

          return engine;
     }

}