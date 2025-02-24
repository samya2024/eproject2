using eproject2.Data;
using eproject2.Models;
using eproject2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eproject2.Repositories.Services
{
    public class DashboardService : IDashboardRepository
    {
        private readonly Context _context;

        public DashboardService(Context context)
        {
            _context = context;
        }

        public async Task<List<Dashboardmodel>> GetAllDashboardDataAsync()
        {
            return await _context.dashboard.ToListAsync();
        }

        public async Task<Dashboardmodel> GetDashboardByIdAsync(int id)
        {
            return await _context.dashboard.FindAsync(id);
        }

        public async Task AddDashboardDataAsync(Dashboardmodel dashboard)
        {
            await _context.dashboard.AddAsync(dashboard);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDashboardAsync(Dashboardmodel dashboard)
        {
            _context.dashboard.Update(dashboard);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDashboardAsync(int id)
        {
            var dashboard = await _context.dashboard.FindAsync(id);
            if (dashboard != null)
            {
                _context.dashboard.Remove(dashboard);
                await _context.SaveChangesAsync();
            }
        }
    }
}
