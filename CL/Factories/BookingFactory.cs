using Bogus;
using CL.Models;

namespace CL.Factories;

public class BookingFactory
{
     private static Faker<Booking> CreateFaker()
     {
          var faker = new Faker<Booking>("it")
               .RuleFor(s => s.Name, f => f.Name.FirstName())
               .RuleFor(s => s.Surname, f => f.Name.LastName())
               .RuleFor(a => a.ArrivalDate, f => f.Date.Past(200))
               .RuleFor(a => a.DepartureDate, f => f.Date.Past(200))
               .RuleFor(c => c.NumberOfPeople, f => f.Random.Int(1, 10))
               .RuleFor(e => e.Email, f => f.Internet.Email());

          return faker;

     }

     public static List<Booking> CreateFakeBookings(int count)
     {
          var faker = CreateFaker();
          var bookings = faker.Generate(count);
          return bookings;
     }

}
