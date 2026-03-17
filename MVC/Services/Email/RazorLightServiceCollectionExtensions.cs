using Microsoft.Extensions.DependencyInjection;
using RazorLight;

namespace MVC.Services.Email;

public static class RazorLightServiceCollectionExtensions
{
     public static IServiceCollection AddRazorLightEngine(this IServiceCollection services)
     {
          // Registriamo la factory
          services.AddSingleton<RazorLightEngineFactory>();

          // Creiamo l'istanza e la registriamo direttamente
          var serviceProvider = services.BuildServiceProvider();
          var factory = serviceProvider.GetRequiredService<RazorLightEngineFactory>();
          var engine = factory.Create();
          services.AddSingleton(engine);

          return services;
     }
}