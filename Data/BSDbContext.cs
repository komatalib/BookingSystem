using BookingSystem.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Data
{
    public class BSDbContext: DbContext
    {
        public BSDbContext(DbContextOptions<BSDbContext> options) : base(options)
        { }

        public DbSet<Customers> Customers { get; set; }
    }
}
