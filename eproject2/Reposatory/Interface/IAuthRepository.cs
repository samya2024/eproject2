using eproject2.Models;

namespace eproject2.Repositories.Interfaces
{
    
        public interface IAuthRepository
        {
        
          Task<Users> AuthenticateUserAsync(string email, string password);
        Task<bool> IsEmailExistsAsync(string email);
        Task<(bool IsSuccess, string Message)> RegisterUserAsync(Users user);
        Task<(bool IsSuccess, string Message)> LoginUserAsync(string email, string password);
        Task LogoutAsync();
    }


    }

