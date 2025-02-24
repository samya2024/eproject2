using eproject2.Repositories.Interfaces;
using eproject2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eproject2.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }
        [Route("Dashboard")]
        [HttpGet]

        public async Task<IActionResult> Dashboard()
        {
            var dashboardDataList = await _dashboardRepository.GetAllDashboardDataAsync();

            if (dashboardDataList == null || !dashboardDataList.Any())
            {
                return View(new List<Dashboardmodel>());
            }

            return View(dashboardDataList);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Dashboardmodel dashboard)
        {
            if (!ModelState.IsValid)
            {
                return View(dashboard);
            }

            await _dashboardRepository.AddDashboardDataAsync(dashboard);
            return RedirectToAction("Dashboard");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dashboard = await _dashboardRepository.GetDashboardByIdAsync(id);
            if (dashboard == null)
                return NotFound();

            return View(dashboard);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Dashboardmodel dashboard)
        {
            if (!ModelState.IsValid)
            {
                return View(dashboard);
            }

            await _dashboardRepository.UpdateDashboardAsync(dashboard);
            return RedirectToAction("Dashboard");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _dashboardRepository.DeleteDashboardAsync(id);
            return RedirectToAction("Dashboard");
        }
    }
}
