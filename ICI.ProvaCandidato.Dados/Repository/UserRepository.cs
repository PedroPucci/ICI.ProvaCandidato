using ICI.ProvaCandidato.Dados.Repository.Interfaces;
using ICI.ProvaCandidato.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _context;

        public UserRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<UserEntity> AddUserAsync(UserEntity userModel)
        {
            var result = await _context.UserModel.AddAsync(userModel);
            return result.Entity;
        }
        public UserEntity UpdateUser(UserEntity userEntity)
        {
            var response = _context.UserModel.Update(userEntity);
            return response.Entity;
        }

        public async Task<List<UserEntity>> GetAllUsersAsync()
        {
            return await _context.UserModel.OrderBy(user => user.Name).Select(user => new UserEntity
            {
                Id = user.Id,
                Name = user.Name,
                Mail = user.Mail
            }).ToListAsync();
        }

        public async Task<UserEntity> GetUserByNameAsync(string name)
        {
            return await _context.UserModel.FirstOrDefaultAsync(user => user.Name == name);
        }
    }
}