using eproject2.Data;
using eproject2.Models;
using eproject2.Reposatory.Interface;
using eproject2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class UserProfilesController : Controller
{
    private readonly IUserProfileRepository _userProfileRepository;
    private readonly IEmailSender _emailSender;
    private readonly IWebHostEnvironment _webHostenvironment;
    private readonly Context _context;

    public UserProfilesController(Context context, IUserProfileRepository userProfileRepository, IEmailSender emailSender, IWebHostEnvironment webHostEnvironment)
    {
        this._userProfileRepository = userProfileRepository;
        this._emailSender = emailSender;
        this._webHostenvironment = webHostEnvironment;
        this._context = context;
    }
    [Route("userform")]

    public async Task<IActionResult> userform()
    {
        var users = await _userProfileRepository.GetAllAsync();
        return View("userform", users);
    }



    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var userProfile = await _userProfileRepository.GetByIdAsync(id.Value);
        if (userProfile == null) return NotFound();

        return View(userProfile);
    }
    [Route("Create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,UserId,FullName,PhoneNumber,email,Address,City,Country,ProfileImage,Role")] UserProfile profile)
    {
        if (ModelState.IsValid)
        {
            await _userProfileRepository.AddAsync(profile);

            string roleMessage = (profile.Role == "Agent")
                ? "You have been granted Agent rights."
                : "You have been granted Private Seller rights.";

            string emailBody = $"<h3>Welcome, {profile.FullName}!</h3><p>{roleMessage}</p>";
            bool emailSent = await _emailSender.SendEmailAsync(profile.email, "Welcome", emailBody);

            TempData["Message"] = emailSent ? "Profile created successfully." : "Profile created, but email failed.";
            return RedirectToAction("Index", "Home");
        }
        return View(profile);
    }
    [Route("Imageinsert")]
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

        string folder = Path.Combine(_webHostenvironment.WebRootPath, "images");
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



    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,FullName,PhoneNumber,email,Address,City,Country,ProfileImage,Role")] UserProfile profile)
    {
        if (id != profile.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                await _userProfileRepository.UpdateAsync(profile);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _userProfileRepository.ExistsAsync(profile.Id)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(profile);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var userProfile = await _userProfileRepository.GetByIdAsync(id.Value);
        if (userProfile == null) return NotFound();

        return View(userProfile);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _userProfileRepository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}