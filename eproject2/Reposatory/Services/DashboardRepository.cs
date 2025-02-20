using eproject2.Data;
using eproject2.Models;
using eproject2.Repositories.Interfaces;
using eproject2.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eproject2.Repositories.Services
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly Context _context;

        public DashboardRepository(Context context)
        {
            _context = context;
        }

        public async Task<DashboardViewModel> GetDashboardDataAsync()
        {
            var totalUsers = await _context.Users.CountAsync();
            var totalListings = await _context.Listings.CountAsync();
            var totalPayments = await _context.Payments.SumAsync(p => p.Amount);
            var activeSubscriptions = await _context.UserSubscriptions.CountAsync(s => s.IsActive);

            var recentUsers = await _context.Users.OrderByDescending(u => u.Id).Take(5).ToListAsync();
            var recentListings = await _context.Listings.OrderByDescending(l => l.ListingID).Take(5).ToListAsync();
            var recentPayments = await _context.Payments.OrderByDescending(p => p.PaymentID).Take(5).ToListAsync();
            var activeUserSubscriptions = await _context.UserSubscriptions.Where(s => s.IsActive).ToListAsync();

            return new DashboardViewModel
            {
                TotalUsers = totalUsers,
                TotalListings = totalListings,
                TotalPayments = totalPayments,
                ActiveSubscriptions = activeSubscriptions,
                RecentUsers = recentUsers,
                RecentListings = recentListings,
                RecentPayments = recentPayments,
                ActiveUserSubscriptions = activeUserSubscriptions
            };
        }
    }
}
