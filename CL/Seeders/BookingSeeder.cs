using CL.Factories;
using CL.Data;

namespace CL.Seeders;

public class BookingSeeder
{
     public static void SeedBookings(ApplicationDbContext context)
     {
          if (context.Bookings.Any()) { return; }
          var fakeBookings = BookingFactory.CreateFakeBookings(10);
          context.Bookings.AddRange(fakeBookings);
          return;
     }
}
