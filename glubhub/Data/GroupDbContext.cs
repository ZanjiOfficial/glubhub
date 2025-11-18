using Microsoft.EntityFrameworkCore;
namespace glubhub.Data
{
    public class GroupDbContext : DbContext
    {
        GroupDbContext(DbContextOptions<GroupDbContext> options) : base(options)
        {
        }
        public DbSet<glubhub.Models.Group> Groups { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<glubhub.Models.Group>(entity =>
            {
                entity.HasKey(e => e.GroupId);
                entity.Property(e => e.Message).HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Members).IsRequired();
            });
        }
    }
}
