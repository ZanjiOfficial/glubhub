using Microsoft.EntityFrameworkCore;
namespace glubhub.Data
{
    public class LocationDbContext : DbContext
    {
        public LocationDbContext(DbContextOptions<LocationDbContext> options) : base(options)
        {
        }
        public DbSet<glubhub.Models.Location> Locations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<glubhub.Models.Location>(entity =>
            {
                entity.HasKey(e => e.LocationId);
                entity.Property(e => e.Region).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Municipality).IsRequired().HasMaxLength(200);
                entity.Property(e => e.City).HasMaxLength(500);
                entity.Property(e => e.SpotType).HasMaxLength(500);
                entity.Property(e => e.CoordinatesX).HasMaxLength(500);
                entity.Property(e => e.CoordinatesY).HasMaxLength(500);
            });
        }
    }
}
