using Microsoft.EntityFrameworkCore;
using ProBookingAPI.Models;

namespace ProBookingAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<ProBookingModel> Bookings { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }
    }
}
