namespace MVC.Services.Email
{
     public interface IRazorRenderer
     {
          public Task<string> RenderAsync<T>(string templatePath, T model);
     }
}
