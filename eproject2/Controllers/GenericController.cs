using eproject2.Data;
using eproject2.Models;
using eproject2.Reposatory.Interface;
using eproject2.Repositories.Interfaces;
using eproject2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eproject2.Controllers
{
    public class GenericController<T> : Controller where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IAuthRepository _authRepository;
        private readonly Context _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IEmailSender _emailSender;
        private readonly IUnitOfWork _unitOfWork;

        public GenericController(
            IGenericRepository<T> repository,
            IAuthRepository authRepository,
            Context context,
            IWebHostEnvironment webHostEnvironment,
            IEmailSender emailSender,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _authRepository = authRepository;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _emailSender = emailSender;
            _unitOfWork = unitOfWork;
        }

        // 🔹 List all items
        public async Task<IActionResult> Index()
        {
            var items = await _repository.GetAllAsync();
            return View(items);
        }

        // 🔹 Create GET
        public IActionResult Create()
        {
            return View();
        }

        // 🔹 Create POST
        [HttpPost]
        public async Task<IActionResult> Create(T entity)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(entity);
                await _repository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // 🔹 Update GET
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        // 🔹 Update POST
        [HttpPost]
        public async Task<IActionResult> Edit(int id, T entity)
        {
            if (ModelState.IsValid)
            {
                await _repository.UpdateAsync(entity);
                await _repository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // 🔹 Delete GET
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        // 🔹 Delete POST
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
