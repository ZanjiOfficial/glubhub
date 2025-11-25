using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using glubhub.Models;

namespace glubhub.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
    

        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        //{
        //}

        //public DbSet<glubhub.Models.User> Users { get; set; }

        public DbSet<glubhub.Models.Fish> Fish { get; set; }
        public DbSet<glubhub.Models.Gear> Gear { get; set; }
        public DbSet<glubhub.Models.Group> Groups { get; set; }
        public DbSet<glubhub.Models.Location> Locations { get; set; }
        public DbSet<glubhub.Models.Message> Messages { get; set; }
        public DbSet<glubhub.Models.Picture> Pictures { get; set; }
        public DbSet<glubhub.Models.Post> Posts { get; set; }
        public DbSet<glubhub.Models.Technique> Techniques { get; set; }
        public DbSet<glubhub.Models.Time> Times { get; set; }
        public DbSet<glubhub.Models.Tips> Tips { get; set; }
        public DbSet<glubhub.Models.Weather> Weathers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User entity configuration
            //modelBuilder.Entity<glubhub.Models.User>(entity =>
            //{
            //    // Don't configure Id, Email, PasswordHash - Identity handles these
            //    entity.Property(e => e.Username).IsRequired().HasMaxLength(255);
            //    entity.Property(e => e.ProfilePicture).IsRequired();
            //    entity.Property(e => e.CreationDate).IsRequired(); // Fixed property name

            //    // Ignore collection properties for now
            //    entity.Ignore(e => e.Followers);
            //    entity.Ignore(e => e.Following);
            //});

            // Fish entity configuration 
            modelBuilder.Entity<glubhub.Models.Fish>(entity =>
            {
                entity.HasKey(e => e.FishId);
                entity.Property(e => e.Species).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Length).IsRequired();
                entity.Property(e => e.Weight).IsRequired();
            });

            // Gear entity configuration
            modelBuilder.Entity<glubhub.Models.Gear>(entity =>
            {
                entity.HasKey(e => e.GearId);
                entity.Property(e => e.Category).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
            });

            // Group entity configuration
            modelBuilder.Entity<glubhub.Models.Group>(entity =>
            {
                entity.HasKey(e => e.GroupId);
                entity.Property(e => e.Message).HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500);

                entity.HasMany(g => g.Members)
                      .WithMany(u => u.Groups)
                      .UsingEntity(j => j.ToTable("GroupMembers"));
            });

            // Location entity configuration
            modelBuilder.Entity<glubhub.Models.Location>(entity =>
            {
                entity.HasKey(e => e.LocationId);
                entity.Property(e => e.Region).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Municipality).IsRequired().HasMaxLength(200);
                entity.Property(e => e.City).HasMaxLength(500);
                entity.Property(e => e.SpotType).IsRequired();
                entity.Property(e => e.CoordinatesX).IsRequired();
                entity.Property(e => e.CoordinatesY).IsRequired();
            });




            // Message entity configuration
            modelBuilder.Entity<glubhub.Models.Message>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.Property(e => e.SenderId).IsRequired().HasMaxLength(450);
                entity.Property(e => e.RecipientId).IsRequired().HasMaxLength(450);
                entity.Property(e => e.Content).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.Status).IsRequired().HasDefaultValue(SeenStatus.Unseen);

                // Link to ApplicationUser instead of User
                entity.HasOne(m => m.Sender)
                      .WithMany()
                      .HasForeignKey(m => m.SenderId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(m => m.Recipient)
                      .WithMany()
                      .HasForeignKey(m => m.RecipientId)
                      .OnDelete(DeleteBehavior.Restrict);
            });




            // Picture entity configuration
            modelBuilder.Entity<glubhub.Models.Picture>(entity =>
            {
                entity.HasKey(e => e.PictureId);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Link).IsRequired().HasMaxLength(200);
            });

            // Post entity configuration
            modelBuilder.Entity<glubhub.Models.Post>(entity =>
            {
                entity.HasKey(e => e.PostId);
                entity.Property(e => e.Content).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.Comment).HasMaxLength(500);

                
                entity.HasOne(e => e.Location);
            });

            // Technique entity configuration
            modelBuilder.Entity<glubhub.Models.Technique>(entity =>
            {
                entity.HasKey(e => e.TechniqueId);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Weight).IsRequired();
            });

            // Time entity configuration
            modelBuilder.Entity<glubhub.Models.Time>(entity =>
            {
                entity.HasKey(e => e.TimeId);
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.Season).IsRequired();
                entity.Property(e => e.Time1).IsRequired();
            });

            // Tips entity configuration
            modelBuilder.Entity<glubhub.Models.Tips>(entity =>
            {
                entity.HasKey(e => e.TipsId);
                entity.Property(e => e.Text).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Type).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Link).HasMaxLength(200);
            });

            // Weather entity configuration
            //modelBuilder.Entity<glubhub.Models.Weather>(entity =>
            //{
            //    entity.HasKey(e => e.WeatherId);
            //    entity.Property(e => e.Temperature).IsRequired();
            //    entity.Property(e => e.RainAmount).IsRequired();
            //    entity.Property(e => e.Cloudiness).HasMaxLength(100);
            //    entity.Property(e => e.AirPressure).IsRequired();
            //    entity.Property(e => e.WindSpeed).IsRequired();
            //});
        }
    }
}
