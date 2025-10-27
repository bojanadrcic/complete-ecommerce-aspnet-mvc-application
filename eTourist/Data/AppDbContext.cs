using eTourist.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eTourist.Data
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TourGuide_Arrangement>().HasKey(ta => new
            {
                ta.TourGuideId,
                ta.ArrangementId,
            });

            modelBuilder.Entity<TourGuide_Arrangement>().HasOne (a => a.Arrangement).WithMany (ta => ta.TourGuides_Arrangements).HasForeignKey (a => a.ArrangementId);
            modelBuilder.Entity<TourGuide_Arrangement>().HasOne(a => a.TourGuide).WithMany(ta => ta.TourGuides_Arrangements).HasForeignKey(a => a.TourGuideId);


            base.OnModelCreating(modelBuilder);

        }
        public DbSet<TourGuide> TourGuides { get; set; }
        public DbSet<Arrangement> Arrangements { get; set; }

        public DbSet<TourGuide_Arrangement> TourGuides_Arrangements { get; set; }

        public DbSet<Destination> Destinations { get; set; }

        public DbSet<TravelAgency> TravelAgencies { get; set; }

        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
