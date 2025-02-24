using eproject2.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace eproject2.Repositories.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Dashboardmodel>> GetAllDashboardDataAsync();
        Task<Dashboardmodel> GetDashboardByIdAsync(int id);
        Task AddDashboardDataAsync(Dashboardmodel dashboard);
        Task UpdateDashboardAsync(Dashboardmodel dashboard);
        Task DeleteDashboardAsync(int id);
    }
}
