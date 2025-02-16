using eproject2.Data;
using eproject2.Models;
using eproject2.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace eproject2.Repositories.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly Context _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        // Constructor injecting Context and HttpContextAccessor
        public AuthRepository(Context context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> IsEmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<Users> AuthenticateUserAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null || password != user.Password)
            {
                return null;
            }
            return user;
        }

        public async Task<(bool IsSuccess, string Message, int UserId)> RegisterUserAsync(Users user)
        {
            try
            {
                if (await _context.Users.AnyAsync(u => u.Email == user.Email))
                {
                    return (false, "Email is already registered.", 0);
                }

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return (true, "Registration successful. Please complete your profile.", user.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in RegisterUserAsync: {ex.Message}");
                return (false, "An error occurred during registration. Please try again.", 0);
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
                _httpContextAccessor.HttpContext.Session.SetString("UserId", user.Id.ToString());

                return (true, "Login successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in LoginUserAsync: {ex.Message}");
                return (false, "An error occurred during login. Please try again.");
            }
        }

        public async Task<bool> ApproveUserAsync(int userId, string role)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task LogoutAsync()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
            await Task.CompletedTask;
        }
    }
}
