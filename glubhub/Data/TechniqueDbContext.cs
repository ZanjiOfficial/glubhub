using Microsoft.EntityFrameworkCore;
namespace glubhub.Data
{
    public class TechniqueDbContext : DbContext
    {
        TechniqueDbContext(DbContextOptions<TechniqueDbContext> options) : base(options)
        {
        }
        public DbSet<glubhub.Models.Technique> Techniques { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<glubhub.Models.Technique>(entity =>
            {
                entity.HasKey(e => e.TechniqueId);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
            });
        }
    }
}
