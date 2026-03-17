using Microsoft.AspNetCore.Hosting;
using RazorLight;

namespace MVC.Services.Email;

public class RazorLightEngineFactory
{
     private readonly IWebHostEnvironment _env;

     public RazorLightEngineFactory(IWebHostEnvironment env)
     {
          _env = env;
     }

     public RazorLightEngine Create()
     {
          // 1. Cartella dei template
          string templatesRoot = Path.Combine(_env.ContentRootPath, "Views");

          // 2. Builder
          var builder = new RazorLightEngineBuilder();

          // 3. Configurazioni separate
          builder.UseFileSystemProject(templatesRoot);
          builder.UseMemoryCachingProvider();

          // 4. Creazione dell’engine
          RazorLightEngine engine = builder.Build();

          // 5. Ritorno dell’engine
          return engine;
     }
}