using Microsoft.EntityFrameworkCore;

namespace VeXeSieuRe;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Booking> Pages { get; set; }
    public DbSet<BookingDetail> Categories { get; set; }
    public DbSet<Bus> Buses { get; set; }
    public DbSet<BusSeat> BusSeats { get; set; }
    public DbSet<BusType> BusTypes { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<RouteStop> RouteStops { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<TripSeat> TripSeats { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Phone)
            .IsUnique();
        
        modelBuilder.Entity<RouteStop>()
            .HasKey(rs => new { rs.RouteId, rs.LocationId });
        modelBuilder.Entity<RouteStop>()
            .HasIndex(rs => new { rs.RouteId, rs.StopOrder })
            .IsUnique();

        modelBuilder.Entity<BookingDetail>()
            .HasOne(bd => bd.PickupLocation)
            .WithMany()
            .HasForeignKey(bd => bd.PickupLocationId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<BookingDetail>()
            .HasOne(bd => bd.DropoffLocation)
            .WithMany()
            .HasForeignKey(bd => bd.DropoffLocationId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        
        configurationBuilder.Properties<DateTime>().HaveColumnType("timestamp without time zone");
        configurationBuilder.Properties<DateTime?>().HaveColumnType("timestamp with time zone");
    }
}