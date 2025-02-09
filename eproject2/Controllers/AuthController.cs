using eproject2.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using eproject2.Repositories.Interfaces;
using eproject2.Repositories.Services;
using Microsoft.Extensions.Options;
using eproject2.Data;
using eproject2.Migrations;
using Microsoft.AspNetCore.Authentication;


namespace eproject2.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepository;
         private readonly Context _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AuthController (IAuthRepository authRepository, Context context, IWebHostEnvironment webHostEnvironment)
        {
        
             this._context = context;
            this._webHostEnvironment = webHostEnvironment;
          this._authRepository = authRepository;

        }
   

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        public async Task<IActionResult> Register(Users user)
        {
            var (isSuccess, message) = await _authRepository.RegisterUserAsync(user);

            if (isSuccess)
            {
                TempData["SuccessMessage"] = message;
                return RedirectToAction("Login");
            }

            ModelState.AddModelError(string.Empty, message);
            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var (isSuccess, message) = await _authRepository.LoginUserAsync(email, password);

            if (isSuccess)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, message);
            return View();
        }


        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(); // Auth user session sign-out karein
            HttpContext.Session.Clear(); // Session clear karein
            Response.Cookies.Delete(".AspNetCore.Cookies"); // Authentication cookie delete karein
            return RedirectToAction("Login", "Auth"); // Login page par bhej dein     
        }



        }
   }
