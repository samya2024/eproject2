using eproject2.Models;
using System.Collections.Generic;

namespace eproject2.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalUsers { get; set; }
        public int TotalListings { get; set; }
        public int ActiveSubscriptions { get; set; }
        public decimal TotalPayments { get; set; }
        

        public List<Users> RecentUsers { get; set; }
        public List<Listing> RecentListings { get; set; }
        public List<Payment> RecentPayments { get; set; }
        public List<Location> Locations { get; set; }
        public List<CategoryModel> Categories { get; set; } 
        public List<Report> AllReports { get; set; }
        public List<UserProfiles> UserProfiles { get; set; }
        public List<UserSubscriptionModel> ActiveUserSubscriptions { get; set; }
    }
}
