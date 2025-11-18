using Microsoft.EntityFrameworkCore;
namespace glubhub.Data
{
    public class PictureDbContext : DbContext
    {
        PictureDbContext(DbContextOptions<PictureDbContext> options) : base(options)
        {

        }

        public DbSet<glubhub.Models.Picture> Pictures { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<glubhub.Models.Picture>(entity =>
            {
                entity.HasKey(e => e.PictureId);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Link).IsRequired().HasMaxLength(200);
            });
        }
    }
}
