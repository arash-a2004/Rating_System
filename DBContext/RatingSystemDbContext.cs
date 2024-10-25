using Microsoft.EntityFrameworkCore;
using Rating_Photo.Models.Authomation;

namespace Rating_Photo.DBContext
{
    public class RatingSystemDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public RatingSystemDbContext(DbContextOptions<RatingSystemDbContext> options,IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }
        public DbSet<Image> Images { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<ImageRatingSummery> ImageRatingSummeries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("RatingSystemDb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>()
                .HasOne(e => e.RatedImage)
                .WithOne(e => e.RatingProp)
                .HasForeignKey<Rating>(e => e.ImageId)
                .IsRequired();

            modelBuilder.Entity<Rating>()
                .HasOne(e =>e.user)
                .WithMany(e=>e.Ratings)
                .HasForeignKey(e => e.UserId)
                .IsRequired();

        }
    }
    
}
