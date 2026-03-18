using Microsoft.AspNetCore.Hosting;
using RazorLight;

namespace MVC.Services.Email;

public static class RazorLightEngineFactory
{
     public static RazorLightEngine Create(IServiceProvider sp)
     {
          var env = sp.GetRequiredService<IWebHostEnvironment>();

          string templatesRoot = Path.Combine(env.ContentRootPath, "Views");

          var builder = new RazorLightEngineBuilder();

          builder.UseFileSystemProject(templatesRoot);
          builder.UseMemoryCachingProvider();

          RazorLightEngine engine = builder.Build();

          return engine;
     }
}