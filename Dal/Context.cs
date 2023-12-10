using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Dal
{
    public class Context : DbContext
    {

        //public Context(DbContextOptions<Context> options)
        //    : base(options) { }
        //f
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ItilBooking;Username=postgres;Password=7076;Include Error Detail=true;");

            optionsBuilder.LogTo(DebugWrite);
        }

        public void DebugWrite(string text)
        {

            System.Diagnostics.Debug.Write(text);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Checkin> Checkins { get; set; }

        public DbSet<Room> Rooms { get; set; }
    }

}
