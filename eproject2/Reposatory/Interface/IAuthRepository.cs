using eproject2.Models;
using System.Threading.Tasks;

namespace eproject2.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<Users> AuthenticateUserAsync(string email, string password);
        Task<bool> IsEmailExistsAsync(string email); // Email existence check
        Task<(bool IsSuccess, string Message, int UserId)> RegisterUserAsync(Users user); // Returns UserId
        Task<(bool IsSuccess, string Message)> LoginUserAsync(string email, string password);
        Task LogoutAsync();
    }
}
