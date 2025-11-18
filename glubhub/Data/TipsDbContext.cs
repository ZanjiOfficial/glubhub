using Microsoft.EntityFrameworkCore;
namespace glubhub.Data
{
    public class TipsDbContext :DbContext
    {
        public TipsDbContext(DbContextOptions<TipsDbContext> options) : base(options)
        {
        }
        public DbSet<glubhub.Models.Tips> Tips { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<glubhub.Models.Tips>(entity =>
            {
                entity.HasKey(e => e.TipsId);
                entity.Property(e => e.Text).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.Link).HasMaxLength(200);
            });
        }
    }
}
