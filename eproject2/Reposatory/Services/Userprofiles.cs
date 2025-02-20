using eproject2.Data;
using eproject2.Models;
using eproject2.Reposatory.Interface;
using Microsoft.EntityFrameworkCore;

namespace eproject2.Reposatory.Services
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly Context _context;

        public UserProfileRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserProfile>> GetAllAsync()
        {
            return await _context.UserProfiles.ToListAsync();
        }

        public async Task<UserProfile> GetByIdAsync(int id)
        {
            return await _context.UserProfiles.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddAsync(UserProfile profile)
        {
            _context.Add(profile);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserProfile profile)
        {
            _context.Update(profile);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var userProfile = await _context.UserProfiles.FindAsync(id);
            if (userProfile != null)
            {
                _context.UserProfiles.Remove(userProfile);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.UserProfiles.AnyAsync(e => e.Id == id);
        }

    }
}
