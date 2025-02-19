using eproject2.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace eproject2.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Users> Users { get; set; }


        public DbSet<SubscriptionPackage> SubscriptionPackages { get; set; }
        public DbSet<UserSubscriptionModel> UserSubscriptions { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<ListingImage> ListingImages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<ContactSubmission> ContactSubmissions { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

    }
}
