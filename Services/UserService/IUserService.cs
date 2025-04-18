using System.Collections.Generic;
using System.Threading.Tasks;
using UserModel = Tender_management.Models.User;

namespace TenderManagementSystem.Services.User
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetUserByIdAsync(int id);
        Task CreateUserAsync(UserModel user);
        Task UpdateUserAsync(UserModel user);
        Task DeleteUserAsync(int id);
    }
}
