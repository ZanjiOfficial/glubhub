using Microsoft.EntityFrameworkCore;
namespace glubhub.Data
{
    public class MessageDbContext : DbContext
    {
        MessageDbContext(DbContextOptions<MessageDbContext> options) : base(options)
        {

        }
        public DbSet<glubhub.Models.Message> Messages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<glubhub.Models.Message>(entity =>
            {
                entity.HasKey(e => e.MessageId);
                entity.Property(e => e.Content).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.SenderId).IsRequired().HasMaxLength(100);
                entity.Property(e => e.RecipentId).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Status).IsRequired();
            });
        }
    }
}
