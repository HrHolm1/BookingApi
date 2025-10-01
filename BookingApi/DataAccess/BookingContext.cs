using Microsoft.EntityFrameworkCore;

namespace BookingApi.DataAccess;

public class BookingContext : DbContext
{
    public DbSet<Models.Booking> Bookings { get; set; }
    public DbSet<Models.User> Users { get; set; }
    public DbSet<Models.Organization> Organizations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=10.176.111.34;Database=RRH-BookingDB;User Id=CSt2023_t_5; Password=CSt2023T5!24;TrustCertificate=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Booking");
        
        modelBuilder.Entity<Models.Booking>(entity =>
        {
            entity.HasKey(b => b.BookingId);
            entity.Property(b => b.ContactEmail).IsRequired().HasMaxLength(100);
            entity.Property(b => b.ContactPerson).IsRequired().HasMaxLength(100);
            entity.Property(b => b.ContactPhone).IsRequired().HasMaxLength(20);

            entity.HasOne(b => b.Organization)
                .WithMany(o => Bookings)
                .HasForeignKey(b => b.OrganizationId);
        });

        modelBuilder.Entity<Models.Organization>(entity =>
        {
            entity.HasKey(o => o.OrganizationId);
            entity.Property(o => o.Name).IsRequired().HasMaxLength(50);
            entity.Property(o => o.Type).IsRequired().HasMaxLength(50);
            entity.Property(o => o.FreeDaysPerYear).HasDefaultValue(0);
        });

        modelBuilder.Entity<Models.User>(entity =>
        {
            entity.HasKey(u => u.UserId);
            entity.Property(u => u.Name).IsRequired().HasMaxLength(100);
            entity.Property(u => u.Email).IsRequired().HasMaxLength(100);
            entity.Property(u => u.Role).IsRequired().HasMaxLength(50);
        });

    }
}