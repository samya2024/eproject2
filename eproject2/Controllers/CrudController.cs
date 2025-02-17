using eproject2.Data;
using eproject2.Models;
using eproject2.Reposatory.Interface;
using eproject2.Reposatory.Services;
using eproject2.Repositories.Interfaces;
using eproject2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eproject2.Controllers
{
    public class CrudController : Controller
    {
        private readonly IAuthRepository _authRepository;
        private readonly Context _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IEmailSender _EmailSender;
      
       



        public CrudController(IAuthRepository authRepository, Context context, IWebHostEnvironment webHostEnvironment, IEmailSender emailSender)
        {
            _authRepository = authRepository;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _EmailSender = emailSender;
        
        }

        public async Task<IActionResult> Welcome()
        {
            TempData.Keep("Data Inserted");
            var data = await _context.UserProfiles.ToListAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserProfile profile)
        {
            if (ModelState.IsValid)
            {
                await _context.UserProfiles.AddAsync(profile);
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

                
                bool emailSent = await _EmailSender.SendEmailAsync(profile.email, "Welcome to Our Platform", emailBody);

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
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue || _context.UserProfiles == null)
            {
                return NotFound();
            }

            var details = await _context.UserProfiles.FindAsync(id);
            return View(details);
        }

        public IActionResult ImageInsert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ImageInsert(ProfileViewModel profile)
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

            return RedirectToAction("Welcome");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue || _context.UserProfiles == null)
            {
                return NotFound();
            }

            var edit = await _context.UserProfiles.FindAsync(id);
            return View(edit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UserProfile profile)
        {
            if (id != profile.Id || _context.UserProfiles == null)
            {
                return NotFound();
            }

            _context.UserProfiles.Update(profile);
            await _context.SaveChangesAsync();

            TempData["Message"] = "Profile updated successfully!";
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue || _context.UserProfiles == null)
            {
                return NotFound();
            }

            var user = await _context.UserProfiles.FindAsync(id);
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var user = await _context.UserProfiles.FindAsync(id);
            if (user == null)
            {
                return RedirectToAction("Welcome");
            }

            _context.UserProfiles.Remove(user);
            await _context.SaveChangesAsync();

            TempData["Message"] = "User deleted successfully!";
            return RedirectToAction("Welcome");
        }
    }
}
