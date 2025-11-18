using Microsoft.EntityFrameworkCore;

namespace glubhub.Data
{
    public class FishDbContext : DbContext
    {
        FishDbContext(DbContextOptions<FishDbContext> options) : base(options)
        {
        }

        public DbSet<glubhub.Models.Fish> Fish { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<glubhub.Models.Fish>(entity =>
            {
                entity.HasKey(e => e.FishId);
                entity.Property(e => e.Species).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Length).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Weight).IsRequired();
            });
        }
    }
}
