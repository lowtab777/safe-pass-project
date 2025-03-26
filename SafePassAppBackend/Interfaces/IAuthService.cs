using SafePassAppBackend.DTOs;
using SafePassAppBackend.Models;

namespace SafePassAppBackend.Interfaces
{
    public interface IAuthService
    {
        Task<User?> LoginUser(UserLoginDto user);
        Task<User> RegisterUser(User user);
    }
}
