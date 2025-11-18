using Microsoft.EntityFrameworkCore;
namespace glubhub.Data
{
    public class PostDbContext : DbContext
    {
        PostDbContext(DbContextOptions<PostDbContext> options) : base(options)
        {
        }
        public DbSet<glubhub.Models.Post> Posts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<glubhub.Models.Post>(entity =>
            {
                entity.HasKey(e => e.PostId);
                entity.Property(e => e.Content).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.Location).HasMaxLength(255);
                entity.Property(e => e.Comment).HasMaxLength(500);
            });
        }
    }
}
