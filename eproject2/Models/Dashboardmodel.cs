using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eproject2.Models
{
    public class Dashboardmodel
    {
        [Key]
        public int Id { get; set; }  // ✅ Primary Key (Dashboard ka Unique Record)

        // ✅ Aggregated Data Fields
        public int TotalUsers { get; set; }
        public int TotalListings { get; set; }
        public int ActiveSubscriptions { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPayments { get; set; }

        // ✅ Navigation Properties (Lists)
        public virtual List<Users> RecentUsers { get; set; }
        public virtual List<Listing> RecentListings { get; set; }
        public virtual List<Payment> RecentPayments { get; set; }
        public virtual List<Location> Locations { get; set; }
        public virtual List<CategoryModel> Categories { get; set; }
        public virtual List<Report> AllReports { get; set; }
        public virtual List<UserProfiles> UserProfiles { get; set; }
        public virtual List<UserSubscriptionModel> ActiveUserSubscriptions { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;  // ✅ Timestamp for Record Tracking
    }
}
