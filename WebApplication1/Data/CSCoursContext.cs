using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;

namespace WebApplication1.Data
{
    public class CSCoursContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); optionsBuilder.UseNpgsql(@"Host=localhost;Database=BorovikDA_ASU;Username=postgres;Password=616948183161049vV")
                .UseSnakeCaseNamingConvention()
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())).EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().Property(p => p.ClientId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Parcel>().Property(p => p.ParcelId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Reception>().Property(p => p.ReceptionId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Client>().HasOne(au => au.Senders).WithOne(af => af.Clients).HasForeignKey<Sender>(au => au.ClientId);
            modelBuilder.Entity<Client>().HasOne(au => au.Receivers).WithOne(af => af.Clients).HasForeignKey<Receiver>(au => au.ClientId);
            modelBuilder.Entity<Sender>().HasMany(au => au.Parcels).WithOne(af => af.Senders);
            modelBuilder.Entity<Receiver>().HasMany(au => au.Parcels).WithOne(af => af.Receivers);
            modelBuilder.Entity<Reception>().HasMany(au => au.Parcels).WithOne(af => af.Receptions);

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Sender> Senders { get; set; }
        public DbSet<Receiver> Receivers { get; set; }
        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<Reception> Receptions { get; set; }
    }
}
