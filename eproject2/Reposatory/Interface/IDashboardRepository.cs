using eproject2.ViewModels;
using System.Threading.Tasks;

namespace eproject2.Repositories.Interfaces
{
    public interface IDashboardRepository
    {
        Task<DashboardViewModel> GetDashboardDataAsync();
    }
}
