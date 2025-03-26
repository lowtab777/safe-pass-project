using Microsoft.EntityFrameworkCore;
using SafePassAppBackend.DTOs;
using SafePassAppBackend.Interfaces;
using SafePassAppBackend.Models;
using SafePassAppBackend.Repositories;

namespace SafePassAppBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User, Guid> _repositiory;

        public UserService(IRepository<User, Guid> repository)
        {
            _repositiory = repository;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }
            var res = _repositiory.Find(e => e.Email == email);
            return await res.FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserById(Guid id)
        {
            return await _repositiory.GetById(id);
        }



        public async Task<bool> ReassignUserRole(int roleId)
        {
            throw new NotImplementedException(); // later
        }
    }
}
