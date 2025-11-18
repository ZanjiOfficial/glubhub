using Microsoft.EntityFrameworkCore;
namespace glubhub.Data
{
    public class TimeDbContext : DbContext
    {
        TimeDbContext(DbContextOptions<TimeDbContext> options) : base(options)
        {
        }
        public DbSet<glubhub.Models.Time> Times { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<glubhub.Models.Time>(entity =>
            {
                entity.HasKey(e => e.TimeId);
                entity.Property(e => e.Date).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Season).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Time1).IsRequired();
            });
        }
    }
    
}
