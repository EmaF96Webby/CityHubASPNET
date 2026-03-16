using CL.Data;
using CL.Seeders;
using Microsoft.EntityFrameworkCore;
using MVC.Services.Email;
using RazorLight;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
var smtpSection = builder.Configuration.GetSection("Smtp");
builder.Services.Configure<SmtpOptions>(smtpSection);
builder.Services.AddSingleton<SmtpOptionsProvider>();
builder.Services.AddSingleton<SmtpOptions>(SmtpOptionsProvider.GetOptions);
builder.Services.AddSingleton<RazorLightEngineProvider>();
builder.Services.AddSingleton<RazorLightEngine>(RazorLightEngineProvider.GetEngine);
builder.Services.AddScoped<IEmailSender, SmtpEmailSender>();
builder.Services.AddScoped<IRazorRenderer, RazorRenderer>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

var scope = app.Services.CreateScope();
using (scope)
{
     var services = scope.ServiceProvider;
     SeedData.Initialize(services);
}



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
