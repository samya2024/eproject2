using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eproject2.Data;
using eproject2.Models;
using eproject2.Reposatory.Interface;
using eproject2.Reposatory.Services;
using eproject2.Repositories.Interfaces;
using eproject2.Repositories.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace eproject2.Controllers
{
    public class UserProfilesController : Controller
    {
        private readonly Context _context;
        private readonly IGenericRepository<UserProfile> _repository;
        private readonly IWebHostEnvironment webHostEnvironment1;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IAuthRepository _authRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IEmailSender _emailSender;
        private readonly IUnitOfWork _unitOfWork;

        public UserProfilesController(Context context, IGenericRepository<UserProfile> repository, IAuthRepository _authRepository, IWebHostEnvironment webHostEnvironment,      IEmailSender emailSender, IUnitOfWork unitOfWork)

      

        {
            this._context = context;
            this._repository = repository;
            this._webHostEnvironment = webHostEnvironment;
            this._emailSender = emailSender;
            this._unitOfWork = unitOfWork;
        }

        // GET: UserProfiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserProfiles.ToListAsync());
        }

        // GET: UserProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfile = await _context.UserProfiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userProfile == null)
            {
                return NotFound();
            }

            return View(userProfile);
        }

        // GET: UserProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,FullName,PhoneNumber,email,Address,City,Country,ProfileImage,Role")] UserProfile profile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profile);
                await _context.SaveChangesAsync();

                string roleMessage = (profile.Role == "Agent")
                 ? "You have been granted Agent rights. You can now post ads and manage your listings."
                 : "You have been granted Private Seller rights. You can now post and manage your listings.";

                string emailBody = $@"
                   <h3>Welcome, {profile.FullName}!</h3> 
                   <p>Thank you for signing up. Your role: <b>{profile.Role}</b></p>
                   <p>{roleMessage}</p>
                   <p>Login and start using our platform.</p>
               ";


                bool emailSent = await _emailSender.SendEmailAsync(profile.email, "Welcome to Our Platform", emailBody);

                if (emailSent)
                {
                    TempData["Message"] = "Profile created successfully. Check your email for confirmation.";
                }
                else
                {
                    TempData["Error"] = "Profile created, but email sending failed.";
                }

                return RedirectToAction("index", "Home");
            }
            return View(profile);
        }
        public IActionResult ImageInsert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ImageInsert(UserProfile profile)
        {
                if (profile.ProfileImage == null)
                {
                    return BadRequest("Invalid product data or image path.");
                }

                string folder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                string fileName = Guid.NewGuid().ToString() + "_" + profile.ProfileImage.FileName;
                string path = Path.Combine(folder, fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await profile.ProfileImage.CopyToAsync(stream);
                }

                UserProfile userProfile = new UserProfile()
                {
                    FullName = profile.FullName,
                    PhoneNumber = profile.PhoneNumber,
                    Address = profile.Address,
                    City = profile.City,
                    Country = profile.Country,
                    Role = profile.Role,
                    ProfileImage = fileName,
                    email = profile.email,
                };

            _context.UserProfiles.Add(userProfile);
            await _context.SaveChangesAsync();

            return RedirectToAction("Home", "Index");
        }





        // GET: UserProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfile = await _context.UserProfiles.FindAsync(id);
            if (userProfile == null)
            {
                return NotFound();
            }
            return View(userProfile);
        }

        // POST: UserProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,FullName,PhoneNumber,email,Address,City,Country,ProfileImage,Role")] UserProfile userProfile)
        {
            if (id != userProfile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserProfileExists(userProfile.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userProfile);
        }

        // GET: UserProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfile = await _context.UserProfiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userProfile == null)
            {
                return NotFound();
            }

            return View(userProfile);
        }

        // POST: UserProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userProfile = await _context.UserProfiles.FindAsync(id);
            if (userProfile != null)
            {
                _context.UserProfiles.Remove(userProfile);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserProfileExists(int id)
        {
            return _context.UserProfiles.Any(e => e.Id == id);
        }
    }
}
