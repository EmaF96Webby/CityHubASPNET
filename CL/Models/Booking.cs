namespace CL.Models;

public class Booking
{
     public required int Id { get; set; }
     public required string Name { get; set; }
     public required string Surname { get; set; }
     public required DateTime ArrivalDate { get; set; }
     public required DateTime DepartureDate { get; set; }
     public required int NumberOfPeople { get; set; }
     public required string Email { get; set; }
}
