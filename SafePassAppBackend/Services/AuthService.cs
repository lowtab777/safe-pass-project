using Microsoft.EntityFrameworkCore;
using SafePassAppBackend.DTOs;
using SafePassAppBackend.Interfaces;
using SafePassAppBackend.Models;
using SafePassAppBackend.Repositories;

namespace SafePassAppBackend.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<User, Guid> _userRespository;
        public AuthService(IRepository<User, Guid> userRespository)
        {
            _userRespository = userRespository;
        }
        public async Task<User?> LoginUser(UserLoginDto user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var existingUser = _userRespository.Find(u => u.Login == user.Login && u.Password == user.Password);
            return await existingUser.FirstOrDefaultAsync();
        }

        public async Task<User> RegisterUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return await _userRespository.AddAsync(user);
        }
    }
}
