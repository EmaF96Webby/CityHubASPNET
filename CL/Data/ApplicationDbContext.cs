using Microsoft.EntityFrameworkCore;
using CL.Models;

namespace CL.Data;

public class ApplicationDbContext : DbContext
{
     public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
     { 
     }

     public DbSet<Booking> Bookings { get; set; }

}
