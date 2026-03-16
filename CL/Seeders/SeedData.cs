using CL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CL.Seeders;

public class SeedData
{
     public static void Initialize(IServiceProvider serviceProvider)
     {
          var service = serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>();
          var context = new ApplicationDbContext(service);
          using (context)
          {
               BookingSeeder.SeedBookings(context);
               context.SaveChanges();
               
          }
          return;
     }
}
