using SafePassAppBackend.Models;

namespace SafePassAppBackend.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUserById(Guid id);
        Task<User?> GetUserByEmail(string email);

        // Если будут идеи - добавит больше операций с роялми
        Task<bool> ReassignUserRole(int roleId);
    }
}
