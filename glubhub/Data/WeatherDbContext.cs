using Microsoft.EntityFrameworkCore;
namespace glubhub.Data
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
        {
        }
        public DbSet<glubhub.Models.Weather> Weathers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<glubhub.Models.Weather>(entity =>
            {
                entity.HasKey(e => e.WeatherId);
                entity.Property(e => e.Temperature).IsRequired();
                entity.Property(e => e.RainAmount).HasMaxLength(100);
                entity.Property(e => e.Cloudiness).HasMaxLength(100);
                entity.Property(e => e.AirPressure).HasMaxLength(100);
                entity.Property(e => e.WindSpeed).HasMaxLength(100);
            });
        }
    }
}
