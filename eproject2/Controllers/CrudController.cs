using eproject2.Data;
using eproject2.Models;
using eproject2.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eproject2.Controllers
{
    public class CrudController : Controller
    {
        private readonly IAuthRepository _authRepository;
        private readonly Context _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public Users UserSubscriptions { get; private set; }

        public CrudController(IAuthRepository authRepository, Context context, IWebHostEnvironment webHostEnvironment)
        {

            this._context = context;
            this._webHostEnvironment = webHostEnvironment;
            


        }

        

        
      
        public async Task<IActionResult> Index(UserSubscriptionModel subscription)
        {
            var subscriptions = await _context.UserSubscriptions.ToListAsync();
            return View(subscriptions);
        }

          //GET: /Subscriptions/Create
        public IActionResult Create( )
        {
            return View();
        } 

        // 📌 POST: /Subscriptions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,PackageID,StartDate,ExpiryDate,IsActive")] UserSubscriptionModel subscription)

        {
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "Username");
            ViewData["PackageID"] = new SelectList(_context.SubscriptionPackages, "PackageID", "PackageName");

            if (ModelState.IsValid)
            {
                _context.Add(subscription);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(subscription);
        }

        // 📌 GET: /Subscriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var subscription = await _context.UserSubscriptions.FindAsync(id);
            if (subscription == null) return NotFound();

            return View(subscription);
        }

        // 📌 POST: /Subscriptions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubscriptionID,UserID,PackageID,StartDate,ExpiryDate,IsActive")] UserSubscriptionModel subscription)
        {
            if (id != subscription.SubscriptionID) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(subscription);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(subscription);
        }

        // 📌 GET: /Subscriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var subscription = await _context.UserSubscriptions.FindAsync(id);
            if (subscription == null) return NotFound();

            return View(subscription);
        }

        // 📌 POST: /Subscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subscription = await _context.UserSubscriptions.FindAsync(id);
            if (subscription != null)
            {
                _context.UserSubscriptions.Remove(subscription);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}