﻿using eproject2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using eproject2.Repositories.Interfaces;
using eproject2.Data;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using eproject2.Reposatory.Interface;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using eproject2.Migrations;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace eproject2.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepository;
        private readonly Context _context;
        private readonly IEmailSender _EmailSender;

        public AuthController(IAuthRepository authRepository, Context context, IEmailSender emailSender)
        {
            _EmailSender = emailSender;
            _authRepository = authRepository;
            _context = context;
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

        [HttpPost]
        public async Task<IActionResult> Register(Users user)
        {
            if (await _authRepository.IsEmailExistsAsync(user.Email))
            {
                ModelState.AddModelError("Email", "Email is already registered.");
                return View(user);
            }



            var (isSuccess, message, userId) = await _authRepository.RegisterUserAsync(user);

            if (ModelState.IsValid)
            {

                TempData["Message"] = "Registration successful! Please log in.";
                return RedirectToAction("Login");
            }

            TempData["Error"] = "Registration failed. Try again.";
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.SuccessMessage = TempData["Message"];
            ViewBag.ErrorMessage = TempData["ErrorMessage"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {

            var (isSuccess, message) = await _authRepository.LoginUserAsync(email, password);
            if (isSuccess)
            {


                bool emailSent = await _EmailSender.SendEmailAsync(email,"Login" ,"Your Account Approval");

                TempData["SuccessMessage"] = "Login successful! Welcome.";
                return RedirectToAction("Index", "Home");
            }
            TempData["ErrorMessage"] = message;
            return RedirectToAction("Login");


            ModelState.AddModelError(string.Empty, message);
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            TempData["Message"] = "You have been logged out !";
            Response.Cookies.Delete(".AspNetCore.Cookies");
            return RedirectToAction("Login", "Auth");
        }
    }
}
