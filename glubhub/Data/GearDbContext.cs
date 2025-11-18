using Microsoft.EntityFrameworkCore;
namespace glubhub.Data
{
    public class GearDbContext  : DbContext
    {
        GearDbContext(DbContextOptions<GearDbContext> options) : base(options)
        {
        }
        public DbSet<glubhub.Models.Gear> Gear { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<glubhub.Models.Gear>(entity =>
            {
                entity.HasKey(e => e.GearId);
                entity.Property(e => e.Category).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
            });
        }
    }
}
