using eproject2.Data;
using eproject2.Models;
using eproject2.Reposatory.Interface;
using eproject2.Repositories.Interfaces;
using eproject2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eproject2.Repositories.Services
{
    public class CrudContrroller : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;



        public CrudContrroller(IDashboardRepository dashboardRepository)



        {
            this._dashboardRepository = dashboardRepository;


        }

        public async Task<IActionResult> Dashboard()
        {
            return View();
        }

        [Route("dashboard/data")]
        public async Task<IActionResult> GetDashboardData()
        {
            var result = await _dashboardRepository.GetDashboardDataAsync();
            return View(result);
        }



        public async Task<IActionResult> Create()
        {
            return View();
        }

    }
}

