using eproject2.Data;
using eproject2.Migrations;
using eproject2.Models;
using eproject2.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace eproject2.Repositories.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly Context _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        // Constructor that injects Context and IHttpContextAccessor
        public AuthRepository(Context context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> IsEmailExistsAsync(string email)
        {
            // Check if email already exists in the database
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<Users> AuthenticateUserAsync(string email, string password)
        {
            // Find the user by email
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return null; // User not found
            }

            // Check if the entered password matches the stored password
            if (password == user.Password)
            {
                return user; // Authentication successful
            }

            return null; // Invalid credentials
        }
        public async Task<(bool IsSuccess, string Message)> RegisterUserAsync(Users user)
        {
            try
            {
                if (await _context.Users.AnyAsync(u => u.Email == user.Email))
                {
                    return (false, "Email is already registered.");
                }

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return (true, "Registration successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in RegisterUserAsync: {ex.Message}");
                return (false, "An error occurred during registration. Please try again.");
            }
        }

        public async Task<(bool IsSuccess, string Message)> LoginUserAsync(string email, string password)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
                if (user == null)
                {
                    return (false, "Invalid email or password.");
                }

                _httpContextAccessor.HttpContext.Session.SetString("Email", user.Email);
                _httpContextAccessor.HttpContext.Session.SetString("Role", user.Role);

                return (true, "Login successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in LoginUserAsync: {ex.Message}");
                return (false, "An error occurred during login. Please try again.");
            }
        }


        // Password verification function
        private bool VerifyPassword(string enteredPassword, string storedPasswordHash)
        {
            // Hash verification logic (agar hashing use kar rahe hain)
            return enteredPassword == storedPasswordHash; // Replace with hashing logic
        }
        
        public async Task LogoutAsync()
        {
            // Clear the session when logging out
            _httpContextAccessor.HttpContext.Session.Clear();
            await Task.CompletedTask;
        }
    }
}
