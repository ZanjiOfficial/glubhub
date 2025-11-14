using Microsoft.EntityFrameworkCore;


namespace glubhub.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

        public DbSet<glubhub.Models.User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<glubhub.Models.User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.ProfilePicture).IsRequired();
                entity.Property(e => e.Creationdate).IsRequired();
                entity.Property(e => e.Followers).IsRequired();
                entity.Property(e => e.Following).IsRequired();
                entity.Property(e => e.Groups).IsRequired();

            });
        }
    }
}
