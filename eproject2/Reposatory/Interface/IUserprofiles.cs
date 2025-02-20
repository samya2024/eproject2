using eproject2.Models;

namespace eproject2.Reposatory.Interface
{
    public interface IUserProfileRepository
    {
        Task<IEnumerable<UserProfile>> GetAllAsync();
        Task<UserProfile> GetByIdAsync(int id);
        Task AddAsync(UserProfile profile);
        Task UpdateAsync(UserProfile profile);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
