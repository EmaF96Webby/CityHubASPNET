using RazorLight;

namespace MVC.Services.Email;

public class RazorRenderer : IRazorRenderer
{
     private readonly RazorLightEngine _engine;

     public RazorRenderer(RazorLightEngine engine)
     {
          _engine = engine;
     }

     public Task<string> RenderAsync<T>(string templatePath, T model)
     {
          return _engine.CompileRenderAsync(templatePath, model);
     }
}