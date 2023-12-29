using BookingSystem.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Data
{
    public class BSDbContext: DbContext
    {
        public BSDbContext(DbContextOptions<BSDbContext> options) : base(options)
        { }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Plans> Plans { get; set; }
        public DbSet<Date> Date { get; set; }
        public DbSet<GroupTraining> GroupTraining { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Time> Time { get; set; }
        public DbSet<TrainingBooking> TrainingBooking { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customers>()
                .HasOne(c => c.Plans)
                .WithMany()
                .HasForeignKey(c => c.PlanID)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

    }
}
