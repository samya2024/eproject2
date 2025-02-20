using eproject2.Models;
using eproject2.Reposatory.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class UserProfilesController : Controller
{
    private readonly IUserProfileRepository _userProfileRepository;
    private readonly IEmailSender _emailSender;

    public UserProfilesController(IUserProfileRepository userProfileRepository, IEmailSender emailSender)
    {
        _userProfileRepository = userProfileRepository;
        _emailSender = emailSender;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _userProfileRepository.GetAllAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var userProfile = await _userProfileRepository.GetByIdAsync(id.Value);
        if (userProfile == null) return NotFound();

        return View(userProfile);
    }

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