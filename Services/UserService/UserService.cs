using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tender_management.Infrastructure;
using UserModel = Tender_management.Models.User;

namespace TenderManagementSystem.Services.User
{
    public class UserService : IUserService
    {
        private readonly EFCoreDBContext _context;

        public UserService(EFCoreDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task CreateUserAsync(UserModel user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UserModel user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}